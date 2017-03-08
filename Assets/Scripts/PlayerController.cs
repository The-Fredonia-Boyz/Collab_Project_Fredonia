using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]// Any object with physics is going to need this, so I made it mandatory.
public class PlayerController : MonoBehaviour
{
    PlayerController controller;
    Vector3 velocity; // Gets velocity
    Rigidbody myRigidbody;

    // Use this for initialization
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody>(); // Used for Getting RigidBody as a variable
    }

    public void Move(Vector3 _velocity) // Gets movement for player
    {
        velocity = _velocity; // Gets the velocity declared at the top and lets it be used in the public method as _velocity
    }

    public void LookAt(Vector3 lookPoint) // Gets the mouses position and makes the player view it
    {
        // Makes it so player does not look down at ground when mouse is in close proximity to player
        Vector3 HeightCorrectedViewpoint = new Vector3(lookPoint.x, transform.position.y, lookPoint.z);
        // Returns point value with heigh correction
        transform.LookAt(HeightCorrectedViewpoint);
    }

    // Update is called once per frame
    void FixedUpdate() //Using fixedupdate instead of update since it uses a consistent time between calls, is better for update that adjust physics
    {
        myRigidbody.MovePosition(myRigidbody.position + velocity * Time.fixedDeltaTime); // Makes the player able to move
    }
}
