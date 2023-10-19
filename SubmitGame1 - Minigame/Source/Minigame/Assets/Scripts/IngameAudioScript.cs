using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngameAudioScript : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource audioSource;
    void Start()
    {
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
