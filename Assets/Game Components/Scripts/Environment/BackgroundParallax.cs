using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RawImage))]

public class BackgroundParallax : MonoBehaviour
{
    [SerializeField] private BirdMovement _birdMovement;
    [SerializeField] private float _speedDivider;

    private RawImage _rawImage;
    private float _imageUVPositionByX;

    private void Start()
    {
        _rawImage = GetComponent<RawImage>();
    }

    private void Update()
    {
        SetImageUVPosition();
    }

    private void SetImageUVPosition()
    {
        _imageUVPositionByX += (_birdMovement.GetComponent<Rigidbody2D>().velocity.x / _speedDivider) * Time.deltaTime;

        if (_imageUVPositionByX >= 1)
        {
            _imageUVPositionByX = 0;
        }

        _rawImage.uvRect = new Rect(_imageUVPositionByX, Vector2.zero.y, _rawImage.uvRect.width, _rawImage.uvRect.height);
    }
}