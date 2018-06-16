using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction
{
    Right,Left,UpperRight,UpperLeft,LowerRight,LowerLeft
}

public class Neighbour 
{
    TileScript tile;
    Direction dir; 
    
    public Direction Dir
    {
        get { return dir; }
    }
    public TileScript Tile
    {
        get { return tile; }
    }

    public Neighbour (TileScript tile, Direction dir)
    {
        this.tile = tile;
        this.dir = dir;
    }
    
}

public class TileScript : MonoBehaviour {
    int x, y;
    //Skapar en kollektion av Neighbours
    List<Neighbour> neighbours = new List<Neighbour>();

    public void AssignIndex(int x, int y)
    {
        this.x = x;
        this.y = y;

    }
    //metod för att skapa grannarna för denna tile.
    public void CreateNeighbour(TileScript tile,Direction dir )
    {
        neighbours.Add(new Neighbour(tile, dir));
    }
    //tillsätter material till tilsen. 
	public void SetColor(Material mat)
    {
        GetComponent<Renderer>().material = mat; 
    }
}
