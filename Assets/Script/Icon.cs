using UnityEngine;

public class Icon : MonoBehaviour
{
    [SerializeField] private OpenSection sectionScript;
    public UnityEngine.UI.Image icon;
    public Sprite iconOn;
    public Sprite iconOff;

    public void UpdateIcon(int boolID)
    {
        switch (boolID)
        {
            case 0:
                icon.sprite = sectionScript.LeftWallBool ? iconOff : iconOn;
                break;
            case 1:
                icon.sprite = sectionScript.RightWallBool ? iconOff : iconOn;
                break;
            case 2:
                icon.sprite = sectionScript.RoofBool ? iconOff : iconOn;
                break;
            case 3:
                icon.sprite = sectionScript.OtherBuildingsBool ? iconOff : iconOn;
                break;
        }
    }
}