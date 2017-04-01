using UnityEngine;
using System.Collections;

public class Ladder : MonoBehaviour {

    public float climbSpeed = 20f;

	// When object enters trigger
	void OnTriggerEnter (Collider other)
    {
        Debug.Log ("Player Entered the trigger");
	}
	
	// When object is staying in the trigger
	void OnTriggerStay (Collider other)
    {
        Debug.Log ("Player is in the trigger");	
        if (Input.GetKey("w"))
        {
            Vector3 climb = new Vector3(0.0f, (1.0f * climbSpeed), 0.0f);
            other.GetComponent<Rigidbody>().AddForce(climb);
        }
	}

    // When object leaves trigger
    void OnTriggerExit (Collider other)
    {
        Debug.Log ("Object Exited the trigger");
    }
}
