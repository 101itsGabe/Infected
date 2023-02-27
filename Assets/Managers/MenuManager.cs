using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;
    [SerializeField] private GameObject _selectedPlayerObject, _tileObject, _tileInfoObject;

    void Awake()
    {
        Instance = this;
    }

    public void showTileInfo(Tile t)
    {
        if(t == null)
        {
            _tileObject.SetActive(false);
            _tileInfoObject.SetActive(false);
            return;
        }

        _tileObject.GetComponentInChildren<Text>().text = t.TileName;
        _tileObject.SetActive(true);

        if(t.OccupiedUnit)
        {
            _tileInfoObject.GetComponentInChildren<Text>().text = t.OccupiedUnit.UnitName;
            _tileInfoObject.SetActive(true);
        }
    }

    public void showSelectedPlayer(BasePlayer p)
    {
        if(p == null)
        {
            _selectedPlayerObject.SetActive(false);
            return;
        }

        _selectedPlayerObject.GetComponentInChildren<Text>().text = p.UnitName;
        _selectedPlayerObject.SetActive(true);
    }
}
