using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GameBoard : NetworkBehaviour {

    public Tile[,] tileArray;

	// Use this for initialization
	void Start () {

        tileArray = new Tile[(int)transform.localScale.x, (int)transform.localScale.y];

        for (int i = 0; i < transform.localScale.x; i++)
        {
            for (int j = 0; j < transform.localScale.y; j++)
            {
                tileArray[i, j] = new Tile();

                tileArray[i, j].gameBoard = this;
            }
        }
	}
	
    public Tile TileAt(Vector3 position)
    {
        return tileArray[(int)position.x + (int)transform.localScale.x / 2, (int)position.y + (int)transform.localScale.y / 2];
    }

	// Update is called once per frame
	void Update () {
		
	}
}
