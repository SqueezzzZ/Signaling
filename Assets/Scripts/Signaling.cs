using System.Collections;
using UnityEngine;

public class Signaling : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    [SerializeField] private float _minVolume = 0;
    [SerializeField] private float _maxVolume = 1f;
    [SerializeField] private float _volumeRate = 0.2f;

    [SerializeField]  private bool _isSignalingActive = false;

    private Coroutine _currentCorutine;

    private void Awake()
    {
        _audioSource.volume = _minVolume;
    }

    public void SetAlarmStatus(bool isAlarming)
    {
        if (_isSignalingActive == true)
        {
            StopCoroutine(_currentCorutine);
        }

        if(isAlarming == true)
        {
            if(_isSignalingActive == false)
            {
                _isSignalingActive = true;
                _audioSource.Play();
            }

            _currentCorutine = StartCoroutine(ChangeVolumeSmoothly(_maxVolume));
        }
        else if(isAlarming == false)
        {
            _currentCorutine = StartCoroutine(ChangeVolumeSmoothly(_minVolume));
        }
    }

    private IEnumerator ChangeVolumeSmoothly(float targetVolume)
    {
        while (_audioSource.volume != targetVolume)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, targetVolume, _volumeRate * Time.deltaTime);

            yield return null;
        }

        if (_audioSource.volume == _minVolume)
        { 
            _audioSource.Stop();
            _isSignalingActive = false;
        }
    }
}