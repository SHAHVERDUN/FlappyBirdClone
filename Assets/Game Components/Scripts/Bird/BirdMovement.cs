using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Bird))]

public class BirdMovement : MonoBehaviour
{
    [SerializeField] private Transform _startPoint;
    [SerializeField] private Transform _upLimitPoint;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _gravityModifier;
    [SerializeField] private float _speed;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _minRotationByZ;
    [SerializeField] private float _maxRotationByZ;

    private Bird _bird;
    private Rigidbody2D _rigidbody2D;
    private Quaternion _maxRotation;
    private Quaternion _minRotation;

    public UnityEvent Flapped;

    private void Reset()
    {
        _jumpForce = 10f;
        _gravityModifier = 0.1f;
        _rotationSpeed = 1f;
        _minRotationByZ = -60f;
        _maxRotationByZ = 30f;
    }

    private void Awake()
    {
        _bird = GetComponent<Bird>();
    }

    private void OnEnable()
    {
        _bird.Lived += SetStartState;
    }

    private void OnDisable()
    {
        _bird.Lived -= SetStartState;
    }

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();

        transform.position = _startPoint.position;
        _rigidbody2D.velocity = Vector2.zero;
        _minRotation = Quaternion.Euler(0, 0, _minRotationByZ);
        _maxRotation = Quaternion.Euler(0, 0, _maxRotationByZ);
    }

    private void Update()
    {
        if (_bird.IsLife == true)
        {
            Move();
        }
    }

    private void Move()
    {
        _rigidbody2D.velocity = new Vector2(_speed, _rigidbody2D.velocity.y);

        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) && transform.position.y < _upLimitPoint.position.y)
        {
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, Vector2.zero.y);

            _rigidbody2D.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
            transform.rotation = _maxRotation;

            Flapped?.Invoke();
        }
        
        _rigidbody2D.AddForce(Vector2.down * _gravityModifier, ForceMode2D.Impulse);
        transform.rotation = Quaternion.Lerp(transform.rotation, _minRotation, _rotationSpeed * Time.deltaTime);
    }

    private void SetStartState(bool active)
    {
        if (active == true)
        {
            transform.position = _startPoint.position;
            _rigidbody2D.SetRotation(0f);
            _rigidbody2D.MoveRotation(0f);
            _rigidbody2D.rotation = 0f;
            _rigidbody2D.velocity = Vector2.zero;
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
}