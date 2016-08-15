using UnityEngine;
using System.Collections;

public class Block : MonoBehaviour {

    float fall =  0;
    public float fallSpeed = 1;

    public bool allowRotation = true;
    public bool limitRotation = false;
    public bool dead = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        CheckUserInput();
	
	}

    void CheckUserInput() {

        if(Input.GetKeyDown(KeyCode.RightArrow)) {

            transform.position += new Vector3(1, 0, 0);

            if(CheckIsValidPosition()) {

                FindObjectOfType<Grid>().UpdateGrid(this);

            }

            else {
                transform.position += new Vector3(-1, 0, 0);
            }

        }
        else if(Input.GetKeyDown(KeyCode.LeftArrow)) {

            transform.position += new Vector3(-1, 0, 0);

            if(CheckIsValidPosition()) {

                FindObjectOfType<Grid>().UpdateGrid(this);

            } 

            else {
                transform.position += new Vector3(1, 0, 0);
            }

        }
        else if (Input.GetKeyDown(KeyCode.UpArrow)) {

            if(allowRotation) {
                if(limitRotation) {
                    if(transform.rotation.eulerAngles.z >= 90) {
                        transform.Rotate(0, 0, -90);
                    }
                    else {
                        transform.Rotate(0, 0, 90);
                    }
                }
                else {
                    transform.Rotate(0, 0, 90);
                }

                if (CheckIsValidPosition()) {

                    FindObjectOfType<Grid>().UpdateGrid(this);

                }
                else{
                    if(limitRotation) {
                        if (transform.rotation.eulerAngles.z >= 90){
                                transform.Rotate(0, 0, -90);
                        }
                        else{
                            transform.Rotate(0, 0, -90);
                        }
                    }
                    else {
                        transform.Rotate(0, 0, -90);
                    }

                }
                
             }
        }
        else if(Input.GetKeyDown(KeyCode.DownArrow) || Time.time - fall >= fallSpeed) {

            transform.position += new Vector3(0, -1, 0);

            if(CheckIsValidPosition()) {

                FindObjectOfType<Grid>().UpdateGrid(this);

            }
            else {
                transform.position += new Vector3(0, 1, 0);

                enabled = false;

                FindObjectOfType<Grid>().SpawnNextElement();
            }

            fall = Time.time;

        }

    }

    bool CheckIsValidPosition() {

        foreach (Transform block in transform) {

            Vector2 pos = FindObjectOfType<Grid>().Round(block.position);

            if(FindObjectOfType<Grid>().CheckIsInsideGrid(pos) == false) {
                return false;
            }
            if(FindObjectOfType<Grid>().GetTransformAtGridPosition(pos) != null && FindObjectOfType<Grid>().GetTransformAtGridPosition(pos).parent != transform) {

                return false;
            }
        }

        return true;

    }

    void OnTriggerEnter(Collider other) {

        if (other.gameObject.tag == "Respawn"){
            dead = true;
            Destroy(this.gameObject);
        }

    }
}
