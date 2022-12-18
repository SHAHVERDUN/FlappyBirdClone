using UnityEngine;

[RequireComponent(typeof(BirdMovement))]
[RequireComponent(typeof(Animator))]

public class BirdAnimatorController : MonoBehaviour
{
    private BirdMovement _birdMovement;
    private Animator _animator;

    private const string BirdWingFlappingAnimation = nameof(BirdWingFlappingAnimation);

    private void Awake()
    {
        _birdMovement = GetComponent<BirdMovement>();
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _birdMovement.Flapped.AddListener(() =>
        {
            _animator.Play(BirdWingFlappingAnimation);
        });
    }

    private void OnDisable()
    {
        _birdMovement.Flapped.RemoveListener(() =>
        {
            _animator.Play(BirdWingFlappingAnimation);
        });
    }
}