  import UnityEngine;
  import System.Collections;
  
  public var CoinCount : int = 0; //Total # of Coins in scene
  public var Coins : GameObject[];
  //Runs at the beginning of game
  function Start ()  {

      //Debug.Log("Object Created");

      Coins = GameObject.FindGameObjectsWithTag("Coin");

      CoinCount = Coins.length;

  } 

  //Runs every frame of game

  function Update ()  {

 Coins = GameObject.FindGameObjectsWithTag("Coin");
 CoinCount = Coins.length;
 Collection();

  }
  
function Collection() {

    if(CoinCount <= 0) {
        Debug.Log("you won !!");
          }

    }


  function OnTriggerEnter (other : Collider) {

      Debug.Log("Entered Object");
      if (other.CompareTag("Player")) {
      	Destroy(gameObject);
         }  
  }
  