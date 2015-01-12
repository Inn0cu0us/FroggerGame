using UnityEngine;
using System.Collections;

public class KillOnContact : MonoBehaviour {

    PlayerDeath playerDeath;

	void Awake () 
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        playerDeath = player.GetComponent<PlayerDeath>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            playerDeath.Die();
        }
    }
}
