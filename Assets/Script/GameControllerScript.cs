using System;
using UnityEngine.Events;
using UnityEngine;
using System.Linq;
using System.Collections.Generic;

public enum gameParams
{
    Clean = 0,
    Popularit = 1,
    Rlevance = 2
}

public class GameControllerScript : MonoBehaviour
{
    public static GameControllerScript instance { get; private set; }
    public UnityEvent<bool, MiniGame, String> getInteractButtonUI;
    //public UnityEvent<gameParams, MiniGame> getUIgameStart;
    public UnityEvent<gameParams> getUIgameEnd;
    public int difficulte { get; private set; }

    private List<int> charGame;

    [SerializeField] private UIController uIController;
    [SerializeField] private CharacterMoveController characterController;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
        // init from file? prefs? anythyng????
        charGame = new List<int>() { 0, 0, 0 };
        difficulte = 1;
    }

    public void offPlayerMove() => characterController.canMove = false;
    public void onPlayerMove() => characterController.canMove = true;

    public void upChar(gameParams index, int score)
    {
        charGame[((int)index)] += score;
        Debug.Log(index + " " + charGame[((int)index)]);
    }
    public void spawnDebug()
    {
        Debug.Log("Work!");
    }

    private void OnEnable()
    {
        getInteractButtonUI.AddListener(uIController.InterractUIBUtton);
        //getUIgameStart.AddListener(uIController.gameUIstart);
        getUIgameEnd.AddListener(uIController.gameUIend);
    }

    private void OnDisable()
    {
        getInteractButtonUI.RemoveListener(uIController.InterractUIBUtton);
        //getUIgameStart.RemoveListener(uIController.gameUIstart);
        getUIgameEnd.RemoveListener(uIController.gameUIend);
    }
}
