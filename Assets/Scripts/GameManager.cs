using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Image bar;
    private float maxTime = 10f;
    private float currentTime;
    public GameObject endMenuUI;
    public static bool gameOver = false;
    public Animator camAnim;
    public TMP_Text highscoreTxt;
    [SerializeField] Interstitial ad;


    void Start()
    {
        //Setup Variables
        currentTime = maxTime;
        highscoreTxt.text = PlayerPrefs.GetInt("highscore").ToString();
    }

    void Update()
    {
        //Timer Bar Code
        currentTime -= 1f * Time.deltaTime;
        bar.fillAmount = currentTime / maxTime;

        //When Time Runs Out
        if (currentTime <= 0)
        {
            highscoreTxt.text = PlayerPrefs.GetInt("highscore").ToString();
            EndGame();
            currentTime = maxTime;
            
        }

        //Reset Highscore
        if(Input.GetKeyDown(KeyCode.R)){
            PlayerPrefs.SetInt("highscore", 0);
        }
    }

    public void CamShake()
    {
        camAnim.SetTrigger("shake");
    }

    public void ResumeGame()
    {
        endMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameOver = false;
        BlueDot.score = 0;
    }

    void EndGame()
    {
        endMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameOver = true;
        ad.ShowAd();

    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }

    public void LoadShop()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Shop");
    }

    public void LoadGame()
    {
        Time.timeScale = 1f;
        gameOver = false;
        SceneManager.LoadScene("Main");
    }
}
