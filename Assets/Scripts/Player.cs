using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PlayerController))] // Needs the controller script
public class Player : MonoBehaviour
{

    public float moveSpeed = 5; // modifies movespeed but since it's public just use the inspector
    Camera viewCamera; // References the camera in this script
    PlayerController controller; // Used to reference the controller in this script

    
    // Use this for initialization
    void Awake() // For when the player is active
    {
        controller = GetComponent<PlayerController>(); // Get the controller
        viewCamera = Camera.main; // Gets the main camera
    }

    // Update is called once per frame
    void Update()
    {
        // Movement input
        Vector3 moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0.0f, Input.GetAxisRaw("Vertical")); // Gets wasd input to let the player move those directions respectively
        Vector3 moveVelocity = moveInput.normalized * moveSpeed; // Formula for setting speed
        controller.Move(moveVelocity); // Calls controller to get movement
        
        // Look input
        Ray ray = viewCamera.ScreenPointToRay(Input.mousePosition); // Get the mouses position from the view of the camera
        Plane groundPlane = new Plane(Vector3.up, Vector3.up); // Has no real function yet but will make the player view line up with the height of his weapon, just times the second vector 3 by whatever the objects height is
        float rayDistance; //  will makes sure the ray is within the cameras range
        if (groundPlane.Raycast(ray, out rayDistance))// Makes sure it's in the right boundries
        {
            Vector3 point = ray.GetPoint(rayDistance); // Get the ray distance from the point where the cursor is at
            //Debug.DrawLine(ray.origin,point,Color.red); //use this if you want to see the line from the camera to the cursor
            controller.LookAt(point); // Makes the controller look at the cursor point
        }
    }
}
