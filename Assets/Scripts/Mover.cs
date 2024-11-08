using UnityEngine;

public class Mover : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);
    private const string Vertical = nameof(Vertical);

    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _movementSpeed;

    private void Update()
    {
        Rotate();
        Move();
    }

    private void Move()
    {
        float direction = Input.GetAxis(Vertical);
        float distance = direction * _movementSpeed * Time.deltaTime;

        transform.Translate(distance * Vector3.forward);
    }

    private void Rotate()
    {
        float rotation = Input.GetAxis(Horizontal);

        transform.Rotate(rotation * _rotationSpeed * Time.deltaTime * Vector3.up);
    }
}