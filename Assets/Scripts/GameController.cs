using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using System.Linq;
public class GameController : MonoBehaviour
{
    List<GameObject> zombies = new List<GameObject>();
    public Player player;
    public bool gameRunning = true;
    public Tilemap tilemap;
    public GameObject zombiePrefab;
    public int minX, minY, maxY, maxX;
    public int maxZombies = 10;
  
    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        if (player.health <= 0)
        {
            gameRunning = false;
        }
        if (!gameRunning)
        {
            return;
        }
        if (zombies.Count<maxZombies)
        {

            SpawnZombie();

        }

    }
    public void RestartGame()
    {
        gameRunning = true;
        player.health = 100;
        player.spriteRenderer.enabled = true;
        KillAllZombies();
    }

    void SpawnZombie()
    {

        BoundsInt bounds = tilemap.cellBounds;
        //Debug.Log(bounds.ToString());
        minX = bounds.x;
        minY = bounds.y;
        maxX = bounds.xMax;
        maxY = bounds.yMax;
        int randomX = Random.Range(minX, maxX);
        //Debug.Log(RandomX);
        int randomY = Random.Range(minY, maxY);
        Vector3Int position = new Vector3Int(randomX, randomY, 0);
        TileBase tile = tilemap.GetTile(position);
        if (tile != null)
        {

            var zombie = Instantiate(zombiePrefab, position, Quaternion.identity);
            zombies.Add(zombie);
        }
        

    }
        public void KillZombie(GameObject zombie)
        {
        zombies.Remove(zombie);
        Destroy(zombie);
        }
        void KillAllZombies()
        {
         while (zombies.Count > 0)
         {
            KillZombie(zombies[0]);
         }

        
        }
}       
