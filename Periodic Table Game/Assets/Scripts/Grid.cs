using UnityEngine;
using System.Collections;

public class Grid : MonoBehaviour {

    public static int gridWidth = 10;
    public static int gridHeight = 20;

    public static Transform[,] grid = new Transform[gridWidth, gridHeight];

	// Use this for initialization
	void Start () {

        SpawnNextElement();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void UpdateGrid(Block block) {

        for(int y = 0; y < gridHeight; ++y) {

            for(int x = 0; x < gridWidth; ++x) {

                if(grid[x,y] != null) {
                    
                    if(grid[x,y].parent == block.transform) {
                        grid[x, y] = null;
                    }
                }
            }
        }

        foreach(Transform element in block.transform) {

            Vector2 pos = Round(element.position);

            if(pos.y < gridHeight) {

                if(pos.y < gridHeight) {

                    grid[(int)pos.x, (int)pos.y] = element;
                }
            }

        }
    }

    public Transform GetTransformAtGridPosition(Vector2 pos) {

        if(pos.y > gridHeight - 1) {
            return null;
        }
        else {

            return grid[(int)pos.x, (int)pos.y];
        }
    }

    public void SpawnNextElement() {

        GameObject nextElement = (GameObject)Instantiate(Resources.Load(GetRandomElement(), typeof(GameObject)), new Vector2(5.0f,20.0f), Quaternion.identity);

    }

    public bool CheckIsInsideGrid(Vector3 pos) {

        return ((int)pos.x >= 0 && (int)pos.x < gridWidth && (int)pos.y >= 0);

    }

    public Vector2 Round(Vector2 pos) {

        return new Vector2(Mathf.Round(pos.x), Mathf.Round(pos.y));
    }

    string GetRandomElement() {

        int randomElement = Random.Range(1, 5);

        string randomElementName = "T Shape";

        switch (randomElement) {

            case 1:
                randomElementName = "L Shape";
                break;
            case 2:
                randomElementName = "O Shape";
                break;
            case 3:
                randomElementName = "Z Shape";
                break;
            case 4:
                randomElementName = "J Shape";
                break;
            case 5:
                randomElementName = "T Shape";
                break;
        }

        return randomElementName;
    }
}
