using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootStepSe : MonoBehaviour
{
    public AudioClip footStep;
    private AudioSource audioSource;


    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.clip = footStep;
    }

    public void SeStep(){
        audioSource.Play();
    }
}
