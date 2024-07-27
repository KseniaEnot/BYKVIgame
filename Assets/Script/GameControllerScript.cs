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
    public UnityEvent<bool, String, MiniGame> getInteractButtonUI;
    public int difficulte { get; private set; }

    private List<int> charGame;
    [SerializeField] private UIController uIController;
    [SerializeField] private CharacterController characterController;

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
        charGame = new List<int>();
        difficulte = 1;
    }

    public void offPlayerMove() => characterController.canMove = false;
    public void onPlayerMove() => characterController.canMove = true;

    public void upChar(gameParams index, int score) => charGame[((int)index)] += score;
    public void spawnDebug()
    {
        Debug.Log("Work!");
    }

    private void OnEnable()
    {
        getInteractButtonUI.AddListener(uIController.InterractUIBUtton);
    }

    private void OnDisable()
    {
        getInteractButtonUI.RemoveListener(uIController.InterractUIBUtton);
    }
}
