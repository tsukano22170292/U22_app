using UnityEngine;

public class audio_c : MonoBehaviour
{
    public AudioSource seSource;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void sePlay(string seName)
    {
        seSource.clip = Resources.Load<AudioClip>(seName);
        seSource.Play();
    }
}