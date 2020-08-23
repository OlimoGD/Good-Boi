using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DialogueUI : MonoBehaviour
{
    [SerializeField]
    private Text nameText;
    [SerializeField]
    private Text sentenceText;

    public void setNameText(string name){
        nameText.text = name;
    }

    public void setSentenceText(string sentence){
        sentenceText.text = sentence;
    }
}
