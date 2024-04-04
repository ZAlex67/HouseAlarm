using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AmbientSound : MonoBehaviour
{
    [SerializeField] private AudioSource _ambientSound;
    [SerializeField] private float _volumeCoefficient;

    private void Start()
    {
        _ambientSound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        float volumeValue = 1f;

        StartCoroutine(ChangeVolume(volumeValue));

        _ambientSound.Play();
    }

    private void OnTriggerExit(Collider other)
    {
        float volumeValue = 0f;

        StartCoroutine(ChangeVolume(volumeValue));

        _ambientSound.Play();
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