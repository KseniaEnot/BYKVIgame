using UnityEngine.UI;
using UnityEngine;
//using System;

public class MiniGame_WaterFlowers : MiniGame
{
    [SerializeField] private int wight;
    [SerializeField] private Slider slider;
    [SerializeField] private RectTransform fillTransform;
    [SerializeField] private RectTransform fullTransform;

    private void Awake()
    {
        par = gameParams.Clean;
    }
    private void Update()
    {
        if (isGameStatr)
        {

        }
    }

    public override void gameStart()
    {
        Debug.Log("GameStart");
        base.gameStart();
        wight = wight / difficulte;
        float pos = Random.Range(0, (fullTransform.offsetMax.x * 2 - wight));
        Debug.Log(fullTransform.offsetMax.x);
        Debug.Log(fullTransform.offsetMin.x);
        Debug.Log(pos);
        Debug.Log(pos + wight);
        fillTransform.offsetMin = new Vector2(pos, fillTransform.offsetMin.y);
        fillTransform.offsetMax = new Vector2(pos + wight, fillTransform.offsetMax.y);
    }

    public override void gameEnd()
    {
        base.gameEnd();
    }
}
