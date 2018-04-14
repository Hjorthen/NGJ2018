using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileGenerator : MonoBehaviour {


    public float generationDistance; //Distance the generator will generate to
    public float deleteDistance; //Distance when the generator will start deleting pieces
    public Tile startile;

    private List<Tile> instantiatedPieces = new List<Tile>(); //Ordered list of tiles


    // Use this for initialization
    void Start () {
        instantiatedPieces.Add(Instantiate<Tile>(startile));
	}
	
	// Update is called once per frame
	void Update () {

        //Check delete distance on first instantiated piece
        if (Vector3.Distance(transform.position, instantiatedPieces[0].transform.position) > deleteDistance)
        {
            instantiatedPieces[0].DestroyTile();
            instantiatedPieces.RemoveAt(0);
        }

        //Check generation distance on the latest piece
        if (Vector3.Distance(transform.position, instantiatedPieces[instantiatedPieces.Count - 1].transform.position) < generationDistance)
        {
            Tile currentTile = instantiatedPieces[instantiatedPieces.Count - 1];
            instantiatedPieces.Add(Tile.CreateTile(PickRandomPossibleTile(currentTile), currentTile.transform.position + currentTile.endPos, currentTile.transform.rotation));
        }
    }


    private Tile PickRandomPossibleTile(Tile currentTile)
    {
        int index = Random.Range(0, currentTile.possibleTiles.Count);
        return currentTile.possibleTiles[index];
    }

    public List<Tile> GetTiles()
    {
        return instantiatedPieces;
    }
}
