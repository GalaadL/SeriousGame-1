using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using System.Xml.Serialization;

public class QuizzManager : MonoBehaviour
{
    public Button AnswerButton1;
    public Text TextButton1;
    public Button AnswerButton2;
    public Text TextButton2;
    public Button AnswerButton3;
    public Text TextButton3;


    private bool WaitAnswer = false;

    public Text QuestionText;

    private List<int> listResult = null;

    private void Start()
    {
        AnswerButton1.enabled = false;
        AnswerButton2.enabled = false;
        AnswerButton3.enabled = false;
        QuestionText.enabled = false;

    }



    public void StartQuizz(TreeDialogue quizz)
    {
        int node_id = 0;

        while (node_id != -1)
        {
            node_id = Run_node(quizz.Nodes[node_id]);
        }
        Debug.Log(listResult);

    }

    public int Run_node(TreeDialogueNode node)
    {
        int nextNode = -1;
        FindObjectOfType<OnClickDialogueManager>().StartDialogue(node.Text);
        while (FindObjectOfType<OnClickDialogueManager>().animator.GetBool("IsOpen") == true)
        {

        }
        TextButton1.text = node.Options[0].Text;
        AnswerButton1.enabled = true;

        TextButton2.text = node.Options[1].Text;
        AnswerButton2.enabled = true;

        TextButton3.text = node.Options[2].Text;
        AnswerButton3.enabled = true;

        QuestionText.text = node.Question;
        QuestionText.enabled = false;

        WaitAnswer = true;
        while (WaitAnswer == true) { }

        AnswerButton1.enabled = false;
        AnswerButton2.enabled = false;
        AnswerButton3.enabled = false;
        QuestionText.enabled = false;

        nextNode = node.Options[listResult[-1]].DestinationNodeID;
        return nextNode;
    }

    public void SendAnswer1()
    {
        listResult.Add(0);
        WaitAnswer = false;
    }
    public void SendAnswer2()
    {
        listResult.Add(1);
        WaitAnswer = false;
    }
    public void SendAnswer3()
    {
        listResult.Add(2);
        WaitAnswer = false;
    }

}
