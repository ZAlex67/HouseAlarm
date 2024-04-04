using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private AudioSource _stepsAudioSource;
    [SerializeField] private float _stepDistance;

    private float _coveredDistance = 0f;

    void Update()
    {
        Rotate();
        Move();
    }

    private void Rotate()
    {
        float rotation = Input.GetAxis("Horizontal");
        transform.Rotate(_rotationSpeed * rotation * Time.deltaTime * Vector3.up);
    }

    private void Move()
    {
        float direction = Input.GetAxis("Vertical");

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
