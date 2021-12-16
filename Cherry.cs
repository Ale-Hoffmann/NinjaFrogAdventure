using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cherry : MonoBehaviour
{
    private SpriteRenderer sr;
    private BoxCollider2D cir;
    public GameObject collected;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        cir = GetComponent<BoxCollider2D>();
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            sr.enabled = false;
            cir.enabled = false;
            collected.SetActive(true);
            

            Destroy(gameObject, 0.25f);
        }
    }
    // Update is called once per frame
    void Update()
    {
       
    }
}
