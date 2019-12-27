using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb2d;

    public float maxHeight;
    public float flapVelocity;
    int Ccount = 0;
    int redCount = 0;
    int blueCount = 0;
    int greenCount = 0;

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

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "ColorItemRed")
        {
            Destroy(col.gameObject);
            redCount = GameManager.instance.getPlayerHaveRedCount();
            redCount++;
            GameManager.instance.setPlayerHaveRedCount(redCount);
        }
        else if (col.gameObject.tag == "ColorItemBlue")
        {
            Destroy(col.gameObject);
            blueCount = GameManager.instance.getPlayerHaveBlueCount();
            blueCount++;
            GameManager.instance.setPlayerHaveBlueCount(blueCount);
        }
        else if (col.gameObject.tag == "ColorItemGreen")
        {
            Destroy(col.gameObject);
            greenCount = GameManager.instance.getPlayerHaveGreenCount();
            greenCount++;
            GameManager.instance.setPlayerHaveGreenCount(greenCount);
        }
    }
}
