using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementController : MonoBehaviour
{
    Rigidbody2D rb;

    [SerializeField] int speed;
    [Range(1, 10)]
    [SerializeField] float acceleration;
    float speedMutiplier;

    public Transform wallCheckPoint;
    bool isWallTouch;
    public LayerMask wallLayer;

    bool btnPressed;

    Vector2 relativeTransform;

    public bool isOnPlatform;
    public Rigidbody2D platFromRb;

    public ParticleController particleController;

    private AudioSource audioSource;
    

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        UpdateRelativeTransform();
    }

    private void FixedUpdate()
    {
        UpdateSpeedMutiplier();
        float targetSpeed = speed * speedMutiplier * relativeTransform.x;

        if (isOnPlatform)
        {
            rb.velocity = new Vector2(targetSpeed + platFromRb.velocity.x, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(targetSpeed, rb.velocity.y);
        }

        // Check for wall collision and trigger flip
        isWallTouch = Physics2D.OverlapBox(wallCheckPoint.position, new Vector2(0.06f, 0.55f), 0, wallLayer);

        if (isWallTouch)
        {
            Flip();
        }
    }

    public void Flip()
    {
        particleController.PlayeTouchParticle(wallCheckPoint.position);
        transform.Rotate(0, 180, 0);
        UpdateRelativeTransform();
    }

    void UpdateRelativeTransform()
    {
        relativeTransform = transform.InverseTransformVector(Vector2.one);
    }

    public void Move(InputAction.CallbackContext value)
    {
        if (value.started)
        {
            audioSource.Play();
            btnPressed = true;
        }
        else if (value.canceled)
        {
            audioSource.Stop();
            btnPressed = false;
        }
    }

    void UpdateSpeedMutiplier()
    {
        if (btnPressed && speedMutiplier < 1)
        {
            speedMutiplier += Time.deltaTime * acceleration;
        }
        else if (!btnPressed && speedMutiplier > 0)
        {
            speedMutiplier -= Time.deltaTime * acceleration;
            if (speedMutiplier < 0) speedMutiplier = 0;
        }
    }

    private void OnDrawGizmos()
    {
        // Visualize wall check in the editor
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(wallCheckPoint.position, new Vector2(0.06f, 0.55f));
    }
}
