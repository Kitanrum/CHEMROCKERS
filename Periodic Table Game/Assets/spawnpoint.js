#pragma strict

public var element : Rigidbody[];
public var instance : Rigidbody;
//public var player : Transform;
public var playerCanon : GameObject[];
public var spawn : Transform[];
//audioclips
//public var explosion : AudioSource;
//public var sides : AudioSource;
//public var down : AudioSource;
//next fire one next turn
public var nextFire : float = 0.0;
//if dead and comes in contact audioclip explosion will play 
public var move : BlockMR;

function start () {

	playerCanon = GameObject.FindGameObjectsWithTag("ElementSpawnPoint");
	spawn = new Transform[Random.Range(0,playerCanon.length-1)];
}

function Update(){

    if(!instance){

        StartCoroutine(Spawn());
        StopCoroutine(Spawn());

    }

}
public function Spawn(){

	var spawn = playerCanon[Random.Range(0,3)];

	instance = Instantiate(element[Random.Range(0,5)],spawn.transform.position, spawn.transform.rotation);

    yield WaitForSeconds(nextFire);

}
