using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb2d;

    public float maxHeight;
    public float flapVelocity;

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
            Flap();
        }

    }

    public void Flap()
    {
        rb2d.velocity = new Vector2(0.0f, flapVelocity);
    }

}
