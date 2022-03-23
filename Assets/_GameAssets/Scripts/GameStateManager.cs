using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    public static GameStateManager Instance { get; private set; }
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
    public delegate void GameStateChangeHandler(GameState newGameState);
    public event GameStateChangeHandler OnGameStateChanged;
    public GameState CurrentGameState { get; private set; }
    public void SetState(GameState newGameState)
    {
        if (newGameState == CurrentGameState) return;
        CurrentGameState = newGameState;
        OnGameStateChanged?.Invoke(newGameState);
    }
}
