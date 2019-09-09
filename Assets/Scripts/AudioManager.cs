using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioClip _levelThemeAudio;

    private AudioSource _audioSource;

    private void Start()
    {
       _audioSource = GetComponent<AudioSource>();
        //_audioSource.PlayOneShot(_levelThemeAudio);
        _audioSource.Play();
    }
    private void Update()
    {
        
    }
}
