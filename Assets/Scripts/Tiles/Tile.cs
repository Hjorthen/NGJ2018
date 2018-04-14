using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour {

    static List<Tile> objectPool = new List<Tile>();

    public Vector3 endPos; //Where the tile ends for the next one to start
    public List<Tile> possibleTiles; //Tiles that can come afte this

    public static Tile CreateTile(Tile tile)
    {
        foreach (Tile t in objectPool)
        {
            if (t.tag == tile.tag)
            {
                Tile newTile = objectPool[0];
                objectPool.RemoveAt(0);
                newTile.gameObject.SetActive(true);
                return newTile;

            }
        }
        return Instantiate<Tile>(tile);
    }

    public virtual void DestroyTile()
    {
        gameObject.SetActive(false);
        objectPool.Add(this);
    }
}
