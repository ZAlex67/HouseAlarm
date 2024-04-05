using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AmbientSound : MonoBehaviour
{
    [SerializeField] private AudioSource _ambientSound;
    [SerializeField] private float _volumeCoefficient;

    private Coroutine _coroutine;

    private void Start()
    {
        _ambientSound = GetComponent<AudioSource>();
    }

    public void SoundOn()
    {
        float volumeValue = 1f;

        Stop();

        Restart(volumeValue);

        _ambientSound.Play();
    }

    public void SoundOff()
    {
        float volumeValue = 0f;

        Stop();

        Restart(volumeValue);

        if (_ambientSound.volume == volumeValue)
            _ambientSound.Stop();
    }

    private void Stop()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);
    }

    private void Restart(float volumeValue)
    {
        _coroutine = StartCoroutine(ChangeVolume(volumeValue));
    }

    private IEnumerator ChangeVolume(float volumeValue)
    {
        while (_ambientSound.volume != volumeValue)
        {
            _ambientSound.volume = Mathf.MoveTowards(_ambientSound.volume, volumeValue, _volumeCoefficient * Time.deltaTime);
            yield return null;
        }
    }
}