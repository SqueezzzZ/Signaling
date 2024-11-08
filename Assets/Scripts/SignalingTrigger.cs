using UnityEngine;

public class SignalingTrigger : MonoBehaviour
{
    [SerializeField] private Signaling _signaling;

    private bool _isRogueEntered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (_isRogueEntered == true)
            return;

        if (other.GetComponent<Rogue>() == false)
            return;

        _isRogueEntered = true;
        _signaling.SetAlarmStatus(true);
    }

    private void OnTriggerExit(Collider other)
    {
        if (_isRogueEntered == false)
            return;

        if (other.GetComponent<Rogue>() == false)
            return;

        _isRogueEntered = false;
        _signaling.SetAlarmStatus(false);
    }
}