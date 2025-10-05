using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInteract : MonoBehaviour
{
    public Fade fade;
    public TaskManager taskManager;
    public DialogueManager dialogue;
   
    public DialogueTrigger TriggerGrave;
    public DialogueTrigger TriggerStore;
    public DialogueTrigger TriggerCreep;
    public PlayerController playerController;
    public Ritual ritual;
    public ShakePhone shake;

    //public GameObject axe;
    public GameObject matches;
 
    public GameObject Flashing;
        
    public GameObject candlesCross;
    public GameObject candleHolder;
    public GameObject creep;

    public ItemStorage items;
    public Interact interact;

  
    public bool axeCollected = false;
    public bool axeCol = false;
    public bool matchescol = false;
    public bool chalkcol = false;
    
    public bool talking = false;
    public bool Screenup = false;
   
    public bool changeColour = false;
    public bool candleListMade = false;

    public int candleScore = 0;

    public Vector3 boxSize = new Vector3(1, 2, 1);


    public AudioSource Collect;
    public AudioSource EyeChime;
    public AudioSource Laptop;
    public AudioSource Chalk;
    public AudioSource Body;
    public AudioSource Axe;

    public Teleport teleport;
    public bool allowedLeave;

    void Start()
    {
        ///FindNPCS();


    }

    void Update()
    {

        if (TriggerGrave == null || TriggerCreep == null || TriggerStore == null || creep == null)
            FindNPCS();


       

        hit();
    }
    public void FindNPCS()
    {
        // Re-find NPC every time the scene loads
        GameObject npc = GameObject.FindGameObjectWithTag("NPCGrave");
        if (npc != null)
        {
            TriggerGrave = npc.GetComponent<DialogueTrigger>();
            Debug.Log("Found");
            if (TriggerGrave == null)
                Debug.LogWarning("no script");
        }
        else
        {
            Debug.LogWarning("NopeG");
        }

        // Re-find NPC every time the scene loads
        GameObject npcStore = GameObject.FindGameObjectWithTag("NPCStore");
        if (npcStore != null)
        {
            TriggerStore = npcStore.GetComponent<DialogueTrigger>();
            Debug.Log("Found");
            if (TriggerStore == null)
                Debug.LogWarning("noscript");
        }
        else
        {
            Debug.LogWarning("NopeS");
        }

        // Re-find NPC every time the scene loads
        GameObject npcCreep = GameObject.FindGameObjectWithTag("NPCCreep");
        if (npcCreep != null)
        {
            TriggerCreep = npcCreep.GetComponent<DialogueTrigger>();
            creep = npcCreep;

            Debug.Log("Found");
            if (TriggerCreep == null)
                Debug.LogWarning("no script");
            if (creep == null)
                Debug.LogWarning("nocreep!");
        }
        else
        {
            Debug.LogWarning("NopeC");
        }
    }


    private void hit()
    {
        Collider[] hits = Physics.OverlapBox(transform.position, boxSize / 2);

        foreach (Collider hit in hits)
        {
            Debug.Log("Overlap hit: " + hit.name);

            if (Input.GetKeyDown(KeyCode.E))
            {
                interact.phoneOn = false;
                // ---------- NPC Grave ----------
                if (hit.CompareTag("NPCGrave"))
                {

                    interact.allowPhone = false;

                    taskManager.bodyTaskComplete = true;
                    dialogue.grave = true;
                    taskManager.AxeActive = true;
                    taskManager.DigActive = true;

                    if (!axeCol)
                    {
                        interact.axe.SetActive(true);
                        axeCol = true;
                    }

                    if (!talking)
                    {
                        TriggerGrave.TriggerDialogue();
                        talking = true;
                    }
                }

                // ---------- Grave ----------
                if (hit.CompareTag("Grave"))
                {
                    if (axeCollected)
                    {
                        taskManager.diggingTaskComplete = true;
                    }
                    if (dialogue.grave && axeCollected)
                    {
                        
                        SceneManager.LoadSceneAsync(2);
                        taskManager.dayTwo = true;
                    }
                }

                // ---------- Axe ----------
                if (hit.CompareTag("Axe"))
                {
                    taskManager.axeTaskComplete = true;
                    axeCollected = true;

                    InventoryInfo axeInfo = new InventoryInfo();
                    axeInfo.Name = "Axe";
                    axeInfo.Quantity = 1;
                    axeInfo.GameObject = gameObject;
                    items.collected.Add(axeInfo);
                    Axe.Play();
                    hit.gameObject.SetActive(false);
                }

                // ---------- Candle ----------
                if (hit.CompareTag("Candle"))
                {
                    candleScore++;
                    hit.gameObject.SetActive(false);
                    Collect.Play();
                    Debug.Log("Candle triggered");
                    Collect.Play();
                    if (candleScore == 5)
                        candlesCross.SetActive(true);

                    if (candleListMade)
                    {
                        InventoryInfo candle = items.collected.Find(i => i.Name == "Candle");
                        candle.Quantity++;

                    }
                    else
                    {
                        InventoryInfo candle = new InventoryInfo { Name = "Candle", Quantity = 1 };
                        items.collected.Add(candle);
                        candleListMade = true;
                    }
                }

                // ---------- Chalk ----------
                if (hit.CompareTag("Chalk"))
                {
                    taskManager.chalkTaskComplete = true;

                    InventoryInfo chalk = new InventoryInfo();
                    chalk.Name = "Chalk";
                    chalk.Quantity = 1;
                    chalk.GameObject = gameObject;
                    items.collected.Add(chalk);
                    Chalk.Play();
                    hit.gameObject.SetActive(false);
                }

                // ---------- Matches ----------
                if (hit.CompareTag("Matches"))
                {
                    taskManager.matchesTaskComplete = true;

                    InventoryInfo matchInfo = new InventoryInfo();
                    matchInfo.Name = "Matches";
                    matchInfo.Quantity = 1;
                    items.collected.Add(matchInfo);
                    Collect.Play();
                    hit.gameObject.SetActive(false);
                }

                // ---------- NPC Store ----------
                if (hit.CompareTag("NPCStore"))
                {
                    interact.allowPhone = false;

                    if (!talking)
                    {
                        TriggerStore.TriggerDialogue();
                        talking = true;
                    }

                    if (!matchescol && interact.daytwoevents)
                    {
                        StartCoroutine(Wait());
                        matches.SetActive(true);
                        dialogue.steal = true;
                        taskManager.steal = true;
                        shake.Shake();
                        matchescol = true;
                    }
                }

                // ---------- NPC Creep ----------
                if (hit.CompareTag("NPCCreep"))
                {
                    interact.allowPhone = false;

                    if (!talking)
                    {
                        TriggerCreep.TriggerDialogue();

                        talking = true;

                        if (!chalkcol)
                        {
                            dialogue.creepChalk = true;
                            chalkcol = true;
                        }
                        else
                        {
                            dialogue.creepChalk = false;
                        }
                    }
                }

                // ---------- Body ----------
                if (hit.CompareTag("Body"))
                {
                    fade.ShowUI();
                    interact.axe.SetActive(false);
                    Body.Play();
                    InventoryInfo body = new InventoryInfo();
                    body.Name = "Body";
                    body.Quantity = 1;
                    body.GameObject = gameObject;
                    items.collected.Add(body);
                    playerController.canMove = false;
                    hit.gameObject.SetActive(false);
                    taskManager.cutBodyTaskComplete = true;

                    StartCoroutine(Wait());
                }

                // ---------- Eye ----------
                if (hit.CompareTag("Eye"))
                {
                    changeColour = true;
                    hit.gameObject.SetActive(false);
                    EyeChime.Play();
                }

                // ---------- Laptop ----------
                if (hit.CompareTag("Laptop"))
                {
                    if (!Screenup) // Open laptop
                    {
                        interact.phoneintro = true;
                        interact.allowPhone = true;
                        interact.reddit.SetActive(true);
                        Flashing.SetActive(true);
                        Screenup = true;
                        playerController.canMove = false;
                        interact.phoneSprite.SetActive(true);
                    }
                    else // Close laptop
                    {
                        interact.reddit.SetActive(false);
                        Flashing.SetActive(false);
                        Screenup = false;
                        playerController.canMove = true;
                        shake.shakestart();
                        allowedLeave = true;
                    }
                }

                // ---------- Ritual Spot ----------
                if (hit.CompareTag("RitualSpot"))
                {
                    ritual.placeCandles();
                    ritual.PlaceItems();
                }

                if (hit.CompareTag("Leave"))
                {
                    if (allowedLeave)
                    {
                        teleport.tele();
                    }

                }


            }
        }
        


    }
  
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position, boxSize);
    }
    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(4);
        fade.HideUI();
        playerController.canMove = true;
        Body.Pause();
        yield return new WaitForSeconds(4);
        StopAllCoroutines();
    }
}
