using UnityEngine;

public class Screen : MonoBehaviour
{
    [SerializeField] private Bird _bird;
    [SerializeField] private CanvasGroup _canvasGroup;

    private void OnEnable()
    {
        _bird.Lived += ShowScreen;
    }

    private void OnDisable()
    {
        _bird.Lived -= ShowScreen;
    }

    private void ShowScreen(bool active)
    {
        if (active == true)
        {
            _canvasGroup.interactable = false;
            _canvasGroup.alpha = 0f;
        }
        else
        {
            _canvasGroup.interactable = true;
            _canvasGroup.alpha = 1f;
        }
    }
}