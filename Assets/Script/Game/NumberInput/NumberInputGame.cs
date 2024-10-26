using UnityEngine;
using TMPro;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
public class NumberInputGame : MiniGame
{
    [SerializeField] private TMP_Text NumberText;
    [SerializeField] private int MaxNumb;
    [SerializeField] private int Size;
    [SerializeField] private List<NumberInputGame_Button> numberInputGame_Buttons;

    private List<int> number;
    private List<int> inputNumber;
    private void Awake()
    {
        par = gameParams.Popularit;
        number = new List<int>();
        inputNumber = new List<int>();
    }

    public override void gameStart()
    {
        base.gameStart();
        foreach (NumberInputGame_Button item in numberInputGame_Buttons)  //продизейблить все кнопки
            item.setEnable(false);
        generateNumber(MaxNumb); //сгенерили
        NumberText.text = "";
        inputNumber.Clear();
        StartCoroutine(clearNumb());

        //стёрли
        //ждём пока чел вводи номер, когда number.size == inputNumber.size эндгейм
    }

    public IEnumerator clearNumb()
    {
        foreach (int item in number)//вывели
        {
            NumberText.text += item;
            yield return new WaitForSeconds(0.1f);
        }
        yield return new WaitForSeconds(1f); //время на запомнить
        NumberText.text = "";
        foreach (NumberInputGame_Button item in numberInputGame_Buttons)//проэнейблить все кнопки
            item.setEnable(true);
    }

    public void pressButton(int numb)
    {
        NumberText.text += numb;
        inputNumber.Add(numb);
        if (inputNumber.Count == number.Count)
        {
            if (Enumerable.SequenceEqual(inputNumber, number))
            {
                gameScore = 1;
                //win
            }
            else
            {
                gameScore = 0;
                //ne win
            }
            gameEnd();
            //end game
        }
    }

    public override void gameEnd()
    {
        // ДЕЙСТВИЯ
        base.gameEnd();
    }

    private void generateNumber(int _size)
    {
        number.Clear();
        for (int i = 0; i < _size; i++)
        {
            number.Add(Random.Range(1, MaxNumb));
        }
    }
}
