using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Text[] buttonlist;
    private string playerSide;

    public GameObject gameOverPanel;
    public GameObject restartButton;
    public GameObject Pausemenu;

    public Text gameOverText;

    



    private int moveCount;
    private void Awake()
    {
        gameOverPanel.SetActive(false);
        setGameManagerRefonButton();
        playerSide = "X";
        moveCount = 0;
        Pausemenu.SetActive(false);

    }
    void setGameManagerRefonButton()
    {
        for (int i = 0; i < buttonlist.Length; i++)
        {
            buttonlist[i].GetComponentInParent<GridSpace>().SetGameManagerRef(this); // Each Grid Space insatnce will use this to set refernece to GameManager
        }
    }

    public string getPlayerSide()  // Returns the current playerside(X,O)
    {
        return playerSide;
    }

    public void EndTurn() // Checks for the winning condition and draw condition and increments moveCount value by +1 on every tap
    {
        moveCount++;
        if(buttonlist[0].text == playerSide && buttonlist[1].text == playerSide && buttonlist[2].text == playerSide)    // row 1(Grid Space = 0,1,2) 
        {
            GameOver(playerSide);
        }

        if (buttonlist[3].text == playerSide && buttonlist[4].text == playerSide && buttonlist[5].text == playerSide)  // row 2 (Grid Space = 3,4,5)
        {
            GameOver(playerSide);
        }

        if (buttonlist[6].text == playerSide && buttonlist[7].text == playerSide && buttonlist[8].text == playerSide)  // row 3 (Grid Space = 6,7,8)
        {
            GameOver(playerSide);
        }

        if (buttonlist[0].text == playerSide && buttonlist[3].text == playerSide && buttonlist[6].text == playerSide)  // column 1(Grid Space = 0,3,6)
        {
            GameOver(playerSide);
        }

        if (buttonlist[1].text == playerSide && buttonlist[4].text == playerSide && buttonlist[7].text == playerSide)  // column 2(Grid Space = 1,4,7)
        {
            GameOver(playerSide);
        }

        if (buttonlist[2].text == playerSide && buttonlist[5].text == playerSide && buttonlist[8].text == playerSide)  // column 3(Grid Space = 2,5,8)
        {
            GameOver(playerSide);
        }

        if (buttonlist[0].text == playerSide && buttonlist[4].text == playerSide && buttonlist[8].text == playerSide)  // Diagonal 1(Grid Space =0,4,8)
        {
            GameOver(playerSide);
        }

        if (buttonlist[2].text == playerSide && buttonlist[4].text == playerSide && buttonlist[6].text == playerSide)  // Diagonal 2(Grid Space = 2,4,6)
        {
            GameOver(playerSide);
        }


        
        if (moveCount >=9)
        {
            GameOver("draw");
        }
    
        ChangeSides();
    }
   
    void GameOver(string winningPlayer) // It prints win or tie condition
    {
        SetBoardInteractable(false);

        if(winningPlayer == "draw")
        {
            SetGameOverText("Game Tie!");
        }
        else
        {
            SetGameOverText(winningPlayer + " Wins!");
        }
        restartButton.SetActive(true);
    }

    void ChangeSides() // Changes player side from "X" to "O"
    {
        playerSide = (playerSide == "X") ? "O" : "X";  
  
    }

    void SetGameOverText(string value) //Sets the gameover panel to be activated 
    {
        var val = value;
        gameOverText.text = val;
        gameOverPanel.SetActive(true);
        
    }

    public void RestartGame() // Restarts the game
    {
        playerSide = "X";
        moveCount = 0;
        gameOverPanel.SetActive(false);

        SetBoardInteractable(true);
        for (int i = 0; i < buttonlist.Length; i++)
        {
            buttonlist[i].text = "";

        }

        Pausemenu.SetActive(false);
    }


    void SetBoardInteractable(bool toggle) // Sets the board to interactable or non-interactable 
    {
        for (int i = 0; i < buttonlist.Length; i++)
        {
            buttonlist[i].GetComponentInParent<Button>().interactable = toggle;

        }
    }


    
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }
    public void QuitGame()
    {
        Application.Quit();

    }
    public void PauseGame()
    {
        Pausemenu.SetActive(true);

    }
    public void ResumeGame()
    {
        Pausemenu.SetActive(false);
    }
}


