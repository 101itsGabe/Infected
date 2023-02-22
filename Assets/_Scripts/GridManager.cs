using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] private int _width, _height;

    [SerializeField] private Tile _tilePrefab;

    [SerializeField] private Transform _cam;

    [SerializeField] private Color _baseColor, _offsetColor;

    void Start()
    {
        GenerateGird();
    }

    void GenerateGird()
    {
        for(int  x = 0; x < _width; x++) 
        {
            for(int y = 0; y < _height; y++) 
            {
                var spawnedTile = Instantiate(_tilePrefab, new Vector3(x, y), Quaternion.identity);
                spawnedTile.name = $"Tile {x} {y}";

                var isOffset = (x % 2 == 0 && y % 2 != 0 || x % 2 != 0 && y % 2 == 0);

                if(isOffset) 
                    spawnedTile.GetComponent<Renderer>().material.color = new Color(48f/255f, 25f / 255f, 52f / 255f);
                else
                    spawnedTile.GetComponent<Renderer>().material.color = new Color(130f / 255f, 130f / 255f, 150f / 255f);
            }
        }

        _cam.transform.position = new Vector3((float)_width / 2 - 0.5f, (float)_height / 2 - 0.5f, -10);
    }
}
