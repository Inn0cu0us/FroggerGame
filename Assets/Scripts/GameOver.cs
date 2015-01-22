using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {

    Canvas GameOverCanvas;

	// Use this for initialization
	void Start () 
    {
        GameOverCanvas = GetComponent<Canvas>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            GameManager.RestartGame();
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                Application.Quit();
            }
        }
	}
}
