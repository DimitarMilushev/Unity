using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField]
    float speed;

    float radius;
    Vector2 direction;
    // Start is called before the first frame update
    void Start()
    {
        speed = 10f;
        direction = Vector2.one.normalized; //direction is (1,1) normalized
        radius = transform.localScale.x / 2;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);

        if(transform.position.y < GameManager.bottomLeft.y + radius && direction.y < 0)
        {
            direction.y *= -1;
        }
        if(transform.position.y > GameManager.topRight.y - radius && direction.y > 0)
        {
            direction.y *= -1;
        }
        if (transform.position.x < GameManager.bottomLeft.x + radius && direction.x < 0)
        {
            Debug.Log("Left player wins!");
            //Stop script
            enabled = false;
        }

        if(transform.position.x > GameManager.topRight.x - radius && direction.x > 0)
        {
            Debug.Log("Left player wins!");
            enabled = false;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Paddle")
        {
            bool isRight = collision.GetComponent<Paddle>().isRight; 

            if(isRight && direction.x > 0)
            {
                direction.x *= -1;
            }

            if(!isRight && direction.x < 0)
            {
                direction.x *= -1;
            }
        }
    }
}
