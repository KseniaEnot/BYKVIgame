using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private TMP_Text buttonText;
    [SerializeField] private GameObject buttonGameObject;
    [SerializeField] private Button buttonButton;
    [SerializeField] private GameObject gamePanelObject;

    private void Awake()
    {
        buttonGameObject.SetActive(false);
        gamePanelObject.SetActive(false);
    }

    public void InterractUIBUtton(bool isActive, String _buttonText, MiniGame game)
    {
        buttonGameObject.SetActive(isActive);
        if (isActive) buttonButton.onClick.AddListener(game.gameStart);
        else buttonButton.onClick.RemoveListener(game.gameStart);
        buttonText.text = _buttonText;
    }
}
