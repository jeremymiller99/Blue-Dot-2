using UnityEngine;
using TMPro;

public class ShopManager : MonoBehaviour
{
    public TMP_Text totalscoreTxt;
    
    void Start()
    {
        totalscoreTxt.text = PlayerPrefs.GetInt("totalscore").ToString();
    }
}