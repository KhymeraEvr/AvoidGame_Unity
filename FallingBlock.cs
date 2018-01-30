using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingBlock : MonoBehaviour {

    public float moveSpeed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector2.down * moveSpeed * Time.deltaTime);
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "KillPlane")
        {
            Destroy(gameObject);
        }
    }
}
