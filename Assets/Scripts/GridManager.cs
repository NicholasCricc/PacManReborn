using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    private static int Width;
    private static int Height;



    //public GameObject myEnemyPrefab;

    public static Dictionary<Vector2Int, GameObject> Key = new Dictionary<Vector2Int, GameObject>();
    public static void CreateGrid(int width, int height, GameObject TilePrefab)
    {
        Width = width;
        Height = height;
        int offset = (width / 2) - 1;
        //Looping through all the x coords
        for (int x = 0; x < width; x++)
        {
            //Looping through all the y coords
            for (int y = 0; y < height; y++)
            {
                //Instantiating a tile
                GameObject tile = Instantiate(TilePrefab, new Vector3(x - offset, y - offset), Quaternion.identity);
                tile.GetComponent<Tile>().setObstacle(Random.Range(1, 10) < 3);
                Key.Add(new Vector2Int(x - offset, y - offset), tile);
            }
        }
        AstarPath.active.Scan();
    }

    public static bool isTileAvailable(Vector3 position)
    {
        return Key.ContainsKey(new Vector2Int((int)position.x, (int)position.y)) &&
            !Key[new Vector2Int((int)position.x, (int)position.y)].GetComponent<Tile>().isObstacle();
    }

    public static Vector3 getSpawnLocation()
    {
        while (true)
        {
            int x = Mathf.FloorToInt(Random.Range(0, Width - 1));
            int y = Mathf.FloorToInt(Random.Range(0, Height - 1));
            GameObject RandomTile = Key[new Vector2Int(x, y)];
            if (!RandomTile.GetComponent<Tile>().isObstacle())
            {
                return new Vector3(x, y);
            }
        }
    }

    public static void SpawnerEnemy(GameObject Enemy_object)
    {
        float offset = (GridManager.Width / 2) - 0.5f;
        GameObject enemyObject;
        GameObject enemyObject2;


        while (true)
        {
            int random_x = Mathf.FloorToInt(Random.Range(1, 29));
            int random_y = Mathf.FloorToInt(Random.Range(11, 29));

            GameObject enemy_Position = Key[new Vector2Int(random_x - (int)offset, random_y - (int)offset)];
            GameObject enemy_Position2 = Key[new Vector2Int(random_x + 1 - (int)offset, random_y - (int)offset)];
            GameObject enemy_Position3 = Key[new Vector2Int(random_x - (int)offset, random_y + 1 - (int)offset)];
            GameObject enemy_Position4 = Key[new Vector2Int(random_x + 1 - (int)offset, random_y + 1 - (int)offset)];

            if (!enemy_Position.GetComponent<Tile>().isObstacle() && !enemy_Position2.GetComponent<Tile>().isObstacle() && !enemy_Position3.GetComponent<Tile>().isObstacle()
                && !enemy_Position4.GetComponent<Tile>().isObstacle() && !enemy_Position.GetComponent<Tile>().isPlayer() && !enemy_Position2.GetComponent<Tile>().isPlayer() && !enemy_Position3.GetComponent<Tile>().isPlayer()
                && !enemy_Position4.GetComponent<Tile>().isPlayer()) // do food
            {
                enemyObject = Instantiate(Enemy_object, enemy_Position.transform.position, Quaternion.identity);
                enemy_Position.GetComponent<Tile>().setEnemy(true);
                enemy_Position2.GetComponent<Tile>().setEnemy(true);
                enemy_Position3.GetComponent<Tile>().setEnemy(true);
                enemy_Position4.GetComponent<Tile>().setEnemy(true);
                break;
            }
        }

        //enemyObject.GetComponent<Enemy>().WayPointList = new List<GameObject>();

        while (true)
        {
            int random_x = Mathf.FloorToInt(Random.Range(1, 29));
            int random_y = Mathf.FloorToInt(Random.Range(11, 29));

            GameObject enemy_Position = Key[new Vector2Int(random_x - (int)offset, random_y - (int)offset)];
            GameObject enemy_Position2 = Key[new Vector2Int(random_x + 1 - (int)offset, random_y - (int)offset)];
            GameObject enemy_Position3 = Key[new Vector2Int(random_x - (int)offset, random_y + 1 - (int)offset)];
            GameObject enemy_Position4 = Key[new Vector2Int(random_x + 1 - (int)offset, random_y + 1 - (int)offset)];

            if (!enemy_Position.GetComponent<Tile>().isObstacle() && !enemy_Position2.GetComponent<Tile>().isObstacle() && !enemy_Position3.GetComponent<Tile>().isObstacle()
                && !enemy_Position4.GetComponent<Tile>().isObstacle() && !enemy_Position.GetComponent<Tile>().isPlayer() && !enemy_Position2.GetComponent<Tile>().isPlayer() && !enemy_Position3.GetComponent<Tile>().isPlayer()
                && !enemy_Position4.GetComponent<Tile>().isPlayer())
            {
                enemyObject2 = Instantiate(Enemy_object, enemy_Position.transform.position, Quaternion.identity);
                enemy_Position.GetComponent<Tile>().setEnemy(true);
                enemy_Position2.GetComponent<Tile>().setEnemy(true);
                enemy_Position3.GetComponent<Tile>().setEnemy(true);
                enemy_Position4.GetComponent<Tile>().setEnemy(true);
                break;
            }
        }

        
        //enemyObject2.GetComponent<Enemy>().WayPointList = new List<GameObject>();

        AstarPath.active.Scan();

    }

    public static void PlayerSpawn(GameObject PlayerObject)
    {
        float offset = (GridManager.Width / 2) - 0.5f;
        GameObject playerObject;


        while (true)
        {
            int random_x = Mathf.FloorToInt(Random.Range(1, 29));
            int random_y = Mathf.FloorToInt(Random.Range(11, 29));


            GameObject player_Position = Key[new Vector2Int(random_x - (int)offset, random_y - (int)offset)];
            GameObject player_Position2 = Key[new Vector2Int(random_x + 1 - (int)offset, random_y - (int)offset)];
            GameObject player_Position3 = Key[new Vector2Int(random_x - (int)offset, random_y + 1 - (int)offset)];
            GameObject player_Position4 = Key[new Vector2Int(random_x + 1 - (int)offset, random_y + 1 - (int)offset)];

            if (!player_Position.GetComponent<Tile>().isEnemy() && !player_Position2.GetComponent<Tile>().isEnemy() && !player_Position3.GetComponent<Tile>().isEnemy() && !player_Position4.GetComponent<Tile>().isEnemy()
                && !player_Position.GetComponent<Tile>().isObstacle() && !player_Position2.GetComponent<Tile>().isObstacle() && !player_Position3.GetComponent<Tile>().isObstacle() && !player_Position4.GetComponent<Tile>().isObstacle())
            {
                playerObject = Instantiate(PlayerObject, player_Position.transform.position, Quaternion.identity);
                player_Position.GetComponent<Tile>().setPlayer(true);
                player_Position2.GetComponent<Tile>().setPlayer(true);
                player_Position3.GetComponent<Tile>().setPlayer(true);
                player_Position4.GetComponent<Tile>().setPlayer(true);
                break;
            }
        }

        //playerObject.GetComponent<Enemy>().WayPointList = new List<GameObject>();

        AstarPath.active.Scan();
    }

    public static void FoodSpawn_5(GameObject FoodObject)
    {
        float offset = (GridManager.Width / 2) - 0.5f;
        GameObject foodObject;


        while (true)
        {
            int random_x = Mathf.FloorToInt(Random.Range(1, 29));
            int random_y = Mathf.FloorToInt(Random.Range(11, 29));

            GameObject food_Position = Key[new Vector2Int(random_x - (int)offset, random_y - (int)offset)];
            GameObject food_Position2 = Key[new Vector2Int(random_x + 1 - (int)offset, random_y - (int)offset)];
            GameObject food_Position3 = Key[new Vector2Int(random_x - (int)offset, random_y + 1 - (int)offset)];
            GameObject food_Position4 = Key[new Vector2Int(random_x + 1 - (int)offset, random_y + 1 - (int)offset)];

            if (!food_Position.GetComponent<Tile>().isObstacle() && !food_Position2.GetComponent<Tile>().isObstacle() && !food_Position3.GetComponent<Tile>().isObstacle()
                && !food_Position4.GetComponent<Tile>().isObstacle() && !food_Position.GetComponent<Tile>().isPlayer() && !food_Position2.GetComponent<Tile>().isPlayer() && !food_Position3.GetComponent<Tile>().isPlayer()
                && !food_Position4.GetComponent<Tile>().isPlayer() && !food_Position.GetComponent<Tile>().isEnemy() && !food_Position2.GetComponent<Tile>().isEnemy() && !food_Position3.GetComponent<Tile>().isEnemy()
                && !food_Position4.GetComponent<Tile>().isEnemy()) // do food
            {
                foodObject = Instantiate(FoodObject, food_Position.transform.position, Quaternion.identity);
                food_Position.GetComponent<Tile>().setEnemy(true);
                food_Position2.GetComponent<Tile>().setEnemy(true);
                food_Position3.GetComponent<Tile>().setEnemy(true);
                food_Position4.GetComponent<Tile>().setEnemy(true);
                break;
            }
        }
        AstarPath.active.Scan();
    }

    public static void FoodSpawn_10(GameObject FoodObject)
    {
        float offset = (GridManager.Width / 2) - 0.5f;
        GameObject foodObject;


        while (true)
        {
            int random_x = Mathf.FloorToInt(Random.Range(1, 29));
            int random_y = Mathf.FloorToInt(Random.Range(11, 29));

            GameObject food_Position = Key[new Vector2Int(random_x - (int)offset, random_y - (int)offset)];
            GameObject food_Position2 = Key[new Vector2Int(random_x + 1 - (int)offset, random_y - (int)offset)];
            GameObject food_Position3 = Key[new Vector2Int(random_x - (int)offset, random_y + 1 - (int)offset)];
            GameObject food_Position4 = Key[new Vector2Int(random_x + 1 - (int)offset, random_y + 1 - (int)offset)];

            if (!food_Position.GetComponent<Tile>().isObstacle() && !food_Position2.GetComponent<Tile>().isObstacle() && !food_Position3.GetComponent<Tile>().isObstacle()
                && !food_Position4.GetComponent<Tile>().isObstacle() && !food_Position.GetComponent<Tile>().isPlayer() && !food_Position2.GetComponent<Tile>().isPlayer() && !food_Position3.GetComponent<Tile>().isPlayer()
                && !food_Position4.GetComponent<Tile>().isPlayer() && !food_Position.GetComponent<Tile>().isEnemy() && !food_Position2.GetComponent<Tile>().isEnemy() && !food_Position3.GetComponent<Tile>().isEnemy()
                && !food_Position4.GetComponent<Tile>().isEnemy()) // do food
            {
                foodObject = Instantiate(FoodObject, food_Position.transform.position, Quaternion.identity);
                food_Position.GetComponent<Tile>().setEnemy(true);
                food_Position2.GetComponent<Tile>().setEnemy(true);
                food_Position3.GetComponent<Tile>().setEnemy(true);
                food_Position4.GetComponent<Tile>().setEnemy(true);
                break;
            }
        }
        AstarPath.active.Scan();
    }

    public static void FoodSpawn_15(GameObject FoodObject)
    {
        float offset = (GridManager.Width / 2) - 0.5f;
        GameObject foodObject;


        while (true)
        {
            int random_x = Mathf.FloorToInt(Random.Range(1, 29));
            int random_y = Mathf.FloorToInt(Random.Range(11, 29));

            GameObject food_Position = Key[new Vector2Int(random_x - (int)offset, random_y - (int)offset)];
            GameObject food_Position2 = Key[new Vector2Int(random_x + 1 - (int)offset, random_y - (int)offset)];
            GameObject food_Position3 = Key[new Vector2Int(random_x - (int)offset, random_y + 1 - (int)offset)];
            GameObject food_Position4 = Key[new Vector2Int(random_x + 1 - (int)offset, random_y + 1 - (int)offset)];

            if (!food_Position.GetComponent<Tile>().isObstacle() && !food_Position2.GetComponent<Tile>().isObstacle() && !food_Position3.GetComponent<Tile>().isObstacle()
                && !food_Position4.GetComponent<Tile>().isObstacle() && !food_Position.GetComponent<Tile>().isPlayer() && !food_Position2.GetComponent<Tile>().isPlayer() && !food_Position3.GetComponent<Tile>().isPlayer()
                && !food_Position4.GetComponent<Tile>().isPlayer() && !food_Position.GetComponent<Tile>().isEnemy() && !food_Position2.GetComponent<Tile>().isEnemy() && !food_Position3.GetComponent<Tile>().isEnemy()
                && !food_Position4.GetComponent<Tile>().isEnemy()) // do food
            {
                foodObject = Instantiate(FoodObject, food_Position.transform.position, Quaternion.identity);
                food_Position.GetComponent<Tile>().setEnemy(true);
                food_Position2.GetComponent<Tile>().setEnemy(true);
                food_Position3.GetComponent<Tile>().setEnemy(true);
                food_Position4.GetComponent<Tile>().setEnemy(true);
                break;
            }
        }
        AstarPath.active.Scan();
    }

    public static void FoodSpawn_20(GameObject FoodObject)
    {
        float offset = (GridManager.Width / 2) - 0.5f;
        GameObject foodObject;


        while (true)
        {
            int random_x = Mathf.FloorToInt(Random.Range(1, 29));
            int random_y = Mathf.FloorToInt(Random.Range(11, 29));

            GameObject food_Position = Key[new Vector2Int(random_x - (int)offset, random_y - (int)offset)];
            GameObject food_Position2 = Key[new Vector2Int(random_x + 1 - (int)offset, random_y - (int)offset)];
            GameObject food_Position3 = Key[new Vector2Int(random_x - (int)offset, random_y + 1 - (int)offset)];
            GameObject food_Position4 = Key[new Vector2Int(random_x + 1 - (int)offset, random_y + 1 - (int)offset)];

            if (!food_Position.GetComponent<Tile>().isObstacle() && !food_Position2.GetComponent<Tile>().isObstacle() && !food_Position3.GetComponent<Tile>().isObstacle()
                && !food_Position4.GetComponent<Tile>().isObstacle() && !food_Position.GetComponent<Tile>().isPlayer() && !food_Position2.GetComponent<Tile>().isPlayer() && !food_Position3.GetComponent<Tile>().isPlayer()
                && !food_Position4.GetComponent<Tile>().isPlayer() && !food_Position.GetComponent<Tile>().isEnemy() && !food_Position2.GetComponent<Tile>().isEnemy() && !food_Position3.GetComponent<Tile>().isEnemy()
                && !food_Position4.GetComponent<Tile>().isEnemy()) // do food
            {
                foodObject = Instantiate(FoodObject, food_Position.transform.position, Quaternion.identity);
                food_Position.GetComponent<Tile>().setEnemy(true);
                food_Position2.GetComponent<Tile>().setEnemy(true);
                food_Position3.GetComponent<Tile>().setEnemy(true);
                food_Position4.GetComponent<Tile>().setEnemy(true);
                break;
            }
        }
        AstarPath.active.Scan();
    }
    public static void Easy()
    {
        
    }
}