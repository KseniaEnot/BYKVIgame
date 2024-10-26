using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Emotion
{
    normal,
    happy,
    sad,
    nervous,
    angry
}

[CreateAssetMenu(fileName = "NPCscript", menuName = "NPCscript", order = 0)]
public class NPCscript : ScriptableObject
{
    [SerializeField] public Emotion emotionState;
    [Space]

    private const int maxLoveState = 10;
    [SerializeField] private List<Sprite> sprites;
    [SerializeField] private int loveState;
    [Space]

    [SerializeField] private List<int> whenOpenInfo; // !when game start whenOpenInfo.count = npcInfo.count
    [SerializeField] private int currentOpened;
    [SerializeField] private List<String> npcInfo;

    public void addLoveState(int add)
    {
        if ((loveState + add < 0) || (loveState + add > maxLoveState)) return;
        loveState += add;
        if (whenOpenInfo.Contains(loveState))
            openNewInfo(loveState);

    }

    private void openNewInfo(int pos)
    {
        whenOpenInfo.Remove(pos);
        currentOpened++;
    }
}