using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreZone : MonoBehaviour
{
    private bool hasScored = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !hasScored)
        {
            hasScored = true;

            ScoreManager scoreManager = FindObjectOfType<ScoreManager>();

            if (scoreManager != null)
            {
                scoreManager.AddScore(1);
            }
        }
    }

    private void OnBecameInvisible()
    {
        hasScored = false;
        
    }
}
