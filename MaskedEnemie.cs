using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaskedEnemie : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator ani;
    public float speed;
    public Transform KillDetector;
    public float moveTime;
    private string TopHeadCont;
    private float timer;
    private bool directionR;
    public static MaskedEnemie call;
    
    
    private bool colliding;

    void Start()
    {
        call = this;
        
        ani= GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
    
         if(directionR)
        {
            // se verdadeiro a serra vai para a direita
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            transform.eulerAngles= new Vector3 (0f,0f,0f);
        }
        else
        {
            // se falso a serra vai para a esquerda
            transform.Translate(Vector2.right * speed * Time.deltaTime);
             transform.eulerAngles= new Vector3 (0f,180f,0f);
        }
        
        timer += Time.deltaTime;
        if (timer >= moveTime)
        {
            directionR= !directionR;
            timer=0f;
        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Player")
        {
        float height = col.contacts[0].point.y - KillDetector.position.y;
        
       
        } 
        
    }
    public void PulonaCabe()
    {
    
            ani.SetBool("dead",true);
            
    
    }
}
