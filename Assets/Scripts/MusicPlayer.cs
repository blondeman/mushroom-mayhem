using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    private static MusicPlayer instance;
    
    public AudioSource source;
    public float targetPitch = 1;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        source.pitch = Mathf.Lerp(source.pitch, targetPitch, Time.deltaTime);
    }
}