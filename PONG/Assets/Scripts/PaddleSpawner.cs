using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleSpawner : MonoBehaviour
{
    public GameObject playerPaddle, enemyPaddle;
    Vector3 playerPaddlePos, enemyPaddlePos;
    float extremeTop, extremeBottom;
    GameObject playerPaddleClone, enemyPaddleClone;

    private void OnEnable()
    {
        UIManager.Paddle_Spawning += SpawnPaddle;
        BallController.destPaddle += DestroyPaddle;
    }
    private void OnDisable()
    {
        UIManager.Paddle_Spawning -= SpawnPaddle;
        BallController.destPaddle -= DestroyPaddle;
    }
    void SpawnPaddle()
    {
        extremeBottom = -Utilities.GetWorldHeight() / 2 + 0.9f;
        extremeTop = Utilities.GetWorldHeight() / 2 - 0.9f;

        playerPaddlePos = new Vector3(0, extremeBottom, 1);
        playerPaddleClone = Instantiate(playerPaddle, playerPaddlePos, Quaternion.identity) as GameObject;
        playerPaddleClone.name = "Player_Paddle";
        playerPaddleClone.transform.parent = transform;

        enemyPaddlePos = new Vector3(0, extremeTop, 1);
        enemyPaddleClone = Instantiate(enemyPaddle, enemyPaddlePos, Quaternion.identity) as GameObject;
        enemyPaddleClone.name = "Enemy_Paddle";
        enemyPaddleClone.transform.parent = transform;
    }
    void DestroyPaddle()
    {
        Destroy(playerPaddleClone);
        Destroy(enemyPaddleClone);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
