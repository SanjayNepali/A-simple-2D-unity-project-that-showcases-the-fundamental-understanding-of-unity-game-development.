using UnityEngine;
// this is a sub class of the PowerUp script doing this allows a more organized code by inheriting functionlity from the parent class
public class SpeedBoost : PowerUp
{
public float speedMultiplier = 1.5f; // Multiplier value for the player's speed
private PlayerController playerobj;
void Start(){
     playerobj = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
}

// A method with overrride keyword so that in the power up class Apply effect abstract method has an implementaion in the Player controller script
  public override void ApplyEffect(PlayerController player){
   
            player.MakeSpeedBoost(speedMultiplier, duration); //an instance of playercontroller script alows us to access the method from that script
    }



private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player"))// When prefab with speedBoost Script collides with the object with tag "Player" this method implements
        {
            PlayerController playerController = other.GetComponent<PlayerController>();
            if (playerController != null){
playerobj.animator.SetTrigger("powerUp");
                 ApplyEffect(playerController);//calling the overrride method which rightnow in this script implements ApplySpeedBoost method from the playercontroller script
                Destroy(gameObject); // Destroy the power-up after it has been picked up
 }
     }
    }
}
