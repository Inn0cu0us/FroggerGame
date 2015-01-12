using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    public AudioClip HopSound;
    AudioSource playerAudio;
    Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
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
      //  Move(h, v);
      //  Rotate(h, v);
	}

    void Move(Vector3 movement)
    {
        playerAudio.clip = HopSound;
        playerAudio.Play();
        anim.SetTrigger("Walk");
        transform.position = transform.position + movement;
    }

    void MoveUp()
    {
        transform.position = transform.position + Vector3.up;
    }

    void MoveRight()
    {
        transform.position = transform.position + Vector3.right;
    }

    void MoveLeft()
    {
        transform.position = transform.position - Vector3.right;
    }

    void MoveDown()
    {
        transform.position = transform.position - Vector3.up;
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
