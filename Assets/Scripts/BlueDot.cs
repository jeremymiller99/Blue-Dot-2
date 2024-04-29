using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BlueDot : MonoBehaviour
{
    public Vector3 blueDot;
    public static int score;
    public TMP_Text scoreText;
    public ParticleSystem explosion;
    public GameManager gm;
    public SoundManager sm;

    void Start()
    {
        //Setup Variables
        score = 0;
        gm = GameObject.FindGameObjectWithTag("Manager").GetComponent<GameManager>();
        sm = GameObject.FindGameObjectWithTag("Sound Manager").GetComponent<SoundManager>();
    }

    void OnMouseDown()
    {
        if (!GameManager.gameOver)
        {
            //Explosion Particles
            Instantiate(explosion, transform.position, Quaternion.identity);

            //Play Explosion Particles
            if(!sm.gameMuted){
                GetComponent<AudioSource>().Play(); 
            }
            
            //Change Location of BlueDot
            blueDot[0] = Random.Range(-2f, 2f);
            blueDot[1] = Random.Range(-3f, 2.5f);
            this.transform.position = blueDot;

            //Update Score
            score++;
            scoreText.text = score.ToString();
            PlayerPrefs.SetInt("totalscore", PlayerPrefs.GetInt("totalscore") + 1);

            //Check for High Score
            if (score > PlayerPrefs.GetInt("highscore")){
                PlayerPrefs.SetInt("highscore", score);
            }

            //Camera Shake
            gm.CamShake();
        }  
    }
}
