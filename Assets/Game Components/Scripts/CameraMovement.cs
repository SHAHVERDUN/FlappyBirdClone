using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Bird _bird;
    [SerializeField] float _offsetByX;

    private void Reset()
    {
        _offsetByX = 1.5f;
    }

    private void Update()
    {
        transform.position = new Vector3(_bird.transform.position.x + _offsetByX, transform.position.y, transform.position.z);
    }
}