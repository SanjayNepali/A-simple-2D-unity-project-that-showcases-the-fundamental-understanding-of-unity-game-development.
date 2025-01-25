using UnityEngine;
using System.Collections;

public class Laser : MonoBehaviour
{

public float laserLength = 10f;
public float onDuration = 2f;
public float offDuration = 2f;
public LineRenderer lR;

public void Start(){

StartCoroutine (LaserRoutine());//couritines are used for delayed execution so this here helps us pause and resume execution(i.e laser on and off)

}

IEnumerator LaserRoutine(){
while (true){//infinite loop so our laser beam keeps switching behavior
        // Laser On
        lR.enabled = true;
        yield return new WaitForSeconds (onDuration);//wait for laser to stay inactive

        // Laser Off
        lR.enabled = false;
        yield return new WaitForSeconds (offDuration);//wait until laser is to stay active


        }
    }


void Update(){
    if(lR.enabled){
        //cast an invisible ray down wards from laser's origin heling us detect if it hits any object
        RaycastHit2D hit =Physics2D.Raycast(transform.position, Vector2.down, laserLength);//we can change the direction by changing the second parameter
        lR.SetPosition(0, transform.position);//set the starting point at the origin

    if (hit.collider != null){
            lR.SetPosition(1, hit.point);}

if (hit.collider.CompareTag("Player")){
    //When The laser hits player, Player Respawns at checkpoint
    GameManager.instance.RespawnPlayerAtCheckPoint();
        }
    }
}
}