using UnityEngine;
using System;
using System.Xml;
using System.Collections;
using System.Collections.Generic;


public enum ActionType
{
    NoneAction, ItemReceived, CallCutscene, ExitDialogue
}

public class Dialogue : MonoBehaviour
{
    public string teste;
    public List<DialogueNode> Nodes;
    public TextAsset xmlDialogue;

    public Dialogue() { }

    void Start()
    {
        Debug.Log("start");

        //add a node
        DialogueNode dialogueNode1 = new DialogueNode(1, "OI!");
        DialogueNode dialogueNode2 = new DialogueNode(1, "SIM!");
        DialogueNode dialogueNode3 = new DialogueNode(1, "Tenho, sim, de uma olhada!");

        DialogueOption dialogueOption1 = new DialogueOption("ta tudo suave?", dialogueNode2.id);
        DialogueOption dialogueOption2 = new DialogueOption("Bye", -1, ActionType.ExitDialogue);

        DialogueOption dialogueOption3 = new DialogueOption("top então, tem coisas pra vender?", dialogueNode3.id);
        DialogueOption dialogueOption4 = new DialogueOption("Bye", -1, ActionType.ExitDialogue);

        addNode(dialogueNode1);
        addNode(dialogueNode2);
        addNode(dialogueNode3);

        addOption(dialogueNode1, new DialogueOption[] { dialogueOption1, dialogueOption2 } );
        addOption(dialogueNode2, new DialogueOption[] { dialogueOption3, dialogueOption4 } );

        createDialog();
    }

    public void createDialog()
    {

    }

    public void addNode(DialogueNode node)
    {
        if (node == null) return;

        Nodes.Add(node);
        // attribute a id
        node.id = Nodes.IndexOf(node);
    }

    public void addOption(DialogueNode node, DialogueOption[] option)
    {    
        for (int cont = 0; cont < option.Length; cont++)
        {
            node.options.Add(option[cont]);
        }
    }
}