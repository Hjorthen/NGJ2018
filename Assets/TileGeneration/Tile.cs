using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour {

    static List<Tile> objectPool = new List<Tile>();

    public Vector3 endPos; //Where the tile ends for the next one to start
    public List<Tile> possibleTiles; //Tiles that can come afte this

    public static Tile CreateTile(Tile tile, Vector3 position, Quaternion rotation)
    {
        for(int i = 0; i < objectPool.Count; i++)
        {
            if (objectPool[i].tag == tile.tag)
            {
                Tile newTile = objectPool[i];
                objectPool.RemoveAt(i);
                newTile.gameObject.SetActive(true);
                newTile.transform.position = position;
                newTile.transform.rotation = rotation;
                return newTile;

            }
        }
        return Instantiate<Tile>(tile, position, rotation);
    }

    public void DestroyTile()
    {
        gameObject.SetActive(false);
        objectPool.Add(this);
    }
}
