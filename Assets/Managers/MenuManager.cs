using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;
    [SerializeField] private GameObject _selectedPlayerObject, _tileObject, _tileInfoObject, _TIO2, _End;

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
            _TIO2.SetActive(false);
            _End.SetActive(false);
            return;
        }

        _tileObject.GetComponentInChildren<Text>().text = t.TileName;
        _tileObject.SetActive(true);

        if(t.OccupiedUnit)
        {
            string text = t.OccupiedUnit.UnitName;
            text += " ";
            text += t.xSpot;
            text += " " + t.ySpot;
            _tileInfoObject.GetComponentInChildren<Text>().text = text;
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

    public void showCurrentEnemy(BaseEnemy e)
    {
        if(e == null) 
        {
            _TIO2.SetActive(false) ;
            return;
        }

        _TIO2.GetComponentInChildren<Text>().text = e.UnitName;
        _TIO2.SetActive(true);
    }

    public void showEnd()
    {
        if(GameManager.Instance.GameState == GameState.GameEnd)
        {
            _End.SetActive(true);
        }
    }
}
