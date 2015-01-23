using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider2D))]
public class KillOnContact : MonoBehaviour {

    PlayerDeath playerDeath;

	void Awake () 
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        playerDeath = player.GetComponent<PlayerDeath>();
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            playerDeath.Die();
        }
    }
}
