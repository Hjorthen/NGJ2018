using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Tiles
{
    struct Chunk
    {
        public Vector3 StartPos;
        private static Vector3 m_TileOffsets = new Vector3(1, 0, 0);
        public const int kChunkSize = 1;
        public Tile[] tiles;
        public Chunk(Vector3 startPos)
        {
            tiles = new Tile[kChunkSize];
            StartPos = startPos;
        }
        
        public float DistanceTo(Vector3 position)
        {
            return Vector3.Distance(position, StartPos);
        }

        public void SetTile(int index, Tile t)
        {
            tiles[index] = t;
            t.transform.position = StartPos + m_TileOffsets * index;
        }

        public void Discard()
        {
            for (int i = 0; i < tiles.Length; i++)
            {
                tiles[i].DestroyTile();
            }
        }
    }
}
