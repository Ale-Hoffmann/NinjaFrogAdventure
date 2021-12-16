using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private BoxCollider2D box;
    private Animator anim;
    
    void Start()
    {
        box=GetComponent<BoxCollider2D>();
        anim=GetComponent<Animator>();
    }

   
    void Update()
    {
        
    }
    
    void OnTriggerEnter2D(Collider2D collider)
    {
         if(collider.gameObject.tag == "Player")
         {
          anim.SetBool("gotcha",true);
          GameController.insta.NextLevel();
         }
    }
}
