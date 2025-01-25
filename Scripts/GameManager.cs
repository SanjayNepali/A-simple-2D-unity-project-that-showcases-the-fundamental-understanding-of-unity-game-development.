using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class GameManager : MonoBehaviour
/*GameManager script contains all the game related functionality. It is good practice in Unity to create this script 
for allowing better modulation and organization. This script handles game logic like player health, timer functionality, respawing 
of player at the check point, handling UI elements. This centralized way of coding is widely used*/
{

    /*setting up game manager singleton instance so it can be accessed by other Scripts
    making it static means only one instance of game manager script is active ensuring there is no duplicates */
    public static GameManager instance;


    [SerializeField] private TextMeshProUGUI timerText; //drag and drop the Text UI objects in these fields
      [SerializeField] private TextMeshProUGUI finalTime;

 private float startTime;
 private float elapsedTime;
    
     public Vector3 currentCheckPoint;//
    
    public PlayerController player;

    public GameObject gameOver;
    public GameObject mainUI;
    
    private bool isGameOver=false;


    void Awake(){
        startTime=Time.time;// captures the start time of the game
        // finds the object with "Player"tag and gets the playercontroller component and attaches it to player variable of PlayerController type
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();/*allows access of methods or 
                                                                                                variables form the PlayerController script*/
if(instance==null){
        instance= this;

        DontDestroyOnLoad(gameObject);
    } else{
        //if any other managers exits it destroys that
            Destroy(gameObject);
    }
    //GameOver Panel
        gameOver = GameObject.Find("GameOverUI");

        //Main UI panel
         mainUI = GameObject.Find("Main UI");

         if(gameOver!=null){
            // when the game is loaded make sure that the GameOverUI is not active we need to activate it only when player is dead
            gameOver.SetActive(false);//By using this block of code the panel is automatically disabled when we load the game
         }
         if(mainUI!=null){
            //if the mainUI panel is not active 
            mainUI.SetActive(true);//Activate the Main UI at the start 
         }
    
    }
    void Update(){
        if(instance==this&&!isGameOver){
        elapsedTime= Time.time-startTime;
        int minutes = Mathf.FloorToInt(elapsedTime/60);
        int seconds = Mathf.FloorToInt(elapsedTime%60);
        timerText.text = string.Format("{0:D2}:{1:D2}", minutes, seconds);
       
    }
    }
    //this method is assigned to the restart button for restarting the scene 
public void RestartScene(){
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
   startTime=Time.time;
   
}
//Method to set a new checkpoint 
public void SetCheckpoint(Vector3 position){
    currentCheckPoint = position;

}
public void RespawnPlayerAtCheckPoint(){
    //condition makes sure the current checkpoint is not null
    if(currentCheckPoint!=null){
        player.transform.position = currentCheckPoint;
    }
}
public void GameOver(){
    gameOver.SetActive(true);
    mainUI.SetActive(false);
    isGameOver=true;
     finalTime.text = timerText.text;
   
}
//When Game Over Button is pressed Game Over UI is activated
public void GameOverButton(){
    gameOver.SetActive(true);
    mainUI.SetActive(false);
    player.body.linearVelocity= Vector2.zero;
    player.animator.SetTrigger("isDead");
    player.gameObject.SetActive(false); 
}


public void LoadNextLevel(){
    //Getting the index of the current Scene
    int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
 int nextSceneIndex=currentSceneIndex+1;

 //Check in Build settings for making sure the next scene exists
 if(nextSceneIndex<SceneManager.sceneCountInBuildSettings){
    SceneManager.LoadScene(nextSceneIndex);
 }

}
}