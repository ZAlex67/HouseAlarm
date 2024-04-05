using UnityEngine;

public class House : MonoBehaviour
{
    private AmbientSound _ambientSound;

    private void Start()
    {
        _ambientSound = GetComponent<AmbientSound>();
    }

    private void OnTriggerEnter(Collider other)
    {
        _ambientSound.SoundOn();
    }

    private void OnTriggerExit(Collider other)
    {
        _ambientSound.SoundOff();
    }
}
