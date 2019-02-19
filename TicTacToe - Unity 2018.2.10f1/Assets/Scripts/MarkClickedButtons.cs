using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarkClickedButtons : MonoBehaviour
{
    PlayerClicks playerClicked;

    private void Start()
    {
        playerClicked.ButtonTileClicked += MarkClickedButtonTile;
    }

    private void MarkClickedButtonTile(string obj)
    {
        throw new System.NotImplementedException();
    }
}
