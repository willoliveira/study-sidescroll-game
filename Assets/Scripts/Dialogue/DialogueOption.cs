using UnityEngine;
using System.Collections;

[System.Serializable]
public class DialogueOption
{

    public ActionType actionType;
    public int nextNodeId;
    public string text;
    
    public DialogueOption(string text, int nextNodeId = -1, ActionType actionType = ActionType.NoneAction)
    {
        this.text = text;
        this.nextNodeId = nextNodeId;
        this.actionType = actionType;
    }
}
