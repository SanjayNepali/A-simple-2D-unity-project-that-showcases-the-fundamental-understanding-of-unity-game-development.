using UnityEngine;

public class NextLevel : MonoBehaviour
{

     private void OnTriggerEnter2D( Collider2D other){
        if(other.CompareTag("Player")){
            GameManager.instance.LoadNextLevel();
        }

}
}
