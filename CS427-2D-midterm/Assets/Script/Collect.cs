using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collect : MonoBehaviour
{
    private Animation anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.tag == "Collection")
        {
            // collision.gameObject.SendMessage("Dead", F);
            Destroy(collision.gameObject);
            scoreScript.scoreValue += 2;
        }

        if (collision.gameObject.tag == "enemy")
        {
            
        }
    }
}