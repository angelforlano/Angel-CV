using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public GameObject explotion;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
            GameObject explotionObj = Instantiate(explotion, transform.position, Quaternion.identity);
            
            Destroy(gameObject);
            Destroy(explotionObj, 2);
            Destroy(other.gameObject);
        }

        if (other.CompareTag("Player"))
        {
            GameObject explotionObj = Instantiate(explotion, transform.position, Quaternion.identity);
            
            Destroy(gameObject);
            Destroy(explotionObj, 2);
            Destroy(other.gameObject);

            AsteroidGameController.Instance.GameOver();
        }
    }
}
