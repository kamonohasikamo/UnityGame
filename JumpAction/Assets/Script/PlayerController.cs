using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb2d;

    public float maxHeight;
    public float flapVelocity;
    int Ccount = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
       /* if(Input.GetButtonDown("Fire1") && transform.position.y < maxHeight)
        {
            Flap();
        }*/
    }

    public void onClickAct()
    {

        if (transform.position.y < maxHeight)
        {
           
                if (Ccount == 0)
                {
                    gameObject.GetComponent<Renderer>().material.color = Color.red;
                }else if(Ccount == 1)
                {
                    gameObject.GetComponent<Renderer>().material.color = Color.blue;
                }else if(Ccount == 2)
                {
                    gameObject.GetComponent<Renderer>().material.color = Color.green;
                }
            Ccount++;
            Ccount %= 3;
            Flap();
        }

    }

    public void Flap()
    {
        rb2d.velocity = new Vector2(0.0f, flapVelocity);
    }

}
