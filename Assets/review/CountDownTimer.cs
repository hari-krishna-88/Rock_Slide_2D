using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CountDownTimer : MonoBehaviour
{
    public TextMeshProUGUI one;
    public TextMeshProUGUI two;
    public TextMeshProUGUI three;

    public TextMeshProUGUI Score;

    MovementController movementController;
    CoinCollector coinCollector;



    private void Start()
    {
        one.enabled = false;
        two.enabled = false;
        three.enabled = false;
        movementController = GetComponent<MovementController>();
        coinCollector = GetComponent<CoinCollector>();
        StartCoroutine(CountDown());
    }
    private void Update()
    {
        Score.text = coinCollector.Score.ToString();
    }

    IEnumerator CountDown()
    {
        movementController.enabled = false;
        yield return new WaitForSeconds(1);
        one.enabled=true;
        yield return new WaitForSeconds(1);
        one.enabled = false;
        two.enabled=true;
        yield return new WaitForSeconds (1);
        two.enabled=false;
        three.enabled=true;
        yield return new WaitForSeconds(1); 
        three.enabled=false;
        movementController.enabled = true;
    }
}
