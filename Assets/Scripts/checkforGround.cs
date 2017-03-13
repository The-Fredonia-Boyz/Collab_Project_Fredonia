using UnityEngine;
using System.Collections;

public class checkforGround : MonoBehaviour {

    public float groundDistance;

    public bool IsGrounded;

    public LayerMask layer; //probably won't actually have use but can be used for things in the future

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        UpdateValues();
	}

    public void UpdateValues()
    {
        if(IsGrounded)
        {
            groundDistance = 0.35f;
        }
        else
        {
            groundDistance = .15f;
        }


        if (Physics.Raycast(transform.position - new Vector3(0, 0.35f, 0), -transform.up, groundDistance, layer))
        {
            IsGrounded = true;
        }
        else
        {
            IsGrounded = false;
        }
        
    }
}
