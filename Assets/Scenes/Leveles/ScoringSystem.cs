using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ScoringSystem : MonoBehaviour
{
    public TextMeshProUGUI score;
    public GameObject player;
    NewBehaviourScript scoringsys;
    void Start()
    {
        scoringsys = player.GetComponent<NewBehaviourScript>();
    }

    // Update is called once per frame
    void Update()
    {
        score.text = scoringsys.scoreCount.ToString();
    }
    
}
