using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private bool ballLaunched = false;  
    public int points = 100; 
    public AudioSource source;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>(); 
        source = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (!ballLaunched && Input.GetKeyDown(KeyCode.Space)) 
        {
            GoBall();
            ballLaunched = true;
        }

        if (Input.GetKeyDown(KeyCode.R)) 
        {
            ResetBall();
        }
    }

    void GoBall()
    {
        float rand = Random.Range(0, 2);
        Vector2 force = (rand < 1) ? new Vector2(3, 5) : new Vector2(-3, 5);
        rb2d.velocity = force;  
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.collider.CompareTag("Player"))
        {
            Vector2 vel = rb2d.velocity;

            
            vel *= 1.04f; 

            
            if (Mathf.Abs(vel.y) < 1.3f)
                vel.y = vel.y > 0 ? 1.3f : -1.3f;

            
            if (Mathf.Abs(vel.x) > Mathf.Abs(vel.y) * 1.5f)
                vel.x = vel.x > 0 ? vel.y * 1.2f : -vel.y * 1.2f;

            
            vel.y += Random.Range(-0.5f, 0.5f);

            rb2d.velocity = vel;
        }

        if (coll.gameObject.CompareTag("Brick"))
        {
            Destroy(coll.gameObject);
            GameManager.PlayerScore1 += points; 
            GameManager.instance.AddScore(points); 
            source.Play();

        }
        source.Play();
    }

    void ResetBall()
    {
        rb2d.velocity = Vector2.zero;
        transform.position = new Vector2(0, -1);
        ballLaunched = false; 
    }

    void RestartGame()
    {
        ResetBall();
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            GoBall();
        }
    }
}
