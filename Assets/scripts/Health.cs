using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public Image fillimg;
    private float fillLevel = 1f;
    private bool inObstacle = false;

    private void Update()
    {
        fillimg.fillAmount = fillLevel;
        if(inObstacle)
        {
            fillLevel -= 0.003f;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            inObstacle = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            inObstacle = false;
        }
    }
}
