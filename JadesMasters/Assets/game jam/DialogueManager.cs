using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.HID;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    public Queue<string> sentences;

    public Animator animator;
    public GameObject matches;

    public bool steal;

    public bool grave;
    public PlayerInteract Pinteract;
    public Interact interact;

    public GameObject graveToDig;

    public bool dialogueActive = false;

    public int speed;
    public PlayerController playerController;
    public Transform player;

    
    // Start is called before the first frame update
    void Start()
    {
        chalk.SetActive(false);
        sentences = new Queue<string>();
        matches.SetActive(false);
        grave = false;
        steal = false;
    }

    private void Update()
    {
        if (dialogueActive && Input.GetKeyDown(KeyCode.T))
        {
            DisplayNextSentence();
        }
    }

    public void StartDialoque(Dialogue dialogue)
    {
           
    
       
      

        dialogueActive = true;
        animator.SetBool("IsOpen", true);
        nameText.text = dialogue.name;

        Debug.Log("Starting convosation with" + dialogue.name);

        sentences.Clear();
        playerController.canMove = false;
        foreach (string sentence in dialogue.sentances)
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
        StartCoroutine(TypeSentance(sentence));

    }

    IEnumerator TypeSentance(string sentence)
    {
        dialogueText.text = "";

        foreach(char letter in  sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.01f);
            
        }
    }
    public bool creepChalk;
    public GameObject chalk;
    void EndDialogue()
    {
        playerController.canMove = true; ;
        dialogueActive = false;

        animator.SetBool("IsOpen", false);
        Debug.Log("end of convosation");

        if (creepChalk)
        {
            chalk.SetActive(true);
        }
        else
        {
            chalk.SetActive(false);
        }


        if (steal)
        {
            matches.SetActive(true);
        }
        else
        {
            matches.SetActive(false);
        }

        interact.allowPhone = true;
        Pinteract.talking = false;

        //steal the matches 

    }
}
