using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameState GameState;

    void Awake()    //Allows us to grab from anywhere
    {
        Instance = this;
    }

    public void ChangeState(GameState newState)
    {
        GameState = newState;
        switch(newState)
        {
            case GameState.GenerateGird:
                GridManager.Instance.GenerateGird();
                break;
            case GameState.SpawnPlayer:
                UnitManager.Instance.spawnPlayer();
                break;
            case GameState.SpawnEnemy:
                UnitManager.Instance.spawnEnemy();
                break;
            case GameState.PlayerTurn:
                break;
            case GameState.EnemyTurn:
                break;
            //default:
            //    throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        ChangeState(GameState.GenerateGird);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

public enum GameState
{
    GenerateGird = 0,
    SpawnPlayer = 1,
    SpawnEnemy = 2,
    PlayerTurn = 3,
    EnemyTurn = 4
}




