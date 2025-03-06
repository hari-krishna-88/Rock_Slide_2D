using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameController : MonoBehaviour
{
    Vector2 CheckPointPos;
    Rigidbody2D playerRb;

    CamaraController camaraController;
    public ParticleSystem partticleController;

    private void Awake()
    {
       camaraController = GameObject.FindGameObjectWithTag("VritualCamera").GetComponent<CamaraController>();
       playerRb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        CheckPointPos = transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle") || collision.CompareTag("UnderGround"))
        {
           Die();
        }
    }

    private void Die()
    {
        partticleController.Play();
        StartCoroutine(Respawn(1f));
    }

    public void UpdateCheckPoint(Vector2 pos)
    {
        CheckPointPos = pos;
    }


    IEnumerator Respawn(float duration)
    {
        playerRb.simulated = false;
        playerRb.velocity = new Vector2(0, 0);
        transform.localScale = new Vector3(0, 0, 0);
        yield return new WaitForSeconds(duration);
        transform.position = CheckPointPos;
        transform.localScale = new Vector3(1, 1, 1);
        playerRb.simulated = true;
    }
}
