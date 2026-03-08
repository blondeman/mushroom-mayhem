using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class Goal : MonoBehaviour
{
    public string nextLevel;
    public int maxPoints;
    public Collector collector;
    public GameObject player;

    public GameObject points;
    public GameObject interact;
    public TextMeshProUGUI textUi;

    void Start()
    {
        interact.SetActive(false);
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Player") {
            FinishedLevel();
        }   
    }

    private void FinishedLevel()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        player.SetActive(false);
        points.SetActive(false);
        interact.SetActive(true);
        textUi. text = "Points: "+collector.points+"/"+maxPoints;
    }

    public void NextLevel()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        SceneManager.LoadScene(nextLevel);
    }
}
