using Assets.Scripts.Tiles;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileGenerator : MonoBehaviour
{


    public float generationDistance; //Distance the generator will generate to
    public float deleteDistance; //Distance when the generator will start deleting pieces
    public Tile startile;

    private System.Random m_RandomGen;

    public Transform player;

    private List<Tile> instantiatedPieces = new List<Tile>(); //Ordered list of tiles

    // Use this for initialization
    void Start()
    {
        instantiatedPieces.Add(Tile.CreateTile(startile, startile.transform.position, startile.transform.rotation));
    }

    // Update is called once per frame
    void Update()
    {

        if (instantiatedPieces.Count > 0)
        {
            //Check delete distance on first instantiated piece
            if (Vector3.Distance(instantiatedPieces[0].transform.position, player.position) > deleteDistance)
            {
                instantiatedPieces[0].DestroyTile();
                instantiatedPieces.RemoveAt(0);
            }

            //Check generation distance on the latest piece
            if (Vector3.Distance(instantiatedPieces[instantiatedPieces.Count - 1].transform.position, player.position) < generationDistance)
            {
                Tile currentTile = instantiatedPieces[instantiatedPieces.Count - 1];
                Tile newTile = PickRandomPossibleTile(currentTile);
                instantiatedPieces.Add(Tile.CreateTile(newTile, currentTile.transform.position + currentTile.endPos, newTile.transform.rotation));
            }
        }

    }


    private Tile PickRandomPossibleTile(Tile currentTile)
    {
        int index = Random.Range(0, currentTile.possibleTiles.Count - 1);
        return currentTile.possibleTiles[index];
    }

    public List<Tile> GetTiles()
    {
        return null;
    }

}