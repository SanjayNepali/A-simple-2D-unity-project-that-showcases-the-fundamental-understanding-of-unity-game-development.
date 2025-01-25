using UnityEngine;

public class Projectile : MonoBehaviour
{
  private PlayerController player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    private void OnTriggerEnter2D( Collider2D other){
        if(other.CompareTag("Player")){
            player.TakeDamage(15);
        }
}
}
