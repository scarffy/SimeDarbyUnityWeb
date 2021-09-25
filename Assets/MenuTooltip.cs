using UnityEngine;

public class MenuTooltip : MonoBehaviour
{
    [SerializeField] private OpenSection sectionScript;
    [SerializeField] private TMPro.TMP_Text textObj;                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                       
    [SerializeField] private Icon leftWallIcon;                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                       
    [SerializeField] private Icon rightWallIcon;                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                       
    [SerializeField] private Icon roofIcon;
    [SerializeField] private Icon buildingIcon;

    public void OffTooltip()
    {
        textObj.text = "";
        gameObject.SetActive(false);
    }

    public void TextTooltip(string textString)
    {
        textObj.text = textString;
        gameObject.SetActive(true);
    }

    public void ToggleTooltip(int toggle)
    {
        string tooltipText = "";

        switch (toggle)
        {
            case 0: // Left Wall

                leftWallIcon.UpdateIcon(0);
                tooltipText = "Left Wall" + "\n<size=12><color=#757587>" + (sectionScript.LeftWallBool? "OFF" : "ON") + "</color></size>";
                break;

            case 1: // Right Wall

                rightWallIcon.UpdateIcon(1);
                tooltipText = "Right Wall" + "\n<size=12><color=#757587>" + (sectionScript.RightWallBool ? "OFF" : "ON") + "</color></size>";
                break;

            case 2: // Roof

                roofIcon.UpdateIcon(2);
                tooltipText = "Roof" + "\n<size=12><color=#757587>" + (sectionScript.RoofBool ? "OFF" : "ON") + "</color></size>";
                break;

            case 3: // Other building

                buildingIcon.UpdateIcon(3);
                tooltipText = "Side Building" + "\n<size=12><color=#757587>" + (sectionScript.OtherBuildingsBool ? "OFF" : "ON") + "</color></size>";
                break;
        }

        if (tooltipText != "")
        {
            textObj.text = tooltipText;
            gameObject.SetActive(true);
        }
    }
}
