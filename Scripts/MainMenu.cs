using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
  public void StartTheGame(){
    SceneManager.LoadScene(1);
  }
  public void ExitApplication(){
    Application.Quit();
  }
}
