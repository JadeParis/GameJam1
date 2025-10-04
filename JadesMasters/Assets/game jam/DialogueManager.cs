using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.HID;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;
    public Queue<string> sentences;

    public Animator animator;
    public GameObject matches;

    public bool steal;

    public bool grave;
    public Interact interact;

    public GameObject graveToDig;

    public bool dialogueActive = false;
   

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
            yield return new WaitForSeconds(0.2f);
            
        }
    }
    public bool creepChalk;
    public GameObject chalk;
    void EndDialogue()
    {
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
        interact.talking = false;

        //steal the matches 

    }
}
