using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public List<GameObject> WayPointList = new List<GameObject>();
    public int LocationPoint = 0;

    public static bool Start_Moving = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Start_Moving)
        {
            if (LocationPoint != 10)
            {
                if (this.gameObject.transform.position != WayPointList[LocationPoint].transform.position)
                {
                    this.gameObject.GetComponent<AIDestinationSetter>().target = WayPointList[LocationPoint].transform;
                }
                else
                {
                    LocationPoint++;
                }
            }
        }
    }
}

