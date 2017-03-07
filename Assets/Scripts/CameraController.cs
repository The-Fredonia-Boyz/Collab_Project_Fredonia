using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    // Reference to the player
    public GameObject player;
    
    // Offset of the camera from the player
    private Vector3 offset;

	// Use this for initialization
	void Start () {
        // Figure out the offset
        offset = transform.position - player.transform.position;
	}
	
	// Update is called once per frame
	void Update () {

	}

    // Used LateUpdate because the dude told me to
    void LateUpdate()
    {
        // Camera is moved to a new position aligned with the player object each frame before displaying what it can see
        transform.position = player.transform.position + offset;
    }


}
