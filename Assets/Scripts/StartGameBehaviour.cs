using UnityEngine;
using System.Collections;

public class StartGameBehaviour : MonoBehaviour {

    AudioSource StartMenuAudio;

    bool gameStarted = false;
    bool gameAlreadyStarting = false;
	// Use this for initialization
    void Start()
    {
        StartMenuAudio = GetComponent<AudioSource>();
    }
	
	
	// Update is called once per frame
	void Update () {
	    if  (Input.GetKeyDown(KeyCode.Return))
        {
            gameStarted = true;
        }
        if (gameStarted && !gameAlreadyStarting )
        {
            gameAlreadyStarting = true;
            StartMenuAudio.Play();
            StartCoroutine(WaitThenLoadLevel("level1", 1.0f));
        }
	}

    IEnumerator WaitThenLoadLevel(string levelname, float delaySeconds)
    {
        yield return new WaitForSeconds(delaySeconds);
        Application.LoadLevel(levelname);
    }
}