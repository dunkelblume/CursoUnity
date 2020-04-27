using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Button TrueBtn;
    public Button FalseBtn;
    public ScoreHandler scoreHandler;
    public GameTextElementComponent GameText;
    public GameImageElementComponent GameCircle;
    public ColorProperties[] availableColors;

    private void Start()
    {
        ChangeColors();
    }

    public void ChangeColors()
    {
        int randColorGameCircle = Random.Range(0, availableColors.Length - 1);
        int randColorGameText = Random.Range(0, availableColors.Length - 1);

        GameText.SetNewColor(availableColors[randColorGameCircle], availableColors[randColorGameText]);
        GameCircle.SetNewColor(availableColors[randColorGameCircle]);

    }

    public void CheckAnswer(bool _answer)
    {
        if(GameCircle.myColor == GameText.myColor && _answer)
        {
            scoreHandler.UpdateScore();
        }
        else if (GameCircle.myColor != GameText.myColor && _answer == false)
        {
            scoreHandler.UpdateScore();
        }
        else
        {
            scoreHandler.WrongAnswer(availableColors,"Rojo");
        }

        ChangeColors();
    }
}

