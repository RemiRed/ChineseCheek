using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardSpawn : MonoBehaviour
{

    [SerializeField]
    GameObject tiles, pawn;
    [SerializeField]
    Material red, blue, black, white, yellow, green;

    Material tileColor, pawnColor;

    [SerializeField]
    float offset;
    //Skapar en jagged array av spelobjekt.
    GameObject[][] board = new GameObject[17][];

    TileScript[][] virtualBoard = new TileScript[17][];

    int[] upperOffset = new int[] { 1, 1, 1, 5, 0, 0, 0, 0, 1, 1, 1, 1, -4, 0, 0, 0 };

    int[] lowerOffset = new int[] { 0, 0, 0, -4, 1, 1, 1, 1, 0, 0, 0, 0, 5, 1, 1, 1 };


    //Längden på raden. 
    int[] rowLengths = new int[] { 1, 2, 3, 4, 13, 12, 11, 10, 9, 10, 11, 12, 13, 4, 3, 2, 1 };

    void Start()
    {
        SpawnThisBoard();
        SetNeighbours();

    }

    // Spawnar spelbrädet med hjälp av en for i en for loop. 
    void SpawnThisBoard()
    {// loopar igenom raden
        for (int i = 0; i < board.Length; i++)
        {
            board[i] = new GameObject[rowLengths[i]];
            virtualBoard[i] = new TileScript[rowLengths[i]];
            //loopar igenom kolumnen. 
            for (int j = 0; j < board[i].Length; j++)
            {
                // Skapar en tile för varje index position för nuvarande raden.
                GameObject tile = Instantiate(tiles, new Vector3((-(rowLengths[i] - 1) + (offset * j)), 0f, offset * (8 - i)), Quaternion.identity);
                virtualBoard[i][j] = tile.GetComponent<TileScript>();

                virtualBoard[i][j].AssignIndex(j, i);
                // Switchen används för att färga tilsen beroende på index position.
                switch (i)
                {
                    case 0:
                    case 1:
                    case 2:
                    case 3:
                        virtualBoard[i][j].SetColor(yellow);
                        break;
                    case 4:
                    case 5:
                    case 6:
                    case 7:
                        if (j < board[i].Length - 9)
                        {
                            virtualBoard[i][j].SetColor(blue);

                        }
                        else if (j > 8)
                        {
                            virtualBoard[i][j].SetColor(red);
                        }
                        break;
                    case 8:
                        break;
                    case 9:
                    case 10:
                    case 11:
                    case 12:
                        if (j < board[i].Length - 9)
                        {
                            virtualBoard[i][j].SetColor(green);

                        }
                        else if (j > 8)
                        {
                            virtualBoard[i][j].SetColor(black);
                        }

                        break;

                    case 13:
                    case 14:
                    case 15:
                    case 16:
                        virtualBoard[i][j].SetColor(white);
                        break;



                    default:
                        break;
                }
            }
        }

    }
    // Tillsätter posititon och håll för varje tile. 
    void SetNeighbours()
    {
        int test = 0;
        for (int i = 0; i < virtualBoard.Length; i++)
        {
            int min = 0, max = 0, rowOffset = 0;
            switch (i)
            {
                case 1:
                case 2:
                case 3:
                    max = virtualBoard[i].Length - 1;
                    break;
            }
            for (int j = 0; j < virtualBoard[i].Length; j++)
            {
                //Om det inte är högsta tile:en har tile:en en neighbour ovanför sig
                if (i > 0)
                {
                    if (j < max)
                    {
                        print(test++);
                        virtualBoard[i][j].CreateNeighbour(virtualBoard[i - 1][j + rowOffset], Direction.UpperLeft);
                    }
                    if (j >= min && j + rowOffset < virtualBoard[i - 1].Length)
                    {
                        print(test++);
                        virtualBoard[i][j].CreateNeighbour(virtualBoard[i - 1][j + rowOffset], Direction.UpperRight);
                    }
                    /*
                    if (j - lowerOffsets[i] == 0)
                    {
                        print(i);
                        print(j + lowerOffsets[i]);
                        virtualBoard[i][j].CreateNeighbour(virtualBoard[i - 1][(j + lowerOffsets[i])], Direction.UpperLeft);
                    }
                    if (j - lowerOffsets[i] == 1)
                    {
                        print(j + lowerOffsets[i]);
                        virtualBoard[i][j].CreateNeighbour(virtualBoard[i - 1][j], Direction.UpperRight);
                    }
                    */
                }
                //Om det inte är lägsta tile:en har tile:en en neighbour nedanför sig
                if (i < virtualBoard.Length - 1)
                {
                    /*
                    if (j - lowerOffsets[i] == 1)
                    {
                        //virtualBoard[i][j].CreateNeighbour(virtualBoard[i + 1][j - (upperOffsets[i] - 1)], Direction.LowerLeft);
                    }
                    if (j - lowerOffsets[i] == 0)
                    {
                        //virtualBoard[i][j].CreateNeighbour(virtualBoard[i + 1][j - (upperOffsets[i] - 1)], Direction.LowerRight);
                    }
                    */
                }
                //Om det inte är tile:en längst till vänster har tile:en en neighbour åt vänster om sig
                if (j > 0)
                {
                    virtualBoard[i][j].CreateNeighbour(virtualBoard[i][j - 1], Direction.Left);
                }
                //Om det inte är tile:en längst till höger har tile:en en neighbour åt höger om sig
                if (j < virtualBoard[i].Length - 1)
                {
                    virtualBoard[i][j].CreateNeighbour(virtualBoard[i][j + 1], Direction.Right);
                }
            }
        }
    }
}
