using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]

public class ScoreZone : MonoBehaviour
{
    private BoxCollider2D boxCollider2D;

    private void Awake()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    private void OnEnable()
    {
        boxCollider2D.enabled = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Bird bird))
        {
            boxCollider2D.enabled = false;
        }
    }
}