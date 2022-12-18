using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Bird))]

public class BirdCollisionHandler : MonoBehaviour
{
    private Bird _bird;

    public UnityEvent EnteredScoreZone;
    public UnityEvent Hited;
    public UnityEvent ReachedGround;

    private void Start()
    {
        _bird = GetComponent<Bird>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (_bird.IsLife == true)
        {
            _bird.Die();

            Hited?.Invoke();
        }

        if (collision.gameObject.TryGetComponent(out Ground ground) == true)
        {
            ReachedGround?.Invoke();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_bird.IsLife == true && collision.TryGetComponent(out ScoreZone scoreZone) == true)
        {
            _bird.IncreaseScore();

            EnteredScoreZone?.Invoke();
        }
    }
}