using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour
{
private Animator anima;

public float forceJump;
 
void Start()
{
    anima=GetComponent<Animator>();
}


    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f,forceJump),ForceMode2D.Impulse);
            anima.SetTrigger("Jump");
        }
    }
    
}
