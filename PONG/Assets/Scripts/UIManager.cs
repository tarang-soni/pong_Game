using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public RectTransform scorePanel, mainMenuPanel,gameOverPanel;
    public GameObject MainGame;

    public TextMeshProUGUI playerScore, enemyScore;
    public TextMeshProUGUI playerFinalScore, enemyFinalScore;

    public delegate void PaddleSpawning();
    public static event PaddleSpawning Paddle_Spawning;

    public delegate void BallSpawning();
    public static event BallSpawning Ball_Spawning;

    private void OnEnable()
    {
        BallController.playerPoints +=PlayerHasScored;
        BallController.enemyPoints += EnemyHasScored;
        BallController.player_win += GameOverPlayerWin;
        BallController.enemy_win += GameOverEnemyWin;
    }
    private void OnDisable()
    {
        BallController.playerPoints -= PlayerHasScored;
        BallController.enemyPoints -= EnemyHasScored;
        BallController.player_win -= GameOverPlayerWin;
        BallController.enemy_win -= GameOverEnemyWin;
    }
    void Start()
    {
    
        scorePanel.gameObject.SetActive(false);
        mainMenuPanel.gameObject.SetActive(true);
        gameOverPanel.gameObject.SetActive(false);
        MainGame.SetActive(false);
       Main.Instance.BGmusic();
       
    }
    public void GameScreen()
    {
        Main.Instance.UISound();
        scorePanel.gameObject.SetActive(true);
        mainMenuPanel.gameObject.SetActive(false);
        gameOverPanel.gameObject.SetActive(false);
        MainGame.SetActive(true);
        Paddle_Spawning();
        Ball_Spawning();
    }
    void GameOverPlayerWin()
    {
        scorePanel.gameObject.SetActive(false);
        mainMenuPanel.gameObject.SetActive(false);
        gameOverPanel.gameObject.SetActive(true);
        MainGame.SetActive(false);
        playerFinalScore.text = Main.Instance.playerScore.ToString();
        enemyFinalScore.text = Main.Instance.enemyScore.ToString();
        //add who wins text
        
    }void GameOverEnemyWin()
    {
        scorePanel.gameObject.SetActive(false);
        mainMenuPanel.gameObject.SetActive(false);
        gameOverPanel.gameObject.SetActive(true);
        MainGame.SetActive(false);
        playerFinalScore.text = Main.Instance.playerScore.ToString();
        enemyFinalScore.text = Main.Instance.enemyScore.ToString();
        //add who wins text
        
    }
    public void MainMenu()
    {
        Main.Instance.UISound();
        scorePanel.gameObject.SetActive(false);
        mainMenuPanel.gameObject.SetActive(true);
        gameOverPanel.gameObject.SetActive(false);
        MainGame.SetActive(false);
        Main.Instance.playerScore = 0;
        playerScore.text = Main.Instance.playerScore.ToString();

        Main.Instance.enemyScore = 0;
        enemyScore.text = Main.Instance.enemyScore.ToString();
    }
    public void Quit()
    {
        Application.Quit();
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    void PlayerHasScored()
    {
    
         Main.Instance.playerScore++;
         playerScore.text = Main.Instance.playerScore.ToString();
         Main.Instance.GoalSound();
    }

    void EnemyHasScored()
    {
        
          Main.Instance.enemyScore++;
          enemyScore.text = Main.Instance.enemyScore.ToString();
          Main.Instance.GoalSound();
        
    }
    void ResetBtn()
    {
        mainMenuPanel.transform.gameObject.SetActive(false);
        MainGame.transform.gameObject.SetActive(true);
        gameOverPanel.transform.gameObject.SetActive(false);
        Main.Instance.playerScore = 0;
        playerScore.text = Main.Instance.playerScore.ToString();
        Main.Instance.enemyScore = 0;
        enemyScore.text = Main.Instance.enemyScore.ToString();
        Paddle_Spawning();
        Ball_Spawning();

    }
    
}
