using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float moveSpeed = 5f;
    public Transform movePoint;
    // Start is called before the first frame update
    void Start()
    {
        movePoint.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        if( Mathf.Abs(Input.GetAxisRaw("Horizontal")) == -1f)
        {
            movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
        }        

        if( Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f)
        {
            movePoint.position += new Vector3(Input.GetAxisRaw("Vertical"), 0f, 0f);
        }
    }
}
