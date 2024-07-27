using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
//using System;

public class MiniGame_WaterFlowers : MiniGame
{
    [SerializeField] private int wight;
    [SerializeField] private Slider slider;
    [SerializeField] private RectTransform fillTransform;
    [SerializeField] private RectTransform fullTransform;

    private int dir;
    [SerializeField]
    [Range(0, 1)]
    private float speed;
    private float needSliderPosL;
    private float needSliderPosR;

    private void Awake()
    {
        par = gameParams.Clean;
    }
    private void Update()
    {
        if (isGameStatr)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                checkEndGame();
            }
            slider.value += dir * speed;
            if ((slider.value + (dir * speed)) > 1 || (slider.value + (dir * speed)) < 0) dir *= -1;
        }
    }

    private void checkEndGame()
    {
        if (needSliderPosL <= slider.value && slider.value <= needSliderPosR)
        {
            gameScore = 1;
        }
        else
        {
            gameScore = 0;
        }
        gameEnd();
    }

    public override void gameStart()
    {
        base.gameStart();
        Debug.Log("GameStart");
        wight = wight / difficulte;
        float pos = Random.Range(0, (fullTransform.offsetMax.x * 2 - wight));
        needSliderPosL = pos / (fullTransform.offsetMax.x * 2);
        needSliderPosR = (pos + wight) / (fullTransform.offsetMax.x * 2);
        Debug.Log("needRange " + needSliderPosL + " " + needSliderPosR);
        slider.value = 0;
        dir = 1;
        fillTransform.offsetMin = new Vector2(pos, fillTransform.offsetMin.y);
        fillTransform.offsetMax = new Vector2(pos + wight, fillTransform.offsetMax.y);
    }

    public override void gameEnd()
    {
        base.gameEnd();
    }
}
