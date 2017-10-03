using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour {

    public Unit testUnit;
    public Unit selectedUnit;
    public GameBoard gameBoard;



	// Use this for initialization
	void Start () {
        gameBoard = FindObjectOfType<GameBoard>();
        selectedUnit = null;
        selectedUnit = FindObjectOfType<Unit>();
        
	}

    // Update is called once per frame
    void Update ()
    {
        if (!isLocalPlayer)
            return;

        if (Input.GetMouseButtonDown(0))
        {
            Vector3 position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));

            if (IsMouseWithinGameBoard(position))
            {
                position = new Vector3(Mathf.Round(position.x), Mathf.Round(position.y), 0);

                if (gameBoard.TileAt(position).HasUnit)
                {
                    selectedUnit = gameBoard.TileAt(position).Unit;
                }

                else if (!gameBoard.TileAt(position).HasUnit && selectedUnit != null)
                {
                    gameBoard.TileAt(position).Unit = selectedUnit;
                    selectedUnit.transform.position = position;
                    selectedUnit = null;
                }


            }
            //else if (cursor is on card)
            //selectedunit = card

        
        }

    }

    private bool IsMouseWithinGameBoard(Vector3 position)
    {
        if (!(position.x >= gameBoard.transform.position.x - gameBoard.transform.localScale.x / 2) || !(position.x <= gameBoard.transform.position.x + gameBoard.transform.localScale.x / 2))
        {
            return false;
        }

        if (!(position.y >= gameBoard.transform.position.y - gameBoard.transform.localScale.y / 2) || !(position.y <= gameBoard.transform.position.y + gameBoard.transform.localScale.y / 2))
        {
            return false;
        }


        return true;
    }

    private void PlaceUnitOnBoard(Unit selectedUnit, Vector3 position)
    {
        selectedUnit.transform.position = new Vector3(Mathf.Round(position.x), Mathf.Round(position.y), 0);
    }

    public override void OnStartLocalPlayer()
    {
        //GetComponent<MeshRenderer>().material.color = Color.green;
    }
}
