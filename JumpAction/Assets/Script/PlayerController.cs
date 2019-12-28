using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb2d;

    public float maxHeight;
    public float flapVelocity;
    int Ccount = 0;
    int redCount = 0;
    int blueCount = 0;
    int greenCount = 0;
    int healCount = 0;
    float flyTime = 0.0f;
    bool fly ;
    int value;



    // Start is called before the first frame update
    void Start()
    {
        fly = true;
        value = Random.Range(0, 3);
        if(value == 0)
        {
            gameObject.GetComponent<Renderer>().material.color = Color.red;
        }
        else if(value == 1)
        {
            gameObject.GetComponent<Renderer>().material.color = Color.blue;
        }
        else if(value == 2)
        {
            gameObject.GetComponent<Renderer>().material.color = Color.green;
        }
    }

    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 tmp = GameObject.Find("Player").transform.position;
        if (fly)
        {
            flyTime += Time.deltaTime;
            GameManager.instance.setPlayerFlyTime(flyTime);
        }

        if(tmp.x <= -3.5 || tmp.y <= -5.5)
        {
            SceneManager.LoadScene("Result");
        }
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
            Debug.Log("aaa");
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
        else if (col.gameObject.tag == "HealItem")
        {
            Destroy(col.gameObject);
            healCount = GameManager.instance.getHealItemCount();
            healCount++;
            GameManager.instance.setHealItemCount(healCount);
        }
    }

    void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.tag == "Block")
        {
            fly = false;
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "Block")
        {
            fly = true;
        }
    }
}
