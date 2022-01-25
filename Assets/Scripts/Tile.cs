using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    private bool Obstacle = false;
    private bool Player = false;
    //private bool Food = false;
    private bool Enemy = false;

    public bool isObstacle()
    {
        return Obstacle;
    }
    public bool isPlayer()
    {
        return Player;
    }
    //public bool isFood()
    //{
    //    return Food;
    //}
    public bool isEnemy()
    {
        return Enemy;
    }

    private void Start()
    {
        //setObstaclecheck();
    }

    public void setObstacle(bool obstacle)
    {
        Obstacle = obstacle;
        this.gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = obstacle;
        this.gameObject.transform.GetChild(0).GetComponent<BoxCollider2D>().enabled = obstacle;
     
    }

    public void setObstaclecheck()
    {
        //this.gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = true;
        this.gameObject.transform.GetChild(0).GetComponent<BoxCollider2D>().enabled = true;

    }

    public void setPlayer(bool player)
    {
        Player = player;
    }

    //public void setFood(bool food)
    //{
    //    Food = food;
    //    this.gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = food;
    //    this.gameObject.transform.GetChild(0).GetComponent<BoxCollider2D>().enabled = food;
    //}

    public void setEnemy(bool enemy)
    {
        Enemy = enemy;
    }
}
