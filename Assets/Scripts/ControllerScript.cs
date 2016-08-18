using UnityEngine;
using System.Collections;

public class ControllerScript : MonoBehaviour {

    /*int[] topEdge;
    int[] leftEdge;
    int[] rightEdge;
    int[] bottomEdge;
    int[,] boardArray;*/
    int boardSize = 7;

    public Sprite[] darkSprites; // { get; set; }
    public Sprite[] lightSprites; // { get; set; }
    public Sprite[] iconSprites;

    
    //See if this works
    GameObject[,] boardArray2;
    GameObject[] topArray;
    GameObject[] leftArray;
    GameObject[] rightArray;
    GameObject[] bottomArray;

    public Sprite getDark(int pos)
    {
        return darkSprites[pos];
    }

    public Sprite getLight(int pos)
    {
        return lightSprites[pos];
    }

    public Sprite getIcon(int pos)
    {
        return iconSprites[pos];
    }

    public int getTileValue(int x, int y)
    {
        return boardArray2[x, y].GetComponent<TileScript>().moonValue;
    }
    
    public bool getFlippedState(int x, int y)
    {
        return boardArray2[x, y].GetComponent<TileScript>().isFlipped;
    }

    public void setTileValue(int x, int y, int value)
    {
        boardArray2[x, y].GetComponent<TileScript>().moonValue = value;
    }

    public void setEdgeValue(string edge, int index, int value)
    {
        Debug.Log("Inside setEdgeValue");

        //Try to handle some improper string formatting
        edge = edge.ToLower();
        
        switch (edge)
        {
            case "top":
                if(topArray[index].GetComponent<EdgeScript>().wasModified == false)
                {
                    topArray[index].GetComponent<EdgeScript>().moonValue = value;
                    topArray[index].GetComponent<EdgeScript>().wasModified = true;
                } 
                break;

            case "left":
                if (leftArray[index].GetComponent<EdgeScript>().wasModified == false)
                {
                    leftArray[index].GetComponent<EdgeScript>().moonValue = value;
                    leftArray[index].GetComponent<EdgeScript>().wasModified = true;
                }
                break;

            case "right":
                if (rightArray[index].GetComponent<EdgeScript>().wasModified == false)
                {
                    rightArray[index].GetComponent<EdgeScript>().moonValue = value;
                    rightArray[index].GetComponent<EdgeScript>().wasModified = true;
                }
                break;

            case "bottom":
                if (bottomArray[index].GetComponent<EdgeScript>().wasModified == false)
                {
                    bottomArray[index].GetComponent<EdgeScript>().moonValue = value;
                    bottomArray[index].GetComponent<EdgeScript>().wasModified = true;
                }
                break;

            default:
                Debug.Log("Inside setEdgeValue DEFAULT CASE");
                break;
        }
    }

	// Use this for initialization
	void Start () {

        boardArray2 = new GameObject[boardSize, boardSize];
        topArray = new GameObject[boardSize];
        leftArray = new GameObject[boardSize];
        rightArray = new GameObject[boardSize];
        bottomArray = new GameObject[boardSize];
        //Default Initialization

        //New Initialization
        //y incrementor is "i", x incrementor is "j"
        for (int i = 0; i < boardSize; i++)
        {
            //Edge arrays are one dimensional and only maybe need proper initialization

            //GameObject myTopInstance = Instantiate(Resources.Load("Edge Tile")) as GameObject;

            topArray[i] = Instantiate(Resources.Load("Edge Tile")) as GameObject;
            topArray[i].transform.position = new Vector3((float)(-3.3 + (i * 1.1)), (float)(4.4), 0);

            bottomArray[i] = Instantiate(Resources.Load("Edge Tile")) as GameObject;
            bottomArray[i].transform.position = new Vector3((float)(-3.3 + (i * 1.1)), (float)(-4.4), 0);

            leftArray[i] = Instantiate(Resources.Load("Edge Tile")) as GameObject;
            leftArray[i].transform.position = new Vector3((float)(-4.4), (float)(3.3 - (i * 1.1)), 0);

            rightArray[i] = Instantiate(Resources.Load("Edge Tile")) as GameObject;
            rightArray[i].transform.position = new Vector3((float)(4.4), (float)(3.3 - (i * 1.1)), 0);

            //Doing row by row
            for (int j = 0; j < boardSize; j++)
            {
                //Put a tile object in appropriate spot in board array
                 

                GameObject myTileInstance = Instantiate(Resources.Load("Tile Object")) as GameObject;

                boardArray2[j, i] = myTileInstance;

                //Calculate our destination as vector
                //X is -330 + 110*j, Y is 330 - 100*i
                Vector3 tempVector = new Vector3((float)(-3.3+(1.1*j)), (float)(3.3-(1.1*i)), 0);
                
                boardArray2[j, i].transform.position = tempVector;
                boardArray2[j, i].GetComponent<TileScript>().setPosition(j, i);
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
