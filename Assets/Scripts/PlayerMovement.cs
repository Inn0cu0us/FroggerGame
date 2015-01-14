using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    public AudioClip HopSound;
    AudioSource playerAudio;
    Animator anim;
    int FloorMask;
    PlayerDeath playerDeath;
    
    void Awake()
    {
        anim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        FloorMask = LayerMask.GetMask("Floor");
        playerDeath = GetComponent<PlayerDeath>();
    }
    
	void Update () 
    {
        KeyCode selectedKeycode = GetSelectedKeyCode();

        switch (selectedKeycode)
        {
            case KeyCode.W: transform.eulerAngles = new Vector3(0, 0, 0); Move(Vector3.up); break;
            case KeyCode.S: transform.eulerAngles = new Vector3(0, 0, 180); Move(-Vector3.up); break;
            case KeyCode.A: transform.eulerAngles = new Vector3(0, 0, 90); Move(-Vector3.right); break;
            case KeyCode.D: transform.eulerAngles = new Vector3(0, 0, 270); Move(Vector3.right); break;
            default:  break;
        }
	}

    void Move(Vector3 movement)
    {
        playerAudio.clip = HopSound;
        playerAudio.Play();
        anim.SetTrigger("Walk");
        transform.position = transform.position + movement;
        if (!LandedSomewhereSafe())
        {
            playerDeath.Die();
        }        
    }

    bool LandedSomewhereSafe()
    {
        var hit = Physics2D.Raycast(transform.position, Vector3.forward, 0.5f, FloorMask);
        return (hit.collider != null);
    }

    void Rotate(float h, float v)
    {
        if (h > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 270);
        }
        if (h < 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 90);
        }
        if (v > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        if (v < 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 180);
        }
    }

    KeyCode GetSelectedKeyCode()
    {
        if (Input.GetKeyDown(KeyCode.None))
        {
            return KeyCode.None;
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                return KeyCode.W;
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.S))
                {
                    return KeyCode.S;
                }
                else
                {
                    if (Input.GetKeyDown(KeyCode.D))
                    {
                        return KeyCode.D;
                    }
                    else
                    {
                        if (Input.GetKeyDown(KeyCode.A))
                        {
                            return KeyCode.A;
                        }
                        else
                        {
                            return KeyCode.None;
                        }

                    }
                }
            }
        }
    }

}
