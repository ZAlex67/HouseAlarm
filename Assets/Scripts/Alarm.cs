using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Alarm : MonoBehaviour
{
    [SerializeField] private AudioSource _alarm;
    [SerializeField] private float _volumeCoefficient;

    private Coroutine _coroutine;

    private void Start()
    {
        _alarm = GetComponent<AudioSource>();
    }

    public void SoundOn()
    {
        float volumeValue = 1f;

        StopCoroutine();

        StartCoroutine(volumeValue);

        _alarm.Play();
    }

    public void SoundOff()
    {
        float volumeValue = 0f;

        StopCoroutine();

        StartCoroutine(volumeValue);
    }

    private void StopCoroutine()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);
    }

    private void StartCoroutine(float volumeValue)
    {
        _coroutine = StartCoroutine(ChangeVolume(volumeValue));
    }

    private IEnumerator ChangeVolume(float volumeValue)
    {
        float volumeStop = 0f;

        while (_alarm.volume != volumeValue)
        {
            _alarm.volume = Mathf.MoveTowards(_alarm.volume, volumeValue, _volumeCoefficient * Time.deltaTime);
            yield return null;
        }

        if (_alarm.volume == volumeStop)
        {
            _alarm.Stop();
        }
    }
}