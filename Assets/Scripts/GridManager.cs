using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    private static int Width;
    private static int Height;

    private static Dictionary<Vector2Int, GameObject> _tiles = new Dictionary<Vector2Int, GameObject>();
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
                _tiles.Add(new Vector2Int(x - offset, y - offset), tile);
            }
        }
        AstarPath.active.Scan();
    }

    public static bool isTileAvailable(Vector3 position)
    {
        return _tiles.ContainsKey(new Vector2Int((int)position.x, (int)position.y)) &&
            !_tiles[new Vector2Int((int)position.x, (int)position.y)].GetComponent<Tile>().isObstacle();
    }

    public static Vector3 getSpawnLocation()
    {
        while (true)
        {
            int x = Mathf.FloorToInt(Random.Range(0, Width - 1));
            int y = Mathf.FloorToInt(Random.Range(0, Height - 1));
            GameObject RandomTile = _tiles[new Vector2Int(x, y)];
            if (!RandomTile.GetComponent<Tile>().isObstacle())
            {
                return new Vector3(x, y);
            }
        }
    }
}