using UnityEngine;

public class CheckPoint : MonoBehaviour
{

public PlayerController player;

void Start(){
   player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
}
void OnTriggerEnter2D(Collider2D collide){
    if (collide.gameObject.CompareTag("Player")){
        //when we collide with a checkpoint it stores the position in the GameManager 
        GameManager.instance.SetCheckpoint(transform.position);
    }
}
}
