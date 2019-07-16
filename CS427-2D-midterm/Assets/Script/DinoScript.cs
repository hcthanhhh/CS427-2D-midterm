using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoScript : MonoBehaviour
{
    public float upForce = 200f;
    public float moveForce = 0.1f;

    private bool isDead = false;
    private Rigidbody2D rb2d;
    private Animator anim;

    Vector2 newPos;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        newPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float y = rb2d.velocity.y;
        if (!isDead)
        {
            rb2d.velocity = new Vector2(0.1f, y);
            if (Input.GetKeyDown(KeyCode.UpArrow) && (y == 0))
            {
                rb2d.velocity = Vector2.zero;
                rb2d.AddForce(new Vector2(0, upForce));
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                anim.SetTrigger("Fire");
            }
        }
        Debug.Log(anim.GetCurrentAnimatorStateInfo(0).IsName("SpitFireMotion"));
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.tag == "Collection")
        {
            // collision.gameObject.SendMessage("Dead", F);
            Destroy(collision.gameObject);
            scoreScript.scoreValue += 2;
        }

        if (collision.gameObject.tag == "Enemy")
        {
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("SpitFireMotion"))
            {
                collision.gameObject.SetActive(false);
                scoreScript.scoreValue += 3;
            }
            else
            {
                isDead = true;
                rb2d.velocity = new Vector2(0.1f, 0);
                GameController.instance.DinoDied();
            }
        }
    }
}
