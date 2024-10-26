using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopGame : MiniGame
{
    private void Awake()
    {
        par = gameParams.Money;
    }

    public override void gameStart()
    {
        base.gameStart();
        Debug.Log("Start Shop Game");
        //действие
    }

    public override void gameEnd()
    {
        //действие
        Debug.Log("End Shop Game");
        base.gameEnd();
    }

    private void Update()
    {
        if (isGameStatr)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                //заглужка конец игры при нажатии пробел
                gameEnd();
            }
        }
    }

}
