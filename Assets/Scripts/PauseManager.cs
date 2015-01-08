using UnityEngine;
using System.Collections;

public class PauseManager : MonoBehaviour {

    bool isPaused = false;
    AudioSource PauseAudio;
    Canvas PauseCanvas;
    public AudioClip PauseClip;

    Animator anim;
	// Use this for initialization
	void Start () {
        PauseAudio = GetComponent<AudioSource>();
        PauseCanvas = GetComponent<Canvas>();
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetKeyDown(KeyCode.Return))
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
