using UnityEngine;
using System.Collections;

public class NextLevelOverlayBehaviour : MonoBehaviour {

    Canvas NextLevelOverlay;

	// Use this for initialization
	void Start () 
    {
	    NextLevelOverlay = GetComponent<Canvas>();
	}
	
	// Update is called once per frame
	void Update () 
    {
	    if (Input.anyKeyDown)
        {
            NextLevelOverlay.enabled = false;
        }
	}
}
