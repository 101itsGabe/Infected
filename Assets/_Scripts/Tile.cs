using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private GameObject _highlight;

    public void Init(bool isOffset)
    {
        //GetComponent<Renderer>().material.color = isOffset? _baseColor : _offsetColor;
        
    }

    void OnMouseEnter()
    {
        _highlight.SetActive(true);
    }

    public void OnMouseExit() 
    {
        _highlight.SetActive(false);
    }
}
