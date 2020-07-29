using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    public float speed = 4;
    public float rotationSpeed = 4;
    public float  fireRate = 0.5f;
    public List<GameObject> bullets = new List<GameObject>();
    
    private Rigidbody2D rb;
    private float lastShot;
        
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float h = Input.GetAxis("Vertical");
        transform.Rotate(new Vector3(0,0, Input.GetAxis("Horizontal") * rotationSpeed));
        rb.AddForce(transform.up  * h * speed, ForceMode2D.Impulse);

        if(Input.GetKey(KeyCode.Return) && Time.time > fireRate + lastShot)
        {
            Fire();
        }
    }

    void Fire()
    {
        GameObject tempBullet = Instantiate(bullets[Random.Range(0, bullets.Count)], transform.position, transform.rotation);
        lastShot = Time.time;
        AsteroidGameController.Instance.AddToGameObjets(tempBullet);
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
        AsteroidGameController.Instance.GameOver();
    }
}