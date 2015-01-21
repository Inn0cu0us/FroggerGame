using UnityEngine;
using System.Collections;

public class Spawning : MonoBehaviour {

    public float IntervalBetweenSpawns = 5f;
    public float MinSpeed = 0.5f;
    public float MaxSpeed = 1.5f;
    public Vector2 Direction = -Vector2.right;
    public GameObject prefab;

    float timer;
    float speed;
    // Use this for initialization
	void Start () 
    {
        IntervalBetweenSpawns *= (1 / GameManager.DifficultyMultiplier);
        timer = IntervalBetweenSpawns;
        speed = Random.Range(MinSpeed, MaxSpeed);
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
                movement.speed = speed * GameManager.DifficultyMultiplier;
            }
        }
	}
}
