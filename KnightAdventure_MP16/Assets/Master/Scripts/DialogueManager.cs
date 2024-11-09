using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    public GameObject dialogueBox;

    private Queue<string> sentences;
    public float typingSpeed = 0.05f; 
    public float timeBetweenSentences = 3.5f; 

    public static DialogueManager Instance { get; private set; }

   

    private void Start()
    {
        sentences = new Queue<string>();
        dialogueBox.SetActive(false);
    }

    public void StartDialogue(Dialogue dialogue)
    {
        dialogueBox.SetActive(true);
        nameText.text = dialogue.characterName;

        sentences.Clear();
        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }

        // Espera unos segundos antes de mostrar la siguiente oración
        yield return new WaitForSeconds(timeBetweenSentences);

        // Muestra la siguiente oración automáticamente
        DisplayNextSentence();
    }

    private void EndDialogue()
    {
        dialogueBox.SetActive(false);
    }
}

[System.Serializable]
public class Dialogue
{
    public string characterName;
    public string[] sentences;
}