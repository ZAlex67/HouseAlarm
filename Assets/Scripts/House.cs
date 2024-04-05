using UnityEngine;

public class House : MonoBehaviour
{
    private Alarm _alarm;

    private void Start()
    {
        _alarm = GetComponent<Alarm>();
    }

    private void OnTriggerEnter(Collider other)
    {
        _alarm.SoundOn();
    }

    private void OnTriggerExit(Collider other)
    {
        _alarm.SoundOff();
    }
}