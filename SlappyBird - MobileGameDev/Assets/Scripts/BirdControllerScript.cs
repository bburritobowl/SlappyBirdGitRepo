using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdControllerScript : MonoBehaviour
{
    private bool isDead = false;
    private Rigidbody2D birdRB;
    private float UpwardsYeetPower = 200f;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        birdRB = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isDead == false)
        {
            if(Input.GetMouseButtonDown(0))
            {
                birdRB.velocity = Vector2.zero;
                birdRB.AddForce(new Vector2(0, UpwardsYeetPower));
                animator.SetTrigger("Flap");
            }
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "noKill")
        {
            return;
        }
        isDead = true;
        birdRB.velocity = Vector2.zero;
        animator.SetTrigger("Die");
        GameManagerScript.instance.BirdDied();
    }
}
