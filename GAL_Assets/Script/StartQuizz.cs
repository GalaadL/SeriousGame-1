using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;
using System.IO;

public class StartQuizz : MonoBehaviour
{

    public string quizzPath;

    private TreeDialogue Quizz;


    private static TreeDialogue load_quizz(string path)
    {
        XmlSerializer serz = new XmlSerializer(typeof(TreeDialogue));
        StreamReader reader = new StreamReader(path);

        TreeDialogue dia = (TreeDialogue)serz.Deserialize(reader);
        return dia;
    }
    public void TriggerQuizz()
    {
        Quizz = load_quizz(quizzPath);
        FindObjectOfType<QuizzManager>().StartQuizz(Quizz);
    }
}
