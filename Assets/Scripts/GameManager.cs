using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    

    static int Score = 0;
    static int LivesRemaining = 2;
    public static float DifficultyMultiplier = 1.0f;
    public static int ScoreMultiplier = 2;
    public static int PondPointValue = 100;
    public static int Level = 1;


    public Canvas NextLevelCanvas;
    public Canvas GameOverCanvas;
    public Text ScoreText;
    public Text LivesRemainingText;
    public Text LevelText;
    PlayerMovement playerMovement;
    int NumberOfPondsReached;
    bool ReadyForNextLevel = false;
	
    void Awake() 
    {
        NumberOfPondsReached = 0;
        
        ScoreText.text = string.Format("SCORE\n{0}", Score);
        LivesRemainingText.text = string.Format("x{0}", LivesRemaining);
        LevelText.text = string.Format("LEVEL\n{0}", Level);

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
               StartCoroutine(AdvanceLevel());
           }
       }
	}

    public void LoseLife()
    {
        LivesRemaining--;
        if (LivesRemaining < 0)
        {
            playerMovement.enabled = false;
            GameOverCanvas.enabled = true;
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
            NextLevelCanvas.enabled = true;
        }
    }

    public IEnumerator AdvanceLevel()
    {
        yield return new WaitForEndOfFrame();
        LevelText.text = string.Format("LEVEL\n{0}", Level++);
        playerMovement.enabled = true;
        DifficultyMultiplier += 0.1f;
        NumberOfPondsReached = 0;
        PondPointValue *= ScoreMultiplier;
        Application.LoadLevel(Application.loadedLevel);        
    }

    public static void RestartGame()
    {
        Score = 0;
        LivesRemaining = 2;
        DifficultyMultiplier = 1.0f;
        ScoreMultiplier = 2;
        PondPointValue = 100;
        Level = 1;
        Time.timeScale = 1.0f;
        Application.LoadLevel(Application.loadedLevel); 
    }
}