using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;

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
            case GameState.SpawnItem:
                UnitManager.Instance.spawnItem();
                break;
            case GameState.PlayerTurn:
                break;
            case GameState.EnemyTurn:
                break;
            case GameState.GameEnd:
                break;

            //default:
            //    throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        ChangeState(GameState.GenerateGird);
        InvokeRepeating("MoveZombie", 1f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        isTouching();
        if (GameState == GameState.GameEnd)
            CancelInvoke();

    }

    void MovePlayer()
    {
        if (Input.GetKeyDown(KeyCode.W) && UnitManager.Instance.SelectedPlayer != null)
        {
            var curPlayer = UnitManager.Instance.SelectedPlayer;
            var curTile = GridManager.Instance.GetRealPlayerTile();
            int x = curTile.xSpot;
            int y = curTile.ySpot;
            if (y + 1 < GridManager.Instance.h)
            {
                var nextTile = GridManager.Instance.GetATile(x, y + 1);
                if (nextTile.walkable)
                    nextTile.SetUnit(curPlayer);
            }

        }
        if (Input.GetKeyDown(KeyCode.S) && UnitManager.Instance.SelectedPlayer != null)
        {
            var curPlayer = UnitManager.Instance.SelectedPlayer;
            var curTile = GridManager.Instance.GetRealPlayerTile();
            int x = curTile.xSpot;
            int y = curTile.ySpot;
            if (y - 1 >= 0)
            {
                var nextTile = GridManager.Instance.GetATile(x, y - 1);
                if (nextTile.walkable)
                    nextTile.SetUnit(curPlayer);
            }
        }

        if (Input.GetKeyDown(KeyCode.A) && UnitManager.Instance.SelectedPlayer != null)
        {
            var curPlayer = UnitManager.Instance.SelectedPlayer;
            var curTile = GridManager.Instance.GetRealPlayerTile();
            int x = curTile.xSpot;
            int y = curTile.ySpot;
            if (x - 1 >= 0)
            {
                var nextTile = GridManager.Instance.GetATile(x - 1, y);
                if (nextTile.walkable)
                    nextTile.SetUnit(curPlayer);
            }
        }
        if (Input.GetKeyDown(KeyCode.D) && UnitManager.Instance.SelectedPlayer != null)
        {
            var curPlayer = UnitManager.Instance.SelectedPlayer;
            var curTile = GridManager.Instance.GetRealPlayerTile();
            int x = curTile.xSpot;
            int y = curTile.ySpot;
            if (x + 1 < GridManager.Instance.w )
            {
                var nextTile = GridManager.Instance.GetATile(x + 1, y);
                if(nextTile.walkable)
                    nextTile.SetUnit(curPlayer);
            }
        }
    }

    void MoveZombie()
    {

        int r = Random.Range(1, 6);
        var PlayerTile = GridManager.Instance.GetRealPlayerTile();

        if (r == 1 && UnitManager.Instance.CurrentEnemy != null)
        {
            var curPlayer = UnitManager.Instance.CurrentEnemy;
            var curTile = GridManager.Instance.GetRealEnemyTile();
            int x = curTile.xSpot;
            int y = curTile.ySpot;
            if (y + 1 < GridManager.Instance.h)
            {
                var nextTile = GridManager.Instance.GetATile(x, y + 1);
                if (nextTile.walkable)
                    nextTile.SetUnit(curPlayer);
            }

        }
        if (r == 2 && (UnitManager.Instance.CurrentEnemy != null))
        {
            var curPlayer = UnitManager.Instance.CurrentEnemy;
            var curTile = GridManager.Instance.GetRealEnemyTile();
            int x = curTile.xSpot;
            int y = curTile.ySpot;
            if (y - 1 >= 0)
            {
                var nextTile = GridManager.Instance.GetATile(x, y - 1);
                if (nextTile.walkable)
                    nextTile.SetUnit(curPlayer);
            }
        }
        if (r == 3 && UnitManager.Instance.CurrentEnemy != null)
        {
            var curPlayer = UnitManager.Instance.CurrentEnemy;
            var curTile = GridManager.Instance.GetRealEnemyTile();
            int x = curTile.xSpot;
            int y = curTile.ySpot;
            if (x - 1 >= 0)
            {
                var nextTile = GridManager.Instance.GetATile(x - 1, y);
                if (nextTile.walkable)
                    nextTile.SetUnit(curPlayer);
            }
        }
        if (r == 4 && UnitManager.Instance.CurrentEnemy != null)
        {
            var curPlayer = UnitManager.Instance.CurrentEnemy;
            var curTile = GridManager.Instance.GetRealEnemyTile();
            int x = curTile.xSpot;
            int y = curTile.ySpot;
            if (x + 1 < GridManager.Instance.w)
            {
                var nextTile = GridManager.Instance.GetATile(x + 1, y);
                if (nextTile.walkable)
                    nextTile.SetUnit(curPlayer);
            }
        }
        if (r == 5 && UnitManager.Instance.CurrentEnemy != null)
        {
            var curPlayer = UnitManager.Instance.CurrentEnemy;
            var curTile = GridManager.Instance.GetRealEnemyTile();
            int x = curTile.xSpot;
            int y = curTile.ySpot;
            if (PlayerTile.xSpot < x)
            {
                var nextTile = GridManager.Instance.GetATile(x - 1, y);
                if (nextTile.walkable)
                    nextTile.SetUnit(curPlayer);
            }
            else if(PlayerTile.xSpot > x)
            {
                var nextTile = GridManager.Instance.GetATile(x + 1, y);
                if (nextTile.walkable)
                    nextTile.SetUnit(curPlayer);
            }
        }
        if(r == 6 && UnitManager.Instance.CurrentEnemy != null)
        {
            var curPlayer = UnitManager.Instance.CurrentEnemy;
            var curTile = GridManager.Instance.GetRealEnemyTile();
            int x = curTile.xSpot;
            int y = curTile.ySpot;
            if (PlayerTile.ySpot < y)
            {
                var nextTile = GridManager.Instance.GetATile(x, y - 1);
                if (nextTile.walkable)
                    nextTile.SetUnit(curPlayer);
            }
            else if (PlayerTile.ySpot > y)
            {
                var nextTile = GridManager.Instance.GetATile(x, y + 1);
                if (nextTile.walkable)
                    nextTile.SetUnit(curPlayer);
            }
        }

    }

    void isTouching()
    {
        var pTile = GridManager.Instance.GetRealPlayerTile();
        var eTile = GridManager.Instance.GetRealEnemyTile();
        if(eTile.xSpot + 1 == pTile.xSpot  && eTile.ySpot == pTile.ySpot|| eTile.xSpot - 1 == pTile.xSpot && eTile.ySpot == pTile.ySpot
            || eTile.ySpot + 1 == pTile.ySpot && eTile.xSpot == pTile.xSpot || eTile.ySpot - 1 == pTile.ySpot && eTile.xSpot == pTile.xSpot)
        {
            ChangeState(GameState.GameEnd);
            MenuManager.Instance.showEnd();
        }
    }
    void EndGame()
    {
        if(GameState == GameState.GameEnd)
        {
            Time.timeScale = 0;
        }
    }
}

public enum GameState
{
    GenerateGird = 0,
    SpawnPlayer = 1,
    SpawnEnemy = 2,
    PlayerTurn = 3,
    EnemyTurn = 4,
    GameEnd = 5,
    SpawnItem = 6
}




