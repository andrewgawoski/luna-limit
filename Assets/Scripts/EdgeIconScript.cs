using UnityEngine;
using System.Collections;

public class EdgeIconScript : MonoBehaviour {

    Sprite ourIcon;
    GameObject controllerReference;
    public int parentMoonValue;

    //Honestly, if I have to optimize this- go back and just make edge tiles tile objects with an extra "edge" boolean field

    Sprite getFreshIcon()
    {
        parentMoonValue = GetComponentInParent<EdgeScript>().moonValue;

        //Moon value from -7 to 0 to 7
        if (GetComponentInParent<EdgeScript>().moonValue >= 0)

        {
            //Handles values from 0-7
            return controllerReference.GetComponent<ControllerScript>().getIcon(parentMoonValue);
        }
        else
        {
            //Handling values from -7 to -1 for icons 7-13
            return controllerReference.GetComponent<ControllerScript>().getIcon(parentMoonValue + 14);
        }
    }


    // Use this for initialization
    void Start()
    {
        controllerReference = GameObject.FindGameObjectWithTag("GameController");
    }

    // Update is called once per frame
    void Update()
    {
        ourIcon = getFreshIcon();
        //If our icon should be different
        if (ourIcon != GetComponent<SpriteRenderer>().sprite)
        {
            GetComponent<SpriteRenderer>().sprite = ourIcon;
        }
    }
}
