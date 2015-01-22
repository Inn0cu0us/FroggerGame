using UnityEngine;
using System.Collections;

public class PauseManager : MonoBehaviour {

    bool isPaused = false;
    AudioSource PauseAudio;
    Canvas PauseCanvas;
    public AudioClip PauseClip;

	// Use this for initialization
	void Start () {
        PauseAudio = GetComponent<AudioSource>();
        PauseCanvas = GetComponent<Canvas>();
	}
	
	// Update is called once per frame
	void Update () {
	    if (isPaused && Input.GetKeyDown(KeyCode.Q))
        {
            Application.Quit();
        }
        
        if (Input.GetButtonDown("Submit"))
        {            
            PauseAudio.clip = PauseClip;
            PauseAudio.Play();
            isPaused = !isPaused;
            PauseCanvas.enabled = isPaused;
            int timeScale = isPaused ? 0 : 1;
            Time.timeScale = timeScale;
        }
	}
}
