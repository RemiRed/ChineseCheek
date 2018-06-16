using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour {

    List<List<Node>> nests;
    public List<List<Node>> Nests // Property
    {
        get { return this.nests; }
    } 

    GameManager GM;

    Node[,] board = new Node[17, 17];

    int[] minCol, maxCol;

    Material[] mats;

    GameObject nodePrefab;
    
    public BoardManager (GameManager GM, GameObject nodePrefab, Material [] mats)       // Konstruktor för boardmanager
    {
        this.GM = GM;
        this.nodePrefab = nodePrefab;
        this.mats = mats;
        minCol = new int[] {4, 4, 4, 4, 0, 1, 2, 3, 4, 4, 4, 4, 4, 9, 10, 11, 12 };
        maxCol = new int[] {4, 5, 6, 7, 12, 12, 12, 12, 12, 13, 14, 15, 16, 12, 12, 12, 12 };
        SpawnBoard();
        AssignNeighbours();
    }

    private void SpawnBoard()
    {
        for (int i = 0; i < minCol.Length; i++)
        {
            for (int j = minCol[i]; j <= maxCol[i]; j++)
            {
                board[i, j] = Instantiate(nodePrefab, new Vector3(-8 + (2 * j) - i, 0f, 16 - 2 * i), Quaternion.identity).GetComponent<Node>();
            }
        }
    }
    //sololearn
	private void AssignNeighbours()
    {
        for (int i = 0; i < minCol.Length; i++)
        {
            for (int j = minCol[i]; j <= maxCol[i]; j++)
            {

            }
        }
    }
}
