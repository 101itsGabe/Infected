using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class GridManager : MonoBehaviour
{
    public static GridManager Instance;
    [SerializeField] private int _width, _height;

    [SerializeField] private Tile _grassTile, _mountianTile;

    [SerializeField] private Transform _cam;

    private Dictionary<Vector2, Tile> _tiles;
    public int w, h;

    void Awake()
    {
        Instance = this;
        w = _width; h = _height;
       
    }

   

    public void GenerateGird()
    {
        _tiles = new Dictionary<Vector2,Tile>();
        for(int  x = 0; x < _width; x++) 
        {
            for(int y = 0; y < _height; y++) 
            {
                var randomTile = Random.Range(0,6) == 3 ? _mountianTile : _grassTile;
                var spawnedTile = Instantiate(randomTile, new Vector3(x, y), Quaternion.identity);
                spawnedTile.name = $"Tile {x} {y}";
                spawnedTile.xSpot = x;
                spawnedTile.ySpot = y;
                spawnedTile.Init(x,y);
                _tiles[new Vector2(x,y)] = spawnedTile;
            }
                
        }

        _cam.transform.position = new Vector3((float)_width / 2 - 0.5f, (float)_height / 2 - 0.5f, -10);

        GameManager.Instance.ChangeState(GameState.SpawnPlayer);
    }

    public Tile GetPlayerTile()
    {
        return _tiles.Where(t=>t.Key.x <  _width/2 && t.Value.walkable).OrderBy(t => Random.value).First().Value;
    }

    public Tile GetRealPlayerTile()
    {
        foreach(var t in _tiles)
        {
            if (t.Value.OccupiedUnit == UnitManager.Instance.SelectedPlayer)
                return t.Value;
        }
        return null;
    }

    public Tile GetRealEnemyTile()
    {
        foreach (var t in _tiles)
        {
            if (t.Value.OccupiedUnit == UnitManager.Instance.CurrentEnemy)
            {
                return t.Value;
            }
        }
        return null;
    }



    public Tile GetEnemyTile()
    {
        return _tiles.Where(t=>t.Key.x >  _width/2 && t.Value.walkable).OrderBy(t => Random.value).First().Value;
    }

    public Tile GetItemTile()
    {
        return _tiles.Where(t => t.Key.x > _width / 2 && t.Value.walkable).OrderBy(t => Random.value).First().Value;
    }

    public Tile GetATile(int x, int y)
    {
        if (x < _width || y < _height || x >= 0 || y >= 0)
        {
            var curTile = _tiles[new Vector2(x, y)];
            return curTile;
        }
        else
            return null;
    }
}
