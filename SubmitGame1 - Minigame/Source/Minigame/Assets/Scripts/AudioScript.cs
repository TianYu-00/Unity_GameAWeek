using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScript : MonoBehaviour
{
    public AudioSource audioSource;

    private float audioVolume = 1f;
    // Start is called before the first frame update
    void Start()
    {
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        audioSource.volume = audioVolume;
    }

    public void setVolume(float volume)
    {
        audioVolume = volume;
    }

}
