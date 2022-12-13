using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class BirdMovement : MonoBehaviour
{
    [SerializeField] private Transform _startPoint;
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _gravityModifier;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _minRotationByZ;
    [SerializeField] private float _maxRotationByZ;

    private Rigidbody2D _rigidbody2D;
    private Quaternion _maxRotation;
    private Quaternion _minRotation;

    private void Reset()
    {
        _jumpForce = 10f;
        _gravityModifier = 0.1f;
        _rotationSpeed = 1f;
        _minRotationByZ = -60f;
        _maxRotationByZ = 60f;
    }

    private void Start()
    {
        transform.position = _startPoint.position;

        _rigidbody2D = GetComponent<Rigidbody2D>();

        _rigidbody2D.velocity = Vector2.zero;
        _minRotation = Quaternion.Euler(0, 0, _minRotationByZ);
        _maxRotation = Quaternion.Euler(0, 0, _maxRotationByZ);
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _rigidbody2D.velocity = new Vector2(_speed, Vector2.zero.y);
            _rigidbody2D.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
            transform.rotation = _maxRotation;
        }

        _rigidbody2D.AddForce(Vector2.down * _gravityModifier, ForceMode2D.Impulse);
        transform.rotation = Quaternion.Lerp(transform.rotation, _minRotation, _rotationSpeed * Time.deltaTime);
    }
}