using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class House : MonoBehaviour
{
    private Alarm _alarm;
    private float volumeMax = 1f;
    private float volumeMin = 0f;

    private void Start()
    {
        _alarm = GetComponent<Alarm>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player>())
            _alarm.SoundController(volumeMax);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Player>())
            _alarm.SoundController(volumeMin);
    }
}