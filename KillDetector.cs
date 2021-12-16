using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillDetector : MonoBehaviour
{
    public string killer;
    public float dJump;
    public GameObject mester;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D co)
    {
      if(co.gameObject.tag == "Player")
      {
          killer=co.gameObject.tag;
          co.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f,dJump),ForceMode2D.Impulse);
          MaskedEnemie.call.PulonaCabe();
          Destroy(mester,1);
      }
    }
}
