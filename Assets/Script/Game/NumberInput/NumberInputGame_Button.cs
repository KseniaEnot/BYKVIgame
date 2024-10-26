using UnityEngine.UI;
using UnityEngine;

public class NumberInputGame_Button : MonoBehaviour
{
    public void setEnable(bool setPos)
    {
        gameObject.GetComponent<Button>().enabled = setPos;
    }

}
