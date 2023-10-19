using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GameController : MonoBehaviour
{
    public Tilemap tilemap;
    public GameObject zombiePrefab;
    public int minX, minY, maxY, maxX;

    // Start is called before the first frame update
    void Start()
    {
        BoundsInt bounds = tilemap.cellBounds;
        //Debug.Log(bounds.ToString());
        minX = bounds.x;
        minY = bounds.y;
        maxX = bounds.xMax;
        maxY = bounds.yMax;
        float RandomX = Random.Range(minX, maxX);
        Debug.Log(RandomX);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
