using UnityEngine;

public class audio_c : MonoBehaviour
{
    public AudioSource seSource;
    public AudioSource cancelSource;
    public AudioSource recycleSource;
    public AudioSource shopSource;

    // Start is called before the first frame update
    public void sePlay()
    {
        seSource.clip = Resources.Load<AudioClip>("kettei");
        seSource.Play();
    }

    public void cancelPlay()
    {
        cancelSource.clip = Resources.Load<AudioClip>("cancel");
        cancelSource.Play();
    }

    public void recyclePlay()
    {
        recycleSource.clip = Resources.Load<AudioClip>("recycle");
        recycleSource.Play();
    }

    public void shopPlay()
    {
        shopSource.clip = Resources.Load<AudioClip>("shop");
        shopSource.Play();
    }
}