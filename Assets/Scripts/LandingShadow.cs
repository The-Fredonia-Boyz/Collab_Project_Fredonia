using UnityEngine;
using System.Collections;

public class LandingShadow : MonoBehaviour {

    public float groundHeight;
	
	void Update ()
    {
        RaycastHit hit;
        Ray groundLevel = new Ray(transform.position, Vector3.down);

        if(Physics.Raycast(groundLevel, out hit, groundHeight))
        {
            transform.position = new Vector3(0, groundHeight, 0);
        }
	}
}
