using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class DriftMovement : MonoBehaviour {

    public float speed = 5f;
    public Vector3 direction = Vector3.right;

    Rigidbody body;

    Vector3 movement;
    void Awake()
    {
        body = GetComponent<Rigidbody>();
    }
	
	void FixedUpdate () 
    {
        movement = direction * speed * Time.deltaTime;
        body.MovePosition(body.position + movement);
	}
}