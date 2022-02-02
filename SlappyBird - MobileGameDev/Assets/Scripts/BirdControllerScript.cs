using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdControllerScript : MonoBehaviour
{
    private bool isDead = false;
    private Rigidbody2D birdRB;
    private float UpwardsYeetPower = 200f;
    private Animator animator;
    private int lives = 3;
    private SpriteRenderer spriteRenderer;
    private PolygonCollider2D polyCollider2D;

    // Start is called before the first frame update
    void Start()
    {
        birdRB = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
        polyCollider2D = this.gameObject.GetComponent<PolygonCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isDead == false)
        {
            if(Input.GetButtonDown("Flap"))
            {
                birdRB.velocity = Vector2.zero;
                birdRB.AddForce(new Vector2(0, UpwardsYeetPower));
                animator.SetTrigger("Flap");
            }
        }
    }

    IEnumerator OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "noKill")
        {
            yield break;
        }
        else //the oof go down
        {
            lives--;
            spriteRenderer.color = Color.red;
            polyCollider2D.enabled = false;
            yield return new WaitForSeconds(2f); //Give the player a break
            polyCollider2D.enabled = true; //Turn on column colliders
            spriteRenderer.color = Color.white;
        }
        if(lives <= 0)
        {
            isDead = true;
            polyCollider2D.enabled = true;
            birdRB.velocity = Vector2.zero;
            animator.SetTrigger("Die");
            GameManagerScript.instance.BirdDied();
        }
    }
}
