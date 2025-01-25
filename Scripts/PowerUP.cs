using UnityEngine;

public abstract class PowerUp : MonoBehaviour
{
    public float duration; // Duration the power-up effect lasts


    /*an abstract method basically means it does not have any implementation im using this so that i can override this method in another 
    sub class and provide implementation. Here i need player to perform two different powerups so creating an abstact class allows 
    implementaion of different effect based on subclass.*/
    public abstract void ApplyEffect(PlayerController player); 
}
