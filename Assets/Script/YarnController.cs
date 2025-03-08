using Yarn.Unity;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class YarnController : MonoBehaviour
{
    [SerializeField]
    private DialogueRunner dialogueRunner;
    private Image image;

    public Sprite sprite1;
    public Sprite sprite2;


    private void Start()
    {
        //dialogueRunner.StartDialogue("TestDialogScript");
        image = gameObject.GetComponent<Image>();
    }

    [YarnCommand("moveCircle")]
    public void MoveCircle(int i)
    {
        Debug.Log("WORK!");
        if (i == 1)
            image.sprite = sprite2;
        else
            image.sprite = sprite1;
        /*Vector3 startPos = transform.position;
         for (int i = 0; i < 50; i++)
         {
             transform.position += Vector3.Lerp(startPos, pos.transform.position, 0.02f);
             yield return new WaitForSeconds(0.1f);
         }*/
    }
}
