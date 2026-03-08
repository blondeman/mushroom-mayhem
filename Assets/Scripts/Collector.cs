using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Collector : MonoBehaviour
{
    public int points = 0;
    public TextMeshProUGUI textUi;
    
    public AudioClip[] PickupAudioClips;

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

            AudioSource.PlayClipAtPoint(PickupAudioClips[Random.Range(0, PickupAudioClips.Length-1)], transform.position, 1);
        } else if(other.tag == "CollectablePoison")
        {
            points ++;
            GameObject.Destroy(other.gameObject);
            SetScore();

            AudioSource.PlayClipAtPoint(PickupAudioClips[Random.Range(0, PickupAudioClips.Length-1)], transform.position, 1);

            FindFirstObjectByType<MusicPlayer>().targetPitch = 0.5f;
            StartCoroutine(ReEnableAfterWait());
        }
    }

    private void SetScore()
    {
        textUi.text = "Points: " + points.ToString();
    }

    private IEnumerator ReEnableAfterWait()
    {
        yield return new WaitForSeconds(5f);
        FindFirstObjectByType<MusicPlayer>().targetPitch = 1f;
    }
}
