using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Collector : MonoBehaviour
{
    public int points = 0;
    public TextMeshProUGUI textUi;

    void Start()
    {
        SetScore();
    }

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Collectable")
        {
            points ++;
            GameObject.Destroy(other.gameObject);
            SetScore();
        }
    }

    private void SetScore()
    {
        textUi.text = "Points: " + points.ToString();
    }
}
