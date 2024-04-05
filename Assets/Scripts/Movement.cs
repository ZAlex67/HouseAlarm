using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private AudioSource _stepsAudioSource;
    [SerializeField] private float _stepDistance;

    private float _coveredDistance = 0f;
    private string _axisHorizonral = "Horizontal";
    private string _axisVertical = "Vertical";

    private void Update()
    {
        Rotate();
        Move();
    }

    private void Rotate()
    {
        float rotation = Input.GetAxis(_axisHorizonral);
        transform.Rotate(_rotationSpeed * rotation * Time.deltaTime * Vector3.up);
    }

    private void Move()
    {
        float direction = Input.GetAxis(_axisVertical);

        if (direction == 0f)
        {
            _coveredDistance = 0f;
            return;
        }

        float distance = _moveSpeed * direction * Time.deltaTime;
        _coveredDistance += Mathf.Abs(distance);
        transform.Translate(distance * Vector3.forward);

        if (_coveredDistance >= _stepDistance)
        {
            _coveredDistance -= _stepDistance;
            _stepsAudioSource.Play();
        }
    }
}
