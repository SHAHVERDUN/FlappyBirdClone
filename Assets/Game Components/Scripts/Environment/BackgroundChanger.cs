using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RawImage))]

public class BackgroundChanger : MonoBehaviour
{
    [SerializeField] private List<Texture2D> _textures;

    private RawImage _rawImage;

    private void Start()
    {
        _rawImage = GetComponent<RawImage>();

        _rawImage.texture = _textures[Random.Range(0, _textures.Count)];
    }
}