
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


    public GameState State => _state;
    private GameState _state;

    private void Awake()
    {
        if (Instance == null)        
            Instance = this;        
        else        
            Destroy(gameObject);        
    }
    private void Start()
    {
        UpdateGameState(GameState.Start); 
    }
    public void UpdateGameState(GameState gamestate)
    {
        if (_state == gamestate) return;

        _state = gamestate;


        if (gamestate == GameState.Quit)
        {
            HandleApplicationQuit();
        }
        OnGameStateChanged?.Invoke(gamestate);
    }

    private void HandleApplicationQuit()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif

    }
}
