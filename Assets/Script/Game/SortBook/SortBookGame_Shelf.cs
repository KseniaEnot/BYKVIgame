using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SortBookGame_Shelf : MonoBehaviour, IDropHandler
{
    public SortBookGame_color shelfColor;
    public UnityEvent bookInShelf;

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
            //вызывать событие, обрабатывать в миниигре 
            if (eventData.pointerDrag.GetComponent<SortBookGame_Book>().bookColor == shelfColor)
            {
                eventData.pointerDrag.GetComponent<SortBookGame_Book>().canMove = false;
                bookInShelf.Invoke();
            }
            Debug.Log(eventData.pointerDrag.name);
        }
    }
    public void setColor(SortBookGame_color color)
    {
        shelfColor = color;
        switch (shelfColor)
        {
            case SortBookGame_color.Green: gameObject.GetComponent<Image>().color = Color.green; break;
            case SortBookGame_color.Red: gameObject.GetComponent<Image>().color = Color.red; break;
            case SortBookGame_color.Yellow: gameObject.GetComponent<Image>().color = Color.yellow; break;
        }
    }
}
