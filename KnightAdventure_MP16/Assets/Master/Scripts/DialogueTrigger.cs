using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    private DialogueManager _dialogueManager;

    public GameObject collectIcon;
    private bool cercaDelJugador = false;
    public GameObject panel;
    private void Start()
    {
        _dialogueManager = FindAnyObjectByType<DialogueManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            cercaDelJugador = true;
            collectIcon.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            cercaDelJugador = false;
            collectIcon.SetActive(false);
        }
    }
    private void Update()
    {
        if(cercaDelJugador && Input.GetKeyDown(KeyCode.E))
        {
            startDialogue();
        }
    }
    void startDialogue()
    {
        panel.SetActive(true);
        _dialogueManager.StartDialogue(dialogue);
        //gameObject.SetActive(false);
    }
}
