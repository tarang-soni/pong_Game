using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Controller : MonoBehaviour
{
    
     Transform ball;
     Rigidbody2D ballRB;

    public float speed;
    float extremeLeft, extremeRight;

    // Start is called before the first frame update
    void Start()
    {
        extremeLeft = -Utilities.GetWorldWidth() / 2 * 0.73f;
        extremeRight = Utilities.GetWorldWidth() / 2 * 0.73f;
        InvokeRepeating("MoveEnemy", 0.02f, 0.02f);
    }

    // Update is called once per frame
    
    private void MoveEnemy()
    {
        
        if (ball == null)
        {
            ball = GameObject.FindWithTag("Ball").transform;
            
        }
        ballRB = ball.GetComponent<Rigidbody2D>();

        if (ballRB.velocity.y>0)
        {
            if (ball.position.x < transform.position.x - 0.03f)
            {
                
                transform.Translate(Vector2.left * speed * Time.deltaTime);
            }
            else if (ball.position.x > transform.position.x + 0.03f)
            {
               
                transform.Translate(Vector2.right * speed * Time.deltaTime);
            }
        }
        if (transform.position.x > extremeRight)
        {
            transform.position = new Vector3(extremeRight, transform.position.y, 0);

        }
        if (transform.position.x < extremeLeft)
        {
            transform.position = new Vector3(extremeLeft, transform.position.y, 0);
        }

    }
}
