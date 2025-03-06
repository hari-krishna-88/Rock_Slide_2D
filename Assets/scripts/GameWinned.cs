using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameWinned : MonoBehaviour
{
    Rigidbody2D playerRb;
    MovementController movementController;
    [SerializeField] ParticleSystem winningParticlesystem;
    [SerializeField] GameObject WinningUi;

    private void Awake()
    {
        playerRb = GetComponent<Rigidbody2D>();
        movementController = gameObject.GetComponent<MovementController>();
        WinningUi.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("FinishingPoint"))
        {
            playerRb.velocity = Vector3.zero;
            playerRb.angularVelocity = 0;
            movementController.enabled = false;
            winningParticlesystem.Play();
            Invoke("DisplayUi", 2f);
        }
    }

    private void DisplayUi()
    {
        WinningUi.SetActive(true);
    }
}


