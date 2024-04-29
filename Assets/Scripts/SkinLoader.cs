using UnityEngine;

public class SkinLoader : MonoBehaviour
{
    public static SpriteRenderer playerSR;
    public static Sprite og;
private void Awake(){
        playerSR.sprite = SkinManager.equippedSkin;
    }
}
