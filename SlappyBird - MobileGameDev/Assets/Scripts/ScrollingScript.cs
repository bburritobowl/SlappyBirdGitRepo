using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingScript : MonoBehaviour
{
    private Rigidbody2D groundRB;

    // Start is called before the first frame update
    void Start()
    {
        groundRB = GetComponent<Rigidbody2D>();
        groundRB.velocity = new Vector2(GameManagerScript.instance.bgScrollSpeed, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManagerScript.instance.gameOver == true)
        {
            groundRB.velocity = Vector2.zero;
        }
    }
}
