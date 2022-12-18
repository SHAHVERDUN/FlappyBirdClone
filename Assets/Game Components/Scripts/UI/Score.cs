using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private Bird _bird;
    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private TMP_Text _maxScoreText;

    private void OnEnable()
    {
        _bird.IncreasedScore += SetText;
    }

    private void OnDisable()
    {
        _bird.IncreasedScore -= SetText;
    }

    private void SetText(float score, float maxScore)
    {
        _scoreText.text = score.ToString();
        _maxScoreText.text = maxScore.ToString();
    }
}