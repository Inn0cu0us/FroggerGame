using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class PlayerDeath : MonoBehaviour {

    public AudioSource playerAudio;
    public AudioClip deathSound;
    public GameObject RespawnLocation;
    
    GameObject player;
    GameManager manager;

    bool isDead = false;
	
    // Use this for initialization
	void Awake () 
    {
        playerAudio = GetComponent<AudioSource>();
        player = GameObject.FindGameObjectWithTag("Player");
        GameObject controller = GameObject.FindGameObjectWithTag("GameController");
        manager = controller.GetComponent<GameManager>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (isDead)
        {
            Debug.Log("Frogger Died");
            manager.LoseLife();
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
