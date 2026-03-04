using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    public string nextLevel;

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Player") {
            SceneManager.LoadScene(nextLevel);
        }   
    }
}
