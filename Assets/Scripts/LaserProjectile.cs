using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserProjectile : MonoBehaviour
{
    [SerializeField] float laserSpeed = 15f;
    bool isEnemyLaser = false;
    Rigidbody2D rb;

    public bool IsEnemyLaser
    {
        get { return isEnemyLaser; }
        set { isEnemyLaser = value; }
    }

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isEnemyLaser)
        {
            rb.position -= new Vector2(0, laserSpeed * Time.deltaTime);
        }
        else
        {
            //player laser shoots up
            rb.position += new Vector2(0, laserSpeed * Time.deltaTime);
        }

        //destroy the laser when it goes off screen
        if (transform.position.y > Camera.main.ViewportToWorldPoint(new Vector2(0, 1)).y ||
            transform.position.y < Camera.main.ViewportToWorldPoint(new Vector2(0, 0)).y)
        {
            Destroy(rb.gameObject);
        }
    }
}
