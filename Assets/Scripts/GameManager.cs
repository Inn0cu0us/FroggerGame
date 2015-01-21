using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    

    static int Score = 0;
    static int LivesRemaining = 3;
    public static float DifficultyMultiplier = 1.0f;
    public static int ScoreMultiplier = 2;
    public static int PondPointValue = 100;


    public Canvas NextLevelCanvas;
    public Text ScoreText;
    public Text LivesRemainingText;
    PlayerMovement playerMovement;
    int NumberOfPondsReached;
    bool ReadyForNextLevel = false;
	void Awake() 
    {
        NumberOfPondsReached = 0;
        ScoreText.text = string.Format("SCORE\n{0}", Score);
        LivesRemainingText.text = string.Format("x{0}", LivesRemaining);

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        playerMovement = player.GetComponent<PlayerMovement>();
	}
	

	void Update () 
    {
        if (ReadyForNextLevel)
       {
           if (Input.anyKeyDown)
           {
               NextLevelCanvas.enabled = false;
               ReadyForNextLevel = false;
               StartCoroutine(RestartLevel());
           }
       }
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
        ScoreText.text = string.Format("SCORE\n{0}", Score);
        NumberOfPondsReached++;
        if (NumberOfPondsReached >= 5)
        {
            ReadyForNextLevel = true;
            playerMovement.enabled = false;
            Debug.Log("You win!");
            NextLevelCanvas.enabled = true;
        }
    }

    public IEnumerator RestartLevel()
    {
        yield return new WaitForEndOfFrame();
        playerMovement.enabled = true;
        DifficultyMultiplier += 0.1f;
        NumberOfPondsReached = 0;
        PondPointValue *= ScoreMultiplier;
        Application.LoadLevel(Application.loadedLevel);
        
    }
}