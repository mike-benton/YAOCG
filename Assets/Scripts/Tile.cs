using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile {

    public GameBoard gameBoard;
    string terrain; //change to enum at some point
    Unit unit;

    public Unit Unit
    {
        get { return unit; }
        set { unit = value; }
    }

    public bool HasUnit
    {
        get { return unit != null; }
    }



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
