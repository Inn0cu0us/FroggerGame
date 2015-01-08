using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    public float speed = 5f;
    Vector3 movement;
    Animator anim;
    Rigidbody playerBody;

    void Awake()
    {
        anim = GetComponent<Animator>();
        playerBody = GetComponent<Rigidbody>();
    }
    
	void FixedUpdate () 
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Move(h, v);
        Rotate(h, v);
	}

    void Move(float h, float v)
    {
        movement.Set(h, v, 0f);
        movement = movement * speed * Time.deltaTime;
        bool isWalking = !(movement == Vector3.zero);
        anim.SetBool("IsWalking", isWalking);
        
        playerBody.MovePosition(transform.position + movement);
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
}
