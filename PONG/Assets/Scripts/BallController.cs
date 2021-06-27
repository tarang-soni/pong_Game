using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BallController : MonoBehaviour
{
    public delegate void BallSpawn();
    public static  event BallSpawn ballSpawner;

    public delegate void PlayerPoints();
    public static event PlayerPoints playerPoints;

    public delegate void EnemyPoints();
    public static event EnemyPoints enemyPoints;

    public delegate void Paddle();
    public static event Paddle destPaddle;

    public delegate void PlayerWin();
    public static event PlayerWin player_win;  
    
    public delegate void EnemyWin();
    public static event PlayerWin enemy_win;


    Rigidbody2D rb;
    public float speed;
    
    

    Vector2 dir;
    // Start is called before the first frame update
    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
        float randNum = Random.Range(1, 4);
        switch (randNum)
        {
            case 1: dir = new Vector2(1f, 1f)*speed;
                break;
            case 2: dir = new Vector2(1f, -1f) * speed;
                break;
            case 3: dir = new Vector2(-1f, -1f) * speed;
                break;
            case 4: dir = new Vector2(-1f, 1f) * speed;
                break;
            default:
                break;
        }
        rb.velocity = dir;
    }

    // Update is called once per frame
  
    float LaunchAngle(Vector2 ballPos,Vector2 paddlePos,float paddleheight)
    {
        return ((ballPos.y - paddlePos.y) / paddleheight);
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy_Left")
        {
            float y = LaunchAngle(transform.position, other.transform.position, other.collider.bounds.size.y);
            Vector2 angle = new Vector2(-1, y).normalized;
            rb.velocity = (angle * speed);
        }
        if (other.gameObject.tag == "Enemy_Right")
        {
            float y = LaunchAngle(transform.position, other.transform.position, other.collider.bounds.size.y);
            Vector2 angle = new Vector2(1, y).normalized;
            rb.velocity = (angle * speed);
        }
        if (other.gameObject.tag == "Player_Left")
        {
            float y = LaunchAngle(transform.position, other.transform.position, other.collider.bounds.size.y);
            Vector2 angle = new Vector2(-1, y).normalized;
            rb.velocity = (angle * speed);
        }
        if (other.gameObject.tag == "Player_Right")
        {
            float y = LaunchAngle(transform.position, other.transform.position, other.collider.bounds.size.y);
            Vector2 angle = new Vector2(1, y).normalized;
            rb.velocity = (angle * speed);
        }
        
        
        speed += 0.4f;

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "TopWall")
        {
            playerPoints();
            if (Main.Instance.playerScore<10)
            {
                ballSpawner();
                Destroy(this.gameObject);
            }
            else
            {

                destPaddle();
                player_win();
            }
      
        }
        if (collision.tag == "BottomWall")
        {
            enemyPoints();
            if (Main.Instance.enemyScore < 10)
            {
                ballSpawner();
                Destroy(this.gameObject);
            }
            else
            {

                destPaddle();
                enemy_win();
            }

        }
    }

    
    /*private void Launch()
    {
        float x = Random.Range(0, 2) == 0 ? -1 : 1;
        float y = Random.Range(0, 2) == 0 ? -1 : 1;
        rb.velocity = new Vector2(1*speed, -1*speed);
    }*/
}
