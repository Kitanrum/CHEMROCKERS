import UnityEngine;
import System.Collections;

//Runs at the beginning of game
function Start () {

    //Debug.Log("Object Created");

}

//Runs every frame of game
function Update () {

}

function OnTriggerEnter(other : Collider){

    Debug.Log("Entered Object");
    
    if(other.CompareTag("Player")){
        Destroy(gameObject);
    }
}