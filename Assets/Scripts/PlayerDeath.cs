using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class PlayerDeath : MonoBehaviour {

    public AudioSource playerAudio;
    public AudioClip deathSound;
    public GameObject RespawnLocation;
    
    GameObject player;
    PlayerMovement playerMovement;

    bool isDead = false;
	
    // Use this for initialization
	void Awake () 
    {
        playerAudio = GetComponent<AudioSource>();
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (isDead)
        {
            Respawn();
        }
	}

    public void Die()
    {
        playerAudio.clip = deathSound;
        playerAudio.Play();
        isDead = true;
        
    }

    private void Respawn()
    {
        isDead = false;
        player.transform.position = RespawnLocation.transform.position;
    }
}
