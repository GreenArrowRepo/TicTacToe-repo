using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Tooltip("Set True for X and false for O, whoever wants to go first.")]
    [SerializeField]
    private bool playerTurn; 
    public bool PlayerTurn { get { return playerTurn; } }

    [Tooltip("player Icons X=player1 and O=player2")]
    [SerializeField]
    private Sprite[] playerSymbols;
    public Sprite[] PlayerSymbols { get { return playerSymbols; } }

    [SerializeField]
    private GameObject[] playerIcon;

    // counts total number of moves by both players
    private int moveCount; 

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        moveCount = 0;
        playerIcon[0].SetActive(true);
        playerIcon[1].SetActive(false);
    }

    internal void ChangePlayerTurn()
    {
        moveCount++;
        Debug.Log("move count :" + moveCount);
        playerTurn = !playerTurn;
        if (!playerTurn)
        {
            playerIcon[0].SetActive(false);
            playerIcon[1].SetActive(true);
        }
        else
        {
            playerIcon[0].SetActive(true);
            playerIcon[1].SetActive(false);
        }
    }

    internal void CheckWin()
    {
       
    }
}
