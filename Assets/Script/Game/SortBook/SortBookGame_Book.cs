using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SortBookGame_Book : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public SortBookGame_color bookColor;
    [SerializeField] Canvas canvas;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    public bool canMove;
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }
    public void setTransform(float posX, float posY)
    {
        //проблемы с ссылками без активации объекта
        GetComponent<RectTransform>().position = new Vector3(posX, posY) / canvas.scaleFactor + canvas.gameObject.GetComponent<RectTransform>().position;
    }
    private void refresh()
    {
        canMove = true;
        //проблемы с ссылками без активации объекта
        GetComponent<CanvasGroup>().alpha = 1f;
        GetComponent<CanvasGroup>().blocksRaycasts = true;
    }
    public void setColor(SortBookGame_color color)
    {
        refresh();
        bookColor = color;
        switch (bookColor)
        {
            case SortBookGame_color.Green: gameObject.GetComponent<Image>().color = Color.green; break;
            case SortBookGame_color.Red: gameObject.GetComponent<Image>().color = Color.red; break;
            case SortBookGame_color.Yellow: gameObject.GetComponent<Image>().color = Color.yellow; break;
        }
    }


    public void OnBeginDrag(PointerEventData eventData)
    {//подняли
        if (canMove)
        {
            canvasGroup.alpha = .6f;
            canvasGroup.blocksRaycasts = false;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (canMove)
        {
            rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {//отпустили
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
    }
}
