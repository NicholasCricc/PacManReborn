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
    [SerializeField] GameObject Food_5;
    [SerializeField] GameObject Food_10;
    [SerializeField] GameObject Food_15;
    [SerializeField] GameObject Food_20;
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
        SpawnPlayer();
        SpawnFood_5();
        SpawnFood_10();
        SpawnFood_15();
        SpawnFood_20();
        Clear();
    }

    public void Clear()
    {
        GridManager.Key.Clear(); 
    }

    public void SpawnEnemy()
    {
        GridManager.SpawnerEnemy(Enemy);
    }
    public void SpawnFood_5()
    {
        GridManager.FoodSpawn_5(Food_5);
    }

    public void SpawnFood_10()
    {
        GridManager.FoodSpawn_10(Food_10);
    }

    public void SpawnFood_15()
    {
        GridManager.FoodSpawn_15(Food_15);
    }

    public void SpawnFood_20()
    {
        GridManager.FoodSpawn_20(Food_20);
    }



    public void SpawnPlayer()
    {
        GridManager.PlayerSpawn(Player);
    }

    public void AttackPlayer()
    {
        //Enemy.Start_Moving = true;
    }

    // Update is called once per frame
    void Update()
    {
        AstarPath.active.Scan();
    }
}
