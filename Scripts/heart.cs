using UnityEngine;

public class heart : MonoBehaviour
{
    private PlayerController playerobj;
    
       
      
  void Start()
    {       
       


    playerobj = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();

       
    }
     private void OnTriggerEnter2D( Collider2D other){
        if(other.CompareTag("Player")){
    playerobj.RecoverHealth(10);
            Destroy(gameObject);
            
        }
        
}

}
