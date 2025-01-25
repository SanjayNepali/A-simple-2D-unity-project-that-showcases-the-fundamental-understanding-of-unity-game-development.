using UnityEngine;

public class JumpBoost : PowerUp
{
    public float jumpForceMultiplier = 1.5f; // Multiplier for the player's jump force to increase at
private PlayerController playerobj;
//Here the abstract method implements another functionality (i.e invoke the jump boosting method from the player controller
void Start(){
     playerobj = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
}
    public override void ApplyEffect(PlayerController player){
        player.MakeJumpBoost(jumpForceMultiplier, duration);//instance of the script is created to acces the mrthod
    }

     private void OnTriggerEnter2D(Collider2D other) {
        //if jumpBoost prefab collides with player invoke the  overridden method from here that calls the method from playercontroller script
        if (other.CompareTag("Player")){
            PlayerController playerController = other.GetComponent<PlayerController>();
            if (playerController != null){
                playerobj.animator.SetTrigger("powerUp");
                ApplyEffect(playerController);
                Destroy(gameObject); // Destroy the power-up after it has been used
            }
        }
    }
     }
