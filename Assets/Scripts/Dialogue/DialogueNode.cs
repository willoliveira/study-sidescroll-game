using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class DialogueNode
{
    public int id = -1;
    public string text;
    public List<DialogueOption> options;

    public DialogueNode(int id, string text)
    {
        this.id = id;
        this.text = text;
    }
}
