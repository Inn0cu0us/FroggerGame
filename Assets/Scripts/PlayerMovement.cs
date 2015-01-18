using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    public AudioClip HopSound;
    AudioSource playerAudio;
    Animator anim;
    int FloorMask;
    PlayerDeath playerDeath;

    FroggerMovement Up = new FroggerMovement() { direction = Vector3.up, rotation = new Vector3(0, 0, 0) };
    FroggerMovement Down = new FroggerMovement() { direction = -Vector3.up, rotation = new Vector3(0, 0, 180) };
    FroggerMovement Left = new FroggerMovement() { direction = -Vector3.right, rotation = new Vector3(0, 0, 90) };
    FroggerMovement Right = new FroggerMovement() { direction = Vector3.right, rotation = new Vector3(0, 0, 270) };

    void Awake()
    {
        anim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        FloorMask = LayerMask.GetMask("Floor");
        playerDeath = GetComponent<PlayerDeath>();
    }
    
	void Update () 
    {
        {
            if (Input.GetButtonDown("Up"))
            {
                Move(Up);
            }
            else
            {
                if (Input.GetButtonDown("Down"))
                {
                    Move(Down);
                }
                else
                {
                    if (Input.GetButtonDown("Right"))
                    {
                        Move(Right);
                    }
                    else
                    {
                        if (Input.GetButtonDown("Left"))
                        {
                            Move(Left);
                        }
                    }
                }
            }
        }
        
	}

    void FixedUpdate()
    {
        if (!IsSomewhereSafe())
        {
            playerDeath.Die();
        }
    }

    void Move(FroggerMovement movement)
    {
        playerAudio.clip = HopSound;
        playerAudio.Play();
        anim.SetTrigger("Walk");
        transform.position = transform.position + movement.direction;
        transform.eulerAngles = movement.rotation;                
    }

    bool IsSomewhereSafe()
    {
        var hit = Physics2D.Raycast(transform.position, Vector3.forward, 0.5f, FloorMask);
        return (hit.collider != null);
    }

    private class FroggerMovement
    {
        public Vector3 direction;
        public Vector3 rotation;
    }


}
