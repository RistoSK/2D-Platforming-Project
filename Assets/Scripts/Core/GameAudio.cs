using UnityEngine;

public class GameAudio : MonoBehaviour
{
    private AudioSource _audioSource;
    private float _playbackTime;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();

        _audioSource.Play();
    }

    private void OnEnable()
    {
        if (_audioSource != null)
        {
            _audioSource.time = _playbackTime;
            _audioSource.Play();
        }
    }

    public void GamePaused()
    {
        _playbackTime = _audioSource.time;
    }
}
