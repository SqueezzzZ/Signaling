using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Signaling : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    [SerializeField] private float _minVolume = 0;
    [SerializeField] private float _maxVolume = 1f;
    [SerializeField] private float _volumeRate = 0.2f;

    private bool _isRogueEntered = false;
    private bool _isSignalingActive = false;

    private void Awake()
    {
        _audioSource.volume = _minVolume;
    }

    private void Update()
    {
        UpdateSignaling();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_isRogueEntered == true)
            return;

        if (other.GetComponent<Rogue>() == false)
            return;

        _isRogueEntered = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (_isRogueEntered == false)
            return;

        if (other.GetComponent<Rogue>() == false)
            return;

        _isRogueEntered = false;
    }

    private void UpdateSignaling()
    {
        if (_isRogueEntered == true && _audioSource.volume < _maxVolume)
        {
            IncreaseVolume();

            if(_isSignalingActive == false)
            {
                _isSignalingActive = true;
                _audioSource.Play();
            }
        }
        else if(_isRogueEntered == false && _isSignalingActive == true)
        {
            ReduceVolume();

            if(_audioSource.volume <= _minVolume)
            {
                _isSignalingActive = false;
                _audioSource.Pause();
            }
        }
    }

    private void ReduceVolume()
    {
        _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, _minVolume, _volumeRate * Time.deltaTime);
    }

    private void IncreaseVolume()
    {
        _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, _maxVolume, _volumeRate * Time.deltaTime);
    }
}