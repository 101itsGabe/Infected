using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using Random = UnityEngine.Random;


public class UnitManager : MonoBehaviour
{
    public static UnitManager Instance;
    private List<ScriptableUnit> _units;
   void Awake()
   {
    Instance = this;

    _units = Resources.LoadAll<ScriptableUnit>("Units").ToList();
   }

   public void spawnPlayer()
   {
    var heroCount = 1;
    for(int i = 0; i < heroCount; i++)
    {
        var randomPrefab = GetRandomUnit<BasePlayer>(Faction.Player);
        var spawnedPlayer = Instantiate(randomPrefab);
        var randomSpawnTile = GridManager.Instance.GetPlayerTile();

        randomSpawnTile.SetUnit(spawnedPlayer);
    }

    GameManager.Instance.ChangeState(GameState.SpawnEnemy);
   }

    public void spawnEnemy()
   {
    var heroCount = 1;
    for(int i = 0; i < heroCount; i++)
    {
        var randomPrefab = GetRandomUnit<BaseEnemy>(Faction.Enemy);
        var spawnedEnemy = Instantiate(randomPrefab);
        var randomSpawnTile = GridManager.Instance.GetEnemyTile();

        randomSpawnTile.SetUnit(spawnedEnemy);
    }

     GameManager.Instance.ChangeState(GameState.PlayerTurn);
   }


    private T GetRandomUnit<T>(Faction faction)where T : BaseUnit
    {
        return (T)_units.Where(u => u.Faction == faction).OrderBy(o=>Random.value).First().UnitPrefab;
    }

}