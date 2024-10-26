using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.UI;

public enum SortBookGame_color
{
    Green = 0,
    Red = 1,
    Yellow = 2
}

public class SortBookGame : MiniGame
{
    //добавить таймер
    [SerializeField]
    private float posY;
    [SerializeField]
    private List<float> posX;

    [SerializeField]
    private List<SortBookGame_Book> books;
    [SerializeField]
    private List<SortBookGame_Shelf> shelfs;
    private int countInPlace;
    private void Awake()
    {
        par = gameParams.Rlevance;
    }

    public override void gameStart()
    {
        base.gameStart();
        //создание книг и шкафов

        //подписка на события
        foreach (SortBookGame_Shelf shelf in shelfs)
        {
            shelf.bookInShelf.AddListener(bookInShelf);
        }
        //окраска книг и полок
        randomColorSet(shelfs);
        randomColorSet(books);
        //устновка книг на экране
        setBookPos(books);
        countInPlace = 0;
    }

    public override void gameEnd()
    {
        foreach (SortBookGame_Shelf shelf in shelfs)
        {
            shelf.bookInShelf.RemoveListener(bookInShelf);
        }
        base.gameEnd();
    }

    private void bookInShelf()
    {
        countInPlace += 1;
        if (countInPlace == books.Count)
        {
            gameScore = 1;
            gameEnd();
        }
    }
    private void setBookPos(List<SortBookGame_Book> arr)
    {
        for (int i = 0; i < arr.Count; i++)
        {
            arr[i].setTransform(posX[i], posY);
        }
    }
    private void randomColorSet(List<SortBookGame_Book> arr)
    {
        List<int> tempArr = new List<int>();
        for (int i = 0; i < arr.Count; i++)
        {
            tempArr.Add(i);
        }
        int getRand;
        for (int i = 0; i < arr.Count; i++)
        {
            getRand = Random.Range(0, tempArr.Count);
            arr[tempArr[getRand]].setColor((SortBookGame_color)i);
            tempArr.RemoveAt(getRand);
        }
    }
    private void randomColorSet(List<SortBookGame_Shelf> arr)
    {
        List<int> tempArr = new List<int>();
        for (int i = 0; i < arr.Count; i++)
        {
            tempArr.Add(i);
        }
        int getRand;
        for (int i = 0; i < arr.Count; i++)
        {
            getRand = Random.Range(0, tempArr.Count);
            arr[tempArr[getRand]].setColor((SortBookGame_color)i);
            tempArr.RemoveAt(getRand);
        }
    }
}
