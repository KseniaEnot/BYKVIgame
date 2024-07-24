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
        Vector3 startpos = transform.position;
        for (int i = 0; i < 10; i++)
        {
            transform.position = Vector3.Lerp(startpos, pos.transform.position, 0.1f);
            yield return new WaitForSeconds(1f);
        }
    }
}
