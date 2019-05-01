using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Paddle paddle;
    public Ball ball;

    public static Vector2 bottomLeft;
    public static Vector2 topRight;
    // Start is called before the first frame update
    void Start()
    {
        //Convert   screens pixel coordinate into games coordinate
        bottomLeft = Camera.main.ScreenToWorldPoint ( new Vector2 (0, 0));
        topRight = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));


        Instantiate(ball);
        Paddle player1 = Instantiate(paddle) as Paddle;
        Paddle player2 = Instantiate(paddle) as Paddle;
        player1.Init(true);
        player2.Init(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
