using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    public GameObject ball;
    //public static int playerScore,enemyScore;

    private void OnEnable()
    {
        BallController.ballSpawner += CreateBall;
        UIManager.Ball_Spawning += CreateBall;
    }
    private void OnDisable()
    {
        BallController.ballSpawner -= CreateBall;
        UIManager.Ball_Spawning -= CreateBall;
    }


    void CreateBall()
    {
        GameObject ballClone = Instantiate(ball, transform.position, Quaternion.identity) as GameObject;
        ballClone.name = "Ball";
        ballClone.transform.parent = transform;
    }
}

    // Update is called once per frame
    
