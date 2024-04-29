using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SkinInShop : MonoBehaviour
{
    public SSkinInfo skinInfo;
    public Image skinImage;
    public bool isSkinUnlocked;
    public TextMeshProUGUI buttonText;
        private void Awake(){
        skinImage.sprite = skinInfo.skinSprite;
        IsSkinUnlocked();
    }

    private void IsSkinUnlocked(){
        if(PlayerPrefs.GetInt(skinInfo.skinID.ToString()) == 1){
            isSkinUnlocked = true;
            buttonText.text = "Equip";
        }
    }

    public void OnButtonPress(){
        if(isSkinUnlocked){
            //equip
            FindObjectOfType<SkinManager>().EquipSkin(skinInfo);
        } else {
            //buy
            if(PlayerPrefs.GetInt("totalscore") >= skinInfo.skinPrice){
                PlayerPrefs.SetInt(skinInfo.skinID.ToString(), 1);
                IsSkinUnlocked();
            }
        }
    }
}
