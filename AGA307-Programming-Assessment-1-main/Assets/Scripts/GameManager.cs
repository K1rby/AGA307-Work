using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    Start,
    Playing,
    Paused,
    GameOver,
    //--------
    COUNT
}

public enum Difficulty { Easy, Medium, Hard}

public class GameManager : Singleton<GameManager>
{
    public GameState gameState;
    public Difficulty difficulty;

    float scoreMultiplier = 1f;
    float score = 3;

    private void OnEnable()
    {
        GameEvents.OnEnemyHit += OnEnemyHit;
    }

    private void OnDisable()
    {
        GameEvents.OnEnemyHit -= OnEnemyHit;
    }

    void OnEnemyHit(Enemies _enemy)
    {
        AddScore(score);
    }

    // Start is called before the first frame update
    void Start()
    {
        //These are the defaults set upon starting the game
        gameState = GameState.Start;
        difficulty = Difficulty.Easy;

        SetUp();
        Debug.Log(score);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetUp()
    {
        switch (difficulty)
        {
            case Difficulty.Easy:
                scoreMultiplier = 1f;
                break;
            case Difficulty.Medium:
                scoreMultiplier = 2f;
                break;
            case Difficulty.Hard:
                scoreMultiplier = 3f;
                break;
            default:
                scoreMultiplier = 1f;
                break;
        }
    }

    public void AddScore(float _points)
    {
        score += _points * scoreMultiplier;
    }
}
