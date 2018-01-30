using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {

    public float moveSpeed;
    private float halfScreenSize;
    public event System.Action gameOver;
    
    // Use this for initialization
    void Start()
    {
        halfScreenSize = Camera.main.aspect * Camera.main.orthographicSize;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(transform.position.x) > halfScreenSize)
        {
            transform.position = new Vector3(-transform.position.x, transform.position.y, transform.position.z);
        }
        transform.Translate(Vector2.right * Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime);
       
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "FallingBlock")
        {
          
            Destroy(gameObject);
            gameOver();
        }
    }
}

