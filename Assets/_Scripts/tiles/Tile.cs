using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Tile : MonoBehaviour
{
    
    public string TileName;
    [SerializeField] protected SpriteRenderer _renderer;
    [SerializeField] private GameObject _highlight;
    [SerializeField] private bool _isWalkable;

    public int xSpot, ySpot;
    public BaseUnit OccupiedUnit;
    public bool walkable => _isWalkable && (OccupiedUnit == null || OccupiedUnit.Faction == Faction.Item);
    public bool hasItem;

    public virtual void Init(int x, int y)
    {
        

    }

    void OnMouseEnter()
    {
        _highlight.SetActive(true);
        MenuManager.Instance.showTileInfo(this);
    }


    public void setEnemy()
    {
            UnitManager.Instance.setCurrentEnemy(OccupiedUnit.GetComponent<BaseEnemy>());
    }


    void OnMouseDown()
    {
        if(GameManager.Instance.GameState != GameState.PlayerTurn) 
            return;

        if(OccupiedUnit != null)
        {
            
            if(OccupiedUnit.Faction == Faction.Player)
                UnitManager.Instance.setSelectedPlayer(OccupiedUnit.GetComponent<BasePlayer>());
            


            else
            {
                if(UnitManager.Instance.SelectedPlayer != null)
                {
                    var enemy = OccupiedUnit.GetComponent<BaseEnemy>();
                    //Doind somehting like this selected player Attack function and
                    //sending in the base enemy
                    Destroy(enemy.gameObject);
                    UnitManager.Instance.setSelectedPlayer(null);
                }
            }
        }
        else
        {
            if(UnitManager.Instance.SelectedPlayer != null)
            {
                        SetUnit(UnitManager.Instance.SelectedPlayer);
                        UnitManager.Instance.setSelectedPlayer(null);
            }
        }
    }

    public void OnMouseExit() 
    {
        _highlight.SetActive(false);
        MenuManager.Instance.showTileInfo(null);
    }

    public void SetUnit(BaseUnit unit)
    {
        if(unit.OccupiedTile != null) unit.OccupiedTile.OccupiedUnit = null;
        unit.transform.position = transform.position;
        OccupiedUnit = unit;
        unit.OccupiedTile = this;
    }
}
