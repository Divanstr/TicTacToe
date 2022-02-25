using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridSpace : MonoBehaviour
{
    public Button button;
    public Text buttonText;
   

    [SerializeField]
    private GameManager gameManager;


    public void SetSpace()
    {
        buttonText.text = gameManager.getPlayerSide();
        button.interactable = false;
        gameManager.EndTurn();
    }

    public void SetGameManagerRef(GameManager manager)
    {
        gameManager = manager;
    }

}
