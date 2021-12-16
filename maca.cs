using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class maca : MonoBehaviour
{
     private SpriteRenderer sr;
   private CircleCollider2D cir;
   public GameObject collected;
   public int Score;
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        cir = GetComponent<CircleCollider2D>();
    }

   
    void OnTriggerEnter2D(Collider2D collider)
    {
         if(collider.gameObject.tag == "Player")
       {
           sr.enabled = false;
           cir.enabled = false;
           collected.SetActive(true);

           GameController.insta.totalScore += Score;
           GameController.insta.UpdateScoreText();
            

          Destroy(gameObject, 0.25f);
       }
    }
  

  
}
