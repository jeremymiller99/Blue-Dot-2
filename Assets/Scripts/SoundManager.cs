using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private Image SoundOffIcon;
    [SerializeField] private Image SoundOnIcon;
    public bool gameMuted = false;
    void Start(){
        //Check if Game Should be Muted
        if (PlayerPrefs.GetInt("muted") == 1){
            gameMuted = true;
            SoundOffIcon.enabled = true;
            SoundOnIcon.enabled = false; 
        } else if(PlayerPrefs.GetInt("muted") == 0){
            gameMuted = false;
            SoundOffIcon.enabled = false;
            SoundOnIcon.enabled = true;
        }
    }
    //Function for Sound Button
    public void ToggleGameSound(){
        if (!gameMuted){
            gameMuted = true;
            SoundOffIcon.enabled = true;
            SoundOnIcon.enabled = false;
            PlayerPrefs.SetInt("muted", 1);
        } else {
            gameMuted = false;
            SoundOffIcon.enabled = false;
            SoundOnIcon.enabled = true;
            PlayerPrefs.SetInt("muted", 0);
        }
    }
}
