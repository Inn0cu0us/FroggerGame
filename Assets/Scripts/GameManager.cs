using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    

    int Score;
    int LivesRemaining;
    int NumberOfPondsReached;
    public int PondPointValue = 100;
    public Text ScoreText;
    public Text LivesRemainingText;
	

	void Awake() 
    {
        Score = 0;
        LivesRemaining = 3;

        ScoreText.text = string.Format("SCORE: {0}", Score);
        LivesRemainingText.text = string.Format("x{0}", LivesRemaining);
	}
	

	void Update () 
    {
        
	}

    public void LoseLife()
    {
        LivesRemaining--;
        if (LivesRemaining < 0)
        {
            Debug.Log("Game Over");
            Time.timeScale = 0;
        }
        else
        {
            LivesRemainingText.text = string.Format("x{0}", LivesRemaining);
        }
    }

    public void PondReached()
    {
        Score += PondPointValue;
        ScoreText.text = string.Format("SCORE: {0}", Score);
        NumberOfPondsReached++;
        if (NumberOfPondsReached >= 5)
        {
            Debug.Log("You win!");
            Time.timeScale = 0;
        }
    }
}
