using UnityEngine;
using UnityEngine.Events;

public class Bird : MonoBehaviour
{
    public float Score { get; private set; }
    public float MaxScore { get; private set; }
    public bool IsLife { get; private set; }

    public event UnityAction<float, float> IncreasedScore;
    public event UnityAction<bool> Lived;

    private void Start()
    {
        IsLife = false;
        Score = 0;
        MaxScore = 0;

        IncreasedScore?.Invoke(Score, MaxScore);
    }

    public void IncreaseScore()
    {
        Score++;

        if (MaxScore < Score)
        {
            MaxScore = Score;
        }

        IncreasedScore?.Invoke(Score, MaxScore);
    }

    public void Die()
    {
        Score = 0;
        IsLife = false;
        Lived?.Invoke(IsLife);
    }

    public void Reborn()
    {
        if (IsLife == false)
        {
            IsLife = true;
            IncreasedScore?.Invoke(Score, MaxScore);
            Lived?.Invoke(IsLife);
        }
    }
}