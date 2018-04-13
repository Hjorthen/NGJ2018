using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour {

    public Vector3 endPos; //Where the tile ends for the next one to start
    public List<Tile> possibleTiles; //Tiles that can come afte this
}
