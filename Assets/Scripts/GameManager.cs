using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] GameObject Player;
    [SerializeField] GameObject Tile;
    [SerializeField] GameObject Obstacle;
    [SerializeField] GameObject Food;
    [SerializeField] GameObject Enemy;
    IAstarAI[] astarAIs;
    Camera mainCam;

    // Start is called before the first frame update
    void Start()
    {
        astarAIs = FindObjectsOfType<MonoBehaviour>().OfType<IAstarAI>().ToArray();
        mainCam = Camera.main;
        GridManager.CreateGrid(30, 30, Tile);
        //Player.transform.position = GridManager.getSpawnLocation();
        SpawnEnemy();
    }

    public void SpawnEnemy()
    {
        GridManager.SpawnerEnemy(Enemy, Player);
    }

    // Update is called once per frame
    void Update()
    {
        AstarPath.active.Scan();
    }
}
