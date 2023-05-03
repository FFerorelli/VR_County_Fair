
using System;
using UnityEngine;
public enum GameState
{
    Start,
    Play,
    Pause,
    Quit
}
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public static event Action<GameState> OnGameStateChanged;
    private GameState _state;
    private void Awake()
    {
        if (Instance == null)        
            Instance = this;        
        else        
            Destroy(gameObject);        
    }

    public void UpdateGameState(GameState gamestate)
    {
        if (_state == gamestate) return;

        _state = gamestate;

        OnGameStateChanged?.Invoke(gamestate);
    }
}
