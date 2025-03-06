using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour
{
    [Header("Movement Particle")]
    [SerializeField] ParticleSystem movementParticle;

    [Range(0, 10)]
    [SerializeField] int occurAfterVelocity;

    [Range(0, 0.2f)]
    [SerializeField] float dustFormationPeriod;

    [SerializeField] Rigidbody2D plyaerRb;

    float counter;

    bool isOnGround;

    [Header("Other Particles")]
    [SerializeField] ParticleSystem fallParticle;
    [SerializeField] ParticleSystem touchParticle;

    private float touchParticleCooldown = 0.2f;
    private float lastTouchParticleTime = 0;

    public void Start()
    {
        // Ensure the touch particle is not parented to any GameObject
        touchParticle.transform.parent = null;
    }

    private void Update()
    {
        counter += Time.deltaTime;

        if (isOnGround && Mathf.Abs(plyaerRb.velocity.x) > occurAfterVelocity)
        {
            if (counter > dustFormationPeriod)
            {
                movementParticle.Play();
                counter = 0;
            }
        }
    }

    public void PlayeTouchParticle(Vector2 pos)
    {
        if (Time.time - lastTouchParticleTime >= touchParticleCooldown)
        {
            // Unparent the particle temporarily and set its position
            touchParticle.transform.SetParent(null);
            touchParticle.transform.position = pos;
            touchParticle.Play();

            lastTouchParticleTime = Time.time;

            // Re-parent the particle back under "Particles"
            touchParticle.transform.SetParent(transform.Find("Particles"));
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            fallParticle.Play();
            isOnGround = true;
            Debug.Log("groundeeddddd");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            isOnGround = false;
            Debug.Log("not grounded brohh");
        }
    }
}
