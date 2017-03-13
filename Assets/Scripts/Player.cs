using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(PlayerController))] // Needs the controller script
public class Player : MonoBehaviour
{

    public float moveSpeed = 5; // modifies movespeed but since it's public just use the inspector
    public float jumpHeight = 5; // modifies jumpheight
    Camera viewCamera; // References the camera in this script
    PlayerController controller; // Used to reference the controller in this script
    checkforGround groundcheck; // Used to reference the checkforground script in this script
    
    void Awake() // For when the player is active
    {
        controller = GetComponent<PlayerController>(); // Get the controller
        groundcheck = GetComponent<checkforGround>(); // Get the groundchecker
        viewCamera = Camera.main; // Gets the main camera
    }

    // Update is called once per frame
    void Update()
    {
        // Movement input
        Vector3 moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0.0f, Input.GetAxisRaw("Vertical")); // Gets wasd input to let the player move those directions respectively
        Vector3 moveVelocity = moveInput.normalized * moveSpeed; // Formula for setting speed
        controller.Move(moveVelocity); // Calls controller to get movement

        // Jump input
        GetComponent<Rigidbody>().AddForce(moveInput * moveSpeed * Time.deltaTime); // Only using this Get call for jumping
        {
            if (Input.GetKeyDown("space") && groundcheck.IsGrounded)
            {
                Vector3 jump = new Vector3(0.0f, (100.0f * jumpHeight), 0.0f); // makes player jump by 100f value times jumpheight variable

                GetComponent<Rigidbody>().AddForce(jump); // Adds the jump force specified above
            }
        }
        if (transform.position.y <= -10.0f || Input.GetKeyDown(KeyCode.R)) // Resets the player if falls out of map or press r
        {
            SceneManager.LoadScene("Tsar"); // Code to reset map, tsar is the name of the scene
        }

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
