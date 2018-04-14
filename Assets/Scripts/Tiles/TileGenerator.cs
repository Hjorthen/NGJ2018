using Assets.Scripts.Tiles;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileGenerator : MonoBehaviour {


    public float generationDistance; //Distance the generator will generate to
    public float deleteDistance; //Distance when the generator will start deleting pieces
    public Tile startile;
    public Transform player;

    private List<Chunk> instantiatedPieces = new List<Chunk>(); //Ordered list of tiles

    // Use this for initialization
    void Start () {
        Chunk startChunk = new Chunk(transform.position);
        for (int i = 0; i < Chunk.kChunkSize; i++)
        {
            Tile obj = Instantiate<Tile>(startile);
            startChunk.SetTile(i, obj);
        }
        instantiatedPieces.Add(startChunk);
	}
	
	// Update is called once per frame
	void Update () {

        //Check delete distance on first instantiated piece
        if (instantiatedPieces[0].DistanceTo(player.position) > deleteDistance)
        {
            instantiatedPieces[0].Discard();
            instantiatedPieces.RemoveAt(0);
        }

        //Check generation distance on the latest piece
        if (instantiatedPieces[instantiatedPieces.Count - 1].DistanceTo(player.position) < generationDistance)
        {
            Chunk currentTile = instantiatedPieces[instantiatedPieces.Count - 1];
            Chunk newChunk = new Chunk(currentTile.StartPos + new Vector3(0, 0, 1));
            instantiatedPieces.Add(newChunk);
            for (int i = 0; i < newChunk.tiles.Length; i++)
            {
                Tile t = Tile.CreateTile(PickRandomPossibleTile(currentTile.tiles[i]));
                newChunk.SetTile(i, t);
            }
        }
    }


    private Tile PickRandomPossibleTile(Tile currentTile)
    {
        int index = Random.Range(0, currentTile.possibleTiles.Count);
        return currentTile.possibleTiles[index];
    }

    public List<Tile> GetTiles()
    {
        return null;
    }
}
