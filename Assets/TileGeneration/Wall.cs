using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{

    static List<Wall> objectPool = new List<Wall>();

    public Vector3 endPos; //Where the tile ends for the next one to start

    public static Wall CreateWall(Wall wall, Vector3 position, Quaternion rotation)
    {
        for (int i = 0; i < objectPool.Count; i++)
        {
            if (objectPool[i].tag == wall.tag)
            {
                Wall newWall = objectPool[i];
                objectPool.RemoveAt(i);
                newWall.gameObject.SetActive(true);
                newWall.transform.position = position;
                newWall.transform.rotation = rotation;
                return newWall;

            }
        }
        return Instantiate<Wall>(wall, position, rotation);
    }

    public void DestroyWall()
    {
        gameObject.SetActive(false);
        objectPool.Add(this);
    }
}
