using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{

    public Transform playerTransform;   // Stores the location of the player; What the enemy is going to move towards
    // PlayerHealth playerHealth
    // EnemyHealth enemyHealth
    private Transform enemyTransform;       // Stores the location of the enemy; used to calculate enemyPlayerDistance
    private NavMeshAgent nav;               // Nav mesh agent of the enemy; used to set the destination of the enemy
    private Renderer enemyRender;    // The renderer of the enemy; Used to change the color of the enemy when the player gets too close
    public float speed = 6;             // The speed of the enemy
    public float acceleration = 10;      // The acceleration of the enemy
    public float activationDistance = 8; // The distance that the player needs to be for them to be attacked by the enemy
    private float enemyPlayerDistance;  // The distance between the player and the enemy; if enemyPlayerDistance is less than activationDistance, the enemy will attack

    void Awake()
    {
        // playerHealth = player.GetComponent <PlayerHealth> ();
        // enemyHealth = GetComponent <EnemyHealth> ();

        // Get the enemies transform, so we know their location
        enemyTransform = GetComponent<Transform>();
        enemyRender = GetComponent<Renderer>();
        nav = GetComponent<NavMeshAgent>();

        // Pulls a reference to the NavMeshAgent component we have in the editor
        nav = GetComponent<NavMeshAgent>();
        nav.speed = speed;
        nav.acceleration = acceleration;
    }

    // Update is called once per frame
    void Update()
    {
        enemyPlayerDistance = Vector3.Distance(playerTransform.position, enemyTransform.position);
        // If the enemy and the player have health left...
        //if (enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0)
        //{
        //    // Set the destination of the nav mesh agent to the player

        // If the player is within the activation distance...
        if (enemyPlayerDistance <= activationDistance)
        {
            // Set the enemies color to red to indicate "anger"...
            enemyRender.material.color = Color.red;
            // And set the destination of the enemy to the player
            nav.SetDestination(playerTransform.position);
        }

        // If the player is not within the activation distance...
        else
        {
            // Enemy should be white to indicate passive...
            enemyRender.material.color = Color.white;

            // And the enemy should not move. I put this here because if it weren't here, even if the player wasn't within the activation distance, the enemy could still be
            // moving towards the last destination that was set when the player WAS within activation distance. This means that the enemy was still moving even if the player
            // was no longer within activation distance
            nav.SetDestination(enemyTransform.position);
        }
    }

    // This method still needs work
    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name + " detected.");
        Destroy(other);
        if (other.gameObject.tag == "Player")
            Debug.Log("Worked!");
    }
}