using UnityEngine;
using System.Collections;

public class VictoryPondBehaviour : MonoBehaviour {

    public GameObject RespawnLocation;
    public GameObject FroggerClone;

    public AudioClip VictoryPondSound;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.transform.position = RespawnLocation.transform.position;
            gameObject.SetActive(false);
            GameObject.Instantiate(FroggerClone, transform.position, Quaternion.identity);
            other.audio.clip = VictoryPondSound;
            other.audio.Play();
        }
    }
}
