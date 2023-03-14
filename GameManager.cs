using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static Action             OnAddScore  = delegate { };
    public static Action             OnGameOver  = delegate { };
    public static Action        OnHighScore = delegate {  };
    public static Action<GameObject> OnAddObject  = delegate { };

    public List<GameObject> PipesSpwanList = new List<GameObject>();
    public Player           player;
    public ChangeBackGround changeBackGround;
    public XPManager        xpManager;
    public SentenceManager  m_sentenceManager;
    public int              score;
    public Text             onSocreText;
    public Text             ScoreText;
    public Text             highScore;
    public GameObject       scoreBorad;
    public GameObject       GameOver;
    public GameObject       playButtum;
    public GameObject       playButtumF;
    public GameObject       resetScore;

    public void Awake()
    {
        Application.targetFrameRate =  100;
        OnAddScore                  += addScore;
        OnGameOver                  += gameOver;
        OnAddObject                  += AddSpawnObject;
        OnHighScore                 += AddHeighScore;
        
        scoreBorad.SetActive(false);
        GameOver.SetActive(false);
        playButtumF.SetActive(true);
        resetScore.SetActive(false);
        onSocreText.enabled       = false;
        ScoreText.enabled         = false;
        highScore.enabled         = false;
        xpManager.enabled         = false;
        m_sentenceManager.enabled = false;
        // pause();
        
        player.enabled = false;
        Time.timeScale = 0f;
        
    }

    public void play()
    {
        score                            = 0;
        onSocreText.text = ScoreText.text = score.ToString();
        scoreBorad.SetActive(false);
        GameOver.SetActive(false);
        playButtumF.SetActive(false);
        resetScore.SetActive(false);
        onSocreText.enabled = true;
        ScoreText.enabled   = false;
        highScore.enabled   = false;
        xpManager.enabled   = true;
        
        player.enabled           = true;
        changeBackGround.enabled = true;
        Time.timeScale           = 1f;

        for (int i = 0; i < PipesSpwanList.Count; i++)
        {
            Destroy(PipesSpwanList[i]);
        }
    }

    public void pause()
    {

        scoreBorad.SetActive(true);
        GameOver.SetActive(true);
        playButtum.SetActive(true);
        resetScore.SetActive(true);
        onSocreText.enabled      = false;
        ScoreText.enabled        = true;
        highScore.enabled        = true;
        
        player.enabled            = false;
        changeBackGround.enabled  = false;
        xpManager.enabled         = false;
        m_sentenceManager.enabled = true;
        Time.timeScale            = 0f;
        
        highScore.text = PlayerPrefs.GetInt("HeighScore", 0).ToString();
        scoreBorad.SetActive(true);
    }

    public void quitGame()
    {
        Application.Quit();
    }
    
    public void addScore()
    {
        score++;
        onSocreText.text = ScoreText.text = score.ToString();
    }

    public void AddHeighScore()
    {
        if (score > PlayerPrefs.GetInt("HeighScore",0))
        {
            PlayerPrefs.SetInt("HeighScore", score);
        }
    }

    public void ResetHeighScore()
    {
        PlayerPrefs.DeleteAll();
        highScore.text = PlayerPrefs.GetInt("HeighScore", 0).ToString();
    }

    public void gameOver()
    {
        pause();
        playButtum.SetActive(true);
    }

    public void AddSpawnObject(GameObject Object_Spawn)
    {
        PipesSpwanList.Add(Object_Spawn);
        if (PipesSpwanList.Count > 10)
        {
            PipesSpwanList.RemoveAt(0);
        }
    }
    
    public void OnDestroy()
    {
        OnAddScore  -= addScore;
        OnGameOver  -= gameOver;
        OnAddObject  -= AddSpawnObject;
        OnHighScore -= AddHeighScore;
    }
}