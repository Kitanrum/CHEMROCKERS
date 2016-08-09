import UnityEngine;
import System.Collections;
import System.Collections.Generic;

var blockPos : Vector3;
var block : GameObject;
var moveDelay : float;
var dead : boolean = false;


function Start(){
    //blockPos = transform.Position;

    
}
function Update () {

        StartCoroutine(MoveBlock());
        StartCoroutine(RotateBlock());
       
}

function MoveBlock(){

    

    
        if(Input.GetKeyDown(KeyCode.S)){
        
            //blockPos = Vector3(0, 0, -1);
            transform.Translate(Vector3.back);
        
            moveDelay = Mathf.Max(0.5, moveDelay - 0.01);
            
            yield WaitForSeconds(moveDelay);

        }

        if(Input.GetKeyDown(KeyCode.A)){
        
            //blockPos = Vector3(-1, 0, 0);
            transform.Translate(Vector3.left);
        
            moveDelay = Mathf.Max(0.5, moveDelay - 0.01);

            

            yield WaitForSeconds(moveDelay);
        }
        if(Input.GetKeyDown(KeyCode.D)){
        
            //blockPos = Vector3(1, 0, 0);
            transform.Translate(Vector3.right);
        
            moveDelay = Mathf.Max(0.5, moveDelay - 0.01);

            

            yield WaitForSeconds(moveDelay);
        }

    
    
}

function RotateBlock(){
    
    if(Input.GetKeyDown(KeyCode.E)){

        //blockPos = Vector3(0,90,0);
        transform.Rotate(Vector3.left);

        moveDelay = Mathf.Max(0.5, moveDelay - 0.01);
        
        yield WaitForSeconds(moveDelay);
    }

    if(Input.GetKeyDown(KeyCode.Q)){

        //blockPos = Vector3(0,-90,0);
        transform.Rotate(Vector3.right);

        moveDelay = Mathf.Max(0.5, moveDelay - 0.01);
        
        yield WaitForSeconds(moveDelay);
    }
}

function OnTriggerEnter(other : Collider){

    if(other.gameObject.tag == "Respawn"){
        dead = true;
        Destroy(block);
    }
}