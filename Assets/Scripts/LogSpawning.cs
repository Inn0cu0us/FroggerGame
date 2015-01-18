using UnityEngine;
using System.Collections;

public class LogSpawning : MonoBehaviour {

    public float IntervalBetweenSpawns = 5f;
    public float MinSpeed = 2f;
    public float MaxSpeed = 5f;
    public Vector2 Direction = -Vector2.right;
    public GameObject prefab;

    float timer;
    // Use this for initialization
	void Start () {
        timer = IntervalBetweenSpawns;
	}
	
	// Update is called once per frame
	void Update () 
    {
        timer += Time.deltaTime;

        if (timer >= IntervalBetweenSpawns)
        {
            timer = 0.0f;
            GameObject newLog = (GameObject)Instantiate(prefab, transform.position, transform.rotation);
            var movement = newLog.GetComponent<DriftMovement>();
            if (movement != null)
            {
                movement.direction = Direction;
            }
        }
	}
}
