import UnityEngine;
import System.Collections;
import System.Collections.Generic;

var diceRoll : float;


function Start () {

}

function Update () {

    if(Input.GetKeyDown(KeyCode.T)){
        diceRoll = Random.Range(1,6);
        Debug.Log(diceRoll);
    }
}