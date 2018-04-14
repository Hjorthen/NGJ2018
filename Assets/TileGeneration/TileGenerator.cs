using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileGenerator : MonoBehaviour {


    public float generationDistance; //Distance the generator will generate to
    public float deleteDistance; //Distance when the generator will start deleting pieces
    public Tile startile;
    public List<Wall> wallPrefabs;
    public Transform player;

    private List<Tile> instantiatedTiles = new List<Tile>(); //Ordered list of tiles
    private List<Wall> instantiatedWalls = new List<Wall>(); //Ordred list of walls


    // Use this for initialization
    void Start () {
        instantiatedTiles.Add(Instantiate<Tile>(startile));
        instantiatedWalls.Add(Instantiate<Wall>(wallPrefabs[0]));
	}
	
	// Update is called once per frame
	void Update () {

        //Check delete distance on first instantiated piece
        if (Vector3.Distance(player.position, instantiatedTiles[0].transform.position) > deleteDistance)
        {
            instantiatedTiles[0].DestroyTile();
            instantiatedTiles.RemoveAt(0);
        }

        //Check generation distance on the latest piece
        if (Vector3.Distance(player.position, instantiatedTiles[instantiatedTiles.Count - 1].transform.position) < generationDistance)
        {
            Tile currentTile = instantiatedTiles[instantiatedTiles.Count - 1];
            instantiatedTiles.Add(Tile.CreateTile(PickRandomPossibleTile(currentTile), currentTile.transform.position + currentTile.endPos, currentTile.transform.rotation));
        }

        //Check delete distance on earliest wall in list
        if (Vector3.Distance(player.position, instantiatedWalls[0].transform.position) > deleteDistance)
        {
            instantiatedWalls[0].DestroyWall();
            instantiatedWalls.RemoveAt(0);
        }

        //Check generation distance on the latest wall
        if (Vector3.Distance(player.position, instantiatedWalls[instantiatedWalls.Count - 1].transform.position) < generationDistance)
        {
            Wall currentWall = instantiatedWalls[instantiatedWalls.Count - 1];
            instantiatedWalls.Add(Wall.CreateWall(pickRandomWall(), currentWall.transform.position + currentWall.endPos, currentWall.transform.rotation));
        }
    }


    private Tile PickRandomPossibleTile(Tile currentTile)
    {
        int index = Random.Range(0, currentTile.possibleTiles.Count);
        return currentTile.possibleTiles[index];
    }

    private Wall pickRandomWall()
    {
        return wallPrefabs[Random.Range(0, wallPrefabs.Count)];
    }

    public List<Tile> GetTiles()
    {
        return instantiatedTiles;
    }
}
