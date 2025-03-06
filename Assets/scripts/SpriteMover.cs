using UnityEngine;

public class SpriteMover : MonoBehaviour
{
    public Transform pointA; // The starting point
    public Transform pointB; // The destination point
    public float speed = 2f; // Speed of movement

    private bool movingToB = true; // Flag to track direction

    void Update()
    {
        if (pointA == null || pointB == null)
        {
            Debug.LogWarning("Please assign both pointA and pointB in the inspector.");
            return;
        }

        // Determine the target point based on the direction
        Transform target = movingToB ? pointB : pointA;

        // Move the sprite towards the target point
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        // Check if the sprite has reached the target point
        if (Vector3.Distance(transform.position, target.position) < 0.01f)
        {
            movingToB = !movingToB; // Switch direction
        }
    }
}
