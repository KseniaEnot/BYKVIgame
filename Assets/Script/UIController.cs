using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class UIController : MonoBehaviour
{
    [SerializeField] private TMP_Text buttonText;
    [SerializeField] private GameObject buttonGameObject;
    [SerializeField] private Button buttonButton;

    [SerializeField]
    [Header("Чистота, популярность, ?актуальность?")]
    private List<GameObject> uiMiniGame;

    private void Awake()
    {
        buttonGameObject.SetActive(false);
    }

    public void InterractUIBUtton(bool isActive, MiniGame game, String _buttonText = "")
    {
        buttonGameObject.SetActive(isActive);
        if (isActive) buttonButton.onClick.AddListener(() => { game.gameStart(); gameUIstart(game.par, game); });
        else buttonButton.onClick.RemoveListener(() => { game.gameStart(); gameUIstart(game.par, game); });
        buttonText.text = _buttonText;
    }

    public void gameUIstart(gameParams gameIndex, MiniGame game)
    {
        InterractUIBUtton(false, game);
        uiMiniGame[(int)gameIndex].SetActive(true);
    }

    public void gameUIend(gameParams gameIndex)
    {
        uiMiniGame[(int)gameIndex].SetActive(false);
    }
}
