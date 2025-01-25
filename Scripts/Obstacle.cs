using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private PlayerController player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    private void OnTriggerEnter2D( Collider2D other){
        if(other.CompareTag("Player")){
            player.TakeDamage(5);//decreases player health by 5 when in contact with obstacle (i.e spikes in the game)
        }
}

}