using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTextElementComponent : MonoBehaviour
{
    public Text GameText;
    public ColorProperties myColor;

    public void SetNewColor(ColorProperties _newColor,ColorProperties _newColorText)
    {
        GameText.color = _newColor.color;
        GameText.text = _newColorText.Name;
        myColor = _newColorText;
    }
}
