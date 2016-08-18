using UnityEngine;
using System.Collections;

public class TileScript : MonoBehaviour {

    //Top left is 0,0
    public int xBoardPosition;
    public int yBoardPosition;

    public int spritePosition;

    public int moonValue;

    Sprite ourSprite;
    Sprite ourIcon;

    //Can we flip this tile or not?
    public bool isFlipped;

    GameObject controllerReference;

    //Default constructor
    public TileScript()
    {
        xBoardPosition = 0;
        yBoardPosition = 0;
    }

    public void setPosition(int x, int y)
    {
        xBoardPosition = x;
        yBoardPosition = y;
    }
       

    Sprite getFreshSprite()
    {
        spritePosition = (7 * yBoardPosition + xBoardPosition);

        if (isFlipped)
        {
            return controllerReference.GetComponent<ControllerScript>().getDark(spritePosition);
        }
        else
        {
            return controllerReference.GetComponent<ControllerScript>().getLight(spritePosition);
        }
    }

    void updateOthers()
    {
        //current position in array is [xBoardPosition, yBoardPosition]

        //Left Neighbor
        if(xBoardPosition == 0)
        {
            //We need to fill in the outer edge
            controllerReference.GetComponent<ControllerScript>().setEdgeValue("left", yBoardPosition, moonValue);
        }
        else
        {
            if(controllerReference.GetComponent<ControllerScript>().getFlippedState(xBoardPosition - 1 ,yBoardPosition) == false)
            {
                //If it isn't flipped

                //Update the value
                int tempValue = controllerReference.GetComponent<ControllerScript>().getTileValue(xBoardPosition - 1, yBoardPosition) + moonValue;
                if (tempValue > 7)
                {
                    tempValue = tempValue - 14;
                }
                else if (tempValue < -7)
                {
                    tempValue = tempValue + 14;
                }
                controllerReference.GetComponent<ControllerScript>().setTileValue(xBoardPosition - 1, yBoardPosition, tempValue);
                //Update the flipped state
            }
        }

        //Top Neighbor
        if(yBoardPosition == 0)
        {
            //We need to fill in the outer edge
            controllerReference.GetComponent<ControllerScript>().setEdgeValue("top", xBoardPosition, moonValue);
        }
        else
        {
            if (controllerReference.GetComponent<ControllerScript>().getFlippedState(xBoardPosition, yBoardPosition - 1) == false)
            {
                //If it isn't flipped

                //Update the value
                int tempValue = controllerReference.GetComponent<ControllerScript>().getTileValue(xBoardPosition, yBoardPosition - 1) + moonValue;
                if(tempValue > 7)
                {
                    tempValue = tempValue - 14;
                }else if(tempValue < -7)
                {
                    tempValue = tempValue + 14;
                }
                controllerReference.GetComponent<ControllerScript>().setTileValue(xBoardPosition, yBoardPosition - 1, tempValue);
                //Update the flipped state
            }
        }

        //Right Neighbor
        if(xBoardPosition == 6)
        {
            //We need to fill in the outer edge
            controllerReference.GetComponent<ControllerScript>().setEdgeValue("right", yBoardPosition, moonValue);
        }
        else
        {
            if (controllerReference.GetComponent<ControllerScript>().getFlippedState(xBoardPosition + 1, yBoardPosition) == false)
            {
                //If it isn't flipped

                //Update the value
                int tempValue = controllerReference.GetComponent<ControllerScript>().getTileValue(xBoardPosition + 1, yBoardPosition) + moonValue;
                if (tempValue > 7)
                {
                    tempValue = tempValue - 14;
                }
                else if (tempValue < -7)
                {
                    tempValue = tempValue + 14;
                }
                controllerReference.GetComponent<ControllerScript>().setTileValue(xBoardPosition + 1, yBoardPosition, tempValue);
                //Update the flipped state
            }
        }

        //Bottom Neighbor
        if(yBoardPosition == 6)
        {
            //We need to fill in the outer edge
            controllerReference.GetComponent<ControllerScript>().setEdgeValue("bottom", xBoardPosition, moonValue);
        }
        else
        {
            if (controllerReference.GetComponent<ControllerScript>().getFlippedState(xBoardPosition, yBoardPosition + 1) == false)
            {
                //If it isn't flipped

                //Update the value
                int tempValue = controllerReference.GetComponent<ControllerScript>().getTileValue(xBoardPosition, yBoardPosition + 1) + moonValue;
                if (tempValue > 7)
                {
                    tempValue = tempValue - 14;
                }
                else if (tempValue < -7)
                {
                    tempValue = tempValue + 14;
                }
                controllerReference.GetComponent<ControllerScript>().setTileValue(xBoardPosition, yBoardPosition + 1, tempValue);
                //Update the flipped state
            }
        }
    }

	// Use this for initialization
	void Start ()
    {
        isFlipped = false;

        spritePosition = (7 * yBoardPosition + xBoardPosition);

        moonValue = Random.Range(-7, 7);
        //moonValue = 0;

        controllerReference = GameObject.FindGameObjectWithTag("GameController");
        Sprite ourSprite = controllerReference.GetComponent<ControllerScript>().getDark(1);
            //ControllerScript.darkSprites[spritePosition];
        GetComponentInChildren<SpriteRenderer>().sprite = ourSprite;
	}
	
	// Update is called once per frame
	void Update ()
    {
        //If we have a mouse click, not necessarily on a collider
        if(Input.GetMouseButtonDown(0))
        {
            
             //Send ray out to mouse position
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //do we have a hit?
            RaycastHit2D hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity);
            //If there's a hit and its this object!
            if(hit.collider != null && hit.collider.transform == this.transform)
            {
                //If it hasn't been flipped, flip it and do the things!
                if(!isFlipped)
                {
                    //Set self to flipped
                    isFlipped = true;
                    //Do ALL the things!
                    updateOthers();
                }
                //Otherwise do nothing
            }          
        }//END MOUSE INPUT

        ourSprite = getFreshSprite();
        //If the sprites are different

        if (GetComponentInChildren<SpriteRenderer>().sprite != ourSprite)
        {
            GetComponentInChildren<SpriteRenderer>().sprite = ourSprite;
        }

    }

}
