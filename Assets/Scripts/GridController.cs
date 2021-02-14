using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridController : MonoBehaviour
{
    [SerializeField] private int _rows = 5;
    [SerializeField] private int _cols = 8;
    [SerializeField] private float _tileSize = 1f;
    
    void Start()
    {
        GenerateGrid();        
    }

    private void GenerateGrid() {
        GameObject referenceTile = Instantiate(Resources.Load("Prefabs/Square")) as GameObject;
        for (int i = 0; i < _rows; i++) {
            for (int j = 0; j < _cols; j++) {
                GameObject tile = Instantiate(referenceTile, transform) as GameObject;

                float positionX = j * _tileSize;
                float positionY = i * -_tileSize;
                tile.name = positionX + "_" + positionY;
                tile.transform.position = new Vector2(positionX, positionY);
            }
        }

        Destroy(referenceTile);

        // Grid center code
        float gridWidth = _cols * _tileSize;
        float gridHeight = _rows * _tileSize;
        float gridX = -gridWidth / 2 + _tileSize / 2;
        float gridY = gridHeight / 2 - _tileSize / 2;

        transform.position = new Vector2(gridX, gridY);
    }
}
