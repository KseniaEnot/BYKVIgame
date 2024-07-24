using Yarn.Unity;
using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour
{
    [SerializeField]
    private DialogueRunner dialogueRunner;

    /*private void Start()
    {
        dialogueRunner.StartDialogue("TestDialogScript");
    }*/

    [YarnCommand("moveCircle")]
    public IEnumerator MoveCircle(GameObject pos)
    {
        Vector3 startPos = transform.position;
        for (int i = 0; i < 50; i++)
        {
            transform.position += Vector3.Lerp(startPos, pos.transform.position, 0.02f);
            yield return new WaitForSeconds(0.1f);
        }
    }
}
