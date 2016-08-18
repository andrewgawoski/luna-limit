using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

    Vector3 destination;
    float distanceFromObject;

	// Use this for initialization
	void Start () {
        destination = Vector3.zero;
        distanceFromObject = -10f;

        //Taken from update as only need to lock to board once. Board doesn't move.
        destination = GameObject.FindGameObjectWithTag("Board").transform.position;
        destination.z = destination.z + distanceFromObject;
        Camera.main.transform.position = destination;
    }
	
	// Update is called once per frame
	void Update () {
        
	}
}
