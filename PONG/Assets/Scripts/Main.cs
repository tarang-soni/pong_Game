using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{

    public AudioSource bgAudioSource;
    public AudioSource sfxAudioSource;

    public AudioClip bgSound;
    public AudioClip buttonSound;
    public AudioClip sfxGoal;

    public int playerScore, enemyScore;
    const float splashHoldTime = 5f;
    private static Main instance = null;
    public static Main Instance
    {
        get
        {
          return instance; 
        }
    }
    // Start is called before the first frame update
    private void Awake()
    {
        if (instance !=null && instance !=this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
    }
    void Start()
    {
        Main.Instance.playerScore = 0;
        Main.Instance.enemyScore = 0;
        Invoke("LoadScreen", splashHoldTime);

        
    }

   public void LoadScreen()
    {
        DontDestroyOnLoad(this.gameObject);
        SceneManager.LoadScene(1);
    }
    public void BGmusic()
    {
        if (Instance.bgAudioSource!=null)
        {
            Instance.bgAudioSource.volume = 0.4f;
            Instance.bgAudioSource.clip = Instance.bgSound;
            Instance.bgAudioSource.Play();
        }
    }
    public void UISound()
    {
        if (Instance.sfxAudioSource!= null)
        {
            Instance.sfxAudioSource.PlayOneShot(Main.Instance.buttonSound);
        }
    }
    public void GoalSound()
    {
        Instance.sfxAudioSource.PlayOneShot(Main.Instance.sfxGoal);
    }
}
