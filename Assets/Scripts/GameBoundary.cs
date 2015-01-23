using UnityEngine;
using System.Collections;

public class GameBoundary : MonoBehaviour {

    void OnTriggerExit2D(Collider2D other)
    {
        string message = string.Format("Destroyed {0}", other.gameObject.name);
        Debug.Log(message);
        GameObject.Destroy(other.gameObject);
    }
}
