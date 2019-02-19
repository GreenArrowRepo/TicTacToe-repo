using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerClicks : MonoBehaviour
{

    [SerializeField]
    private Button[] buttonTiles; //get buttons in array by assigning buttons in inspector
    
    private Button clickedButton;
    private Sprite xSprite;
    private Sprite oSprite;
    string buttonName;
    public Image SymbolImg { get; private set; }

    public event Action<string> ButtonTileClicked = delegate { };

    private void Start()
    {
        xSprite = GameManager.Instance.PlayerSymbols[0];
        oSprite = GameManager.Instance.PlayerSymbols[1];
        
        SetButtons();
    }

    // Add Listner to all buttons
    private void SetButtons()
    {
        foreach (Button btn in buttonTiles)
        {
            btn.GetComponent<Button>().interactable = true;
            btn.GetComponent<Image>().sprite = null;
        }
    }

    // draw a sprite when the button is clicked and change turn.
    public void OnButtonClicked(int btnIndex)
    {
        clickedButton = buttonTiles[btnIndex];
        
        SymbolImg = clickedButton.GetComponent<Image>();

        clickedButton.GetComponent<Button>().interactable = false;

        if (GameManager.Instance.PlayerTurn)
        {
            SymbolImg.sprite = xSprite;
        }
        else
        {
            SymbolImg.sprite = oSprite;
        }

        // mark clicked button using event action // call to MarkClickedButtons script.
        buttonName = clickedButton.name;
        ButtonTileClicked(buttonName);

        GameManager.Instance.CheckWin();

        // change player turn
        GameManager.Instance.ChangePlayerTurn();

        
        

    }
}
