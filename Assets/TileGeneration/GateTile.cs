using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateTile : Tile {



    public override void DestroyTile()
    {
        Destroy(gameObject);
    }
}
