using System;
using UnityEngine.Events;
using UnityEngine;

public class MiniGame : MonoBehaviour
{
    [SerializeField] private String nameInteraction;
    public UnityEvent GameEnd;
    public UnityEvent GameStart;
    protected int gameScore;
    protected int difficulte;
    protected bool isGameStatr;
    public gameParams par { get; protected set; }
    private void Awake()
    {
        gameScore = 0;
        isGameStatr = false;
    }
    public virtual void gameStart()
    {
        GameControllerScript.instance.offPlayerMove();
        difficulte = GameControllerScript.instance.difficulte;
        isGameStatr = true;
        gameScore = 0;
        GameStart.Invoke();
    }

    public virtual void gameEnd()
    {
        GameControllerScript.instance.upChar(par, gameScore);
        GameControllerScript.instance.onPlayerMove();
        GameControllerScript.instance.getUIgameEnd.Invoke(par);
        isGameStatr = false;
        GameEnd.Invoke();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
            GameControllerScript.instance.getInteractButtonUI.Invoke(true, this, nameInteraction);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
            GameControllerScript.instance.getInteractButtonUI.Invoke(false, this, nameInteraction);
    }
}
