using UnityEngine;
// adding unity UI lets us access UI elements in the script
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    // SerializeField helps manually change values of variabled directly in the unity inspector
    [SerializeField] private float moveSpeed;// speed of the player
    [SerializeField] private float jumpForce = 20f;
    public Rigidbody2D body;
    public Animator animator;
    private BoxCollider2D boxCollider2d;
    private bool grounded;

    [SerializeField] private LayerMask Ground;
    public int maxHealth = 100;
    public int currentHealth = 100;
    public Image healthBar;
    public bool dead;

    private bool canDoubleJump;
    private int jumpCount;

  // initializing variables for Power UP system
    private float initialSpeed; // storing the original speed of the player before colliding with the spped
    private bool isSpeedIncreased;
    private float speedBoostEndTime;
    private float initialJumpForce; // store the original jump force
    private bool isJumpIncreased;
    private float jumpBoostEndTime;

    private void Awake()
    {
        //To access the Components from of the Player in the code itself
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        boxCollider2d = GetComponent<BoxCollider2D>();

        // Health UI
        healthBar = GameObject.Find("Health UI").GetComponent<Image>();

        // Store the original move speed and jump force for power-up resets
        initialSpeed = moveSpeed;
        initialJumpForce = jumpForce;
    }

    private void Update()
    {
        if(dead){
            //when Player is dead this changes players velocity to zero for no movement after player health is null
            body.linearVelocity = Vector2.zero;
        }
// storing the method in the grounded boolean to check wheter the player is touching the ground or not
        grounded = IsGrounded();

        // calling the method for player movement in update mthod so it runs always 
        MovePlayer();

        //plays idle animation when player is grounded this transition condition switches from jump back to idle
        animator.SetBool("grounded", grounded);

        if(grounded){

            canDoubleJump = true;
            jumpCount = 0;
        }
//this function takes input (i.e space bar) from the keyboard
        if (Input.GetKeyDown(KeyCode.Space)) {
            if(grounded || canDoubleJump){
                  JumpPlayer();
                jumpCount++;
            if(jumpCount >= 1){
                    canDoubleJump = false; // Disabling double jump ability after two jumps
        }
            }
        }
//When the player presses F key attack animation is triggered
        if(Input.GetKeyDown(KeyCode.F)) {
            animator.SetTrigger("attack");
        }

        // Check if the speed boost has expired
        if(isSpeedIncreased && Time.time > speedBoostEndTime){
            RemoveSpeedBoost();
        }

        // Check if the jump boost has expired
        if(isJumpIncreased && Time.time > jumpBoostEndTime) {
            RemoveJumpBoost();
        }
    }
// This is the method that is responsible for handling player movements 
    private void MovePlayer(){
        body.constraints = RigidbodyConstraints2D.FreezeRotation;
// storing Player's horizontal movement in a variable for we dont have to use GetAxis function repeatedly
        float horizontalMovement = Input.GetAxis("Horizontal");

        // Move player horizontally (i.e x axis) keeping y axis as it is 
        body.linearVelocity = new Vector2(horizontalMovement * moveSpeed, body.linearVelocity.y);
if(horizontalMovement > 0.01f && transform.localScale.x < 0) {
            transform.localScale = Vector3.one;
        }else if(horizontalMovement < -0.01f && transform.localScale.x > 0)    {
         // When player changes direction from right to left it flips the player
    
            transform.localScale = new Vector3(-1, 1, 1);
        }

        //When player moves in x axis the run boolean returns true setting the transition from idle to walking
        animator.SetBool("run", horizontalMovement != 0);
    }
// this method is called when space bar is pressed so that our player jumps when the condition is met
    private void JumpPlayer(){
        body.linearVelocity = new Vector2(body.linearVelocity.x, jumpForce);// Jump player
         grounded = false;// Player is no longer grounded
    }
// Method of boolean type because we have to return a boolean valur true or false based on whether the player is grounded or not 
    private bool IsGrounded(){
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider2d.bounds.center,boxCollider2d.bounds.size,0f,Vector2.down
        ,0.1f, // Small offset to ensure detection
            Ground);
        return raycastHit.collider != null;
    }


    // Method for decreasing playerHealth
    public void TakeDamage(int damageAmount){
        currentHealth -= damageAmount;

        if(currentHealth<=0){
            dead = true;

            Debug.Log("Player has died");
            //This method is called so that player movement is disabled when dead is true
            SelfDestruct();
        }
//
        UpdateHealthBar();
    }

    // Method recovering health when health object is aquired
    public void RecoverHealth(int recoverAmount) {
        // this function gets the mininum Smalles value it is used so that currentHealth is not greater than max health
        currentHealth = Mathf.Min(currentHealth + recoverAmount, maxHealth);
        UpdateHealthBar();
    }

    public void UpdateHealthBar(){
        if(healthBar != null){
            //health bar is an image with filling property so it is updated according to damage and recover
            healthBar.fillAmount = (float)currentHealth / maxHealth;
        }
    }

    public void SelfDestruct(){
                    // Trigger dead animation when player Health reaches 0
            //animator.SetTrigger("isDead"); this didnt work because the next line disables the script when the player is dead in Take Damage method
        this.enabled = false;//disable the script
        GameManager.instance.GameOver();


    }

    // Method to increase speed of the player
    public void MakeSpeedBoost(float multiplier, float duration){
        if(!isSpeedIncreased){
            moveSpeed *= multiplier;
            isSpeedIncreased = true;
            speedBoostEndTime= Time.time + duration; // Set the end time for speed
        }
    }

    private void RemoveSpeedBoost(){
      moveSpeed = initialSpeed; // Reset the speed to its initial value
        isSpeedIncreased = false; }

 // Method to boost jump force of player
    public void MakeJumpBoost(float multiplier, float duration) {
        if(!isJumpIncreased){
            jumpForce *= multiplier;
            isJumpIncreased = true;
            jumpBoostEndTime = Time.time + duration; // Set the end time for jump boost
    }
    }

    private void RemoveJumpBoost() {
        jumpForce = initialJumpForce; // Reset the jump force to its initial value
        isJumpIncreased = false;
    }
}
