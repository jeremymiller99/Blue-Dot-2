using UnityEngine;

[CreateAssetMenu(fileName ="New Skin", menuName ="Create New Skin")]
public class SSkinInfo : ScriptableObject
{
    public enum SkinIDs { og, smile, sad, iO, wink, mustache, xx, king }
    public SkinIDs skinID;
    public Sprite skinSprite;
    public int skinPrice;
}
