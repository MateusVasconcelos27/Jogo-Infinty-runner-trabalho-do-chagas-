using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    
    public float speed = 5f;
    private bool hasScored = false;
    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;

        if (transform.position.x < -10f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D (Collider2D other)
    {
        if (other.CompareTag("Player") && !hasScored)
        {
            GameObject.FindObjectOfType<ScoreManager>().AddScore(1);
            hasScored = true;
        }
    }
}
