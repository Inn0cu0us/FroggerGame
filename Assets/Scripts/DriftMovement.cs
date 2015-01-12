using UnityEngine;
using System.Collections;

public class DriftMovement : MonoBehaviour {

    public float speed = 5f;
    public Vector3 direction = Vector3.right;

    Vector3 movement;
    void Awake()
    {

    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            movement = direction * speed * Time.deltaTime;
            other.transform.position += movement;
        }
    }

	void FixedUpdate () 
    {
        movement = direction * speed * Time.deltaTime;
        transform.position += movement;
	}
}