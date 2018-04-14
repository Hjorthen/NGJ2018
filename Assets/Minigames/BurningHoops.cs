using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurningHoops : Minigame
{
    //I will get back to this
    public int numberOfHoops;
    //public Hoop hoopPrefab;
    public GameObject player;

    TileGenerator tileGenerator;

    private void Start()
    {
        tileGenerator = player.GetComponent<TileGenerator>();
    }

    public override void StartGame()
    {
        RaycastHit hitInfo;
        Physics.Raycast(player.transform.position, Vector3.down, out hitInfo);
        Tile standingTile = hitInfo.transform.GetComponent<Tile>(); //The tile the player is standing on at the start of the minigame
        int startIndex = tileGenerator.GetTiles().IndexOf(standingTile);
        
        //Generate hoops
        for (int i = startIndex; i < startIndex + numberOfHoops; i++)
        {
            
        }
    }
}
