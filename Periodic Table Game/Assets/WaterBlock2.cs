using UnityEngine;
using System.Collections;

public class WaterBlock2 : MonoBehaviour {
	public Transform WaterCube2;
	public Transform Position1;
	public Transform Position2;
	public Transform Position3;
	public Transform Position4;
	public Vector3 newPosition;
	public string currentState;
	public float smooth;
	public float resetTime;
	public GameObject Damage;
	

	// Use this for initialization
	void Start () 
	{
		ChangeTarget();
		Damage.SetActive(true);
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		WaterCube2.position = Vector3.Lerp(WaterCube2.position, newPosition, smooth * Time.deltaTime);
		
	}

	void ChangeTarget()
	{
		if(currentState == "Moving To Position 3")
		{
			currentState = "Moving To Position 2";
			newPosition = Position2.position;
		}
		else if(currentState == "Moving To Position 2")
		{
			currentState = "Moving To Position 1";
			newPosition = Position1.position;
		}
		else if(currentState == "Moving To Position 1")
		{
			currentState = "Moving To Position 4";
			newPosition = Position4.position;
		}
		else if(currentState == "Moving To Position 4")
		{
			currentState = "Moving To Position 3";
			newPosition = Position3.position;
		}
		else if(currentState == "")
		{
			currentState = "Moving To Position 3";
			newPosition = Position3.position;
		}
		Invoke("ChangeTarget", resetTime);
	}
	public void OpenDamageCollider()
	{
		Damage.SetActive(true);
	}
}
