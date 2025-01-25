using UnityEngine;
using System.Collections;

public class ProjectileSpawner : MonoBehaviour
{
    //this is what we will shoot
[SerializeField] GameObject projectilePrefab;
[SerializeField] float projectileSpeed=5f;
[SerializeField] float timeBetweenShots=2f;
[SerializeField] float destroyProjectile=5f;

void Start(){
    StartCoroutine(ShootRoutine());
}
IEnumerator ShootRoutine(){
    while(true){
    //wait for specific time between shots
    yield return new WaitForSeconds(timeBetweenShots);
    ShootProjectile();
    }
}
//Method to shoot projectile
void ShootProjectile(){
    //Create a new projectile at that spawn position
    GameObject projectile = Instantiate(projectilePrefab,transform.position,Quaternion.identity);

    //get rigid body component for each prefab
    Rigidbody2D rigidbody = projectile.GetComponent<Rigidbody2D>();
    rigidbody.linearVelocity= Vector2.left * projectileSpeed;
    //Destroy projectile after some time
    Destroy(projectile,destroyProjectile);
}



}