
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.Animations;
using UnityEngine;

public class CheckVisability : MonoBehaviour
{
    [SerializeField] private GameObject target;
    [SerializeField] private Camera playerCamera;

    public Transform treeParent;
    List<Transform> allTrees = new List<Transform>();

    public List<Transform> nearbyTrees = new List<Transform>(); //When trigger enter, add to this list.
    public List<GameObject> nonVisibleTrees;

    public bool manPeeking;
    public GameObject peekingMan;

    GameObject spawnedMan;

    bool cooldownTimer;
    public float manSpawnCooldown = 5f;

    public Vector3 positionOffset;
    public Vector3 scale = new Vector3(0.1963626f, 0.1963626f, 0.1963626f);


    //All trees 
    //When not looking at trees
    //pick one tree (timer?)
    //have character animated out of it.
    //When looking at this tree,
    //character animates in. 

    //BUG: Check if we can ACTUALLY SEE THE tree MESH

    private void Start()
    {
        foreach (Transform tr in treeParent.GetComponentsInChildren<Transform>())
        {
            if(tr.name.Contains("tree"))
                allTrees.Add(tr);
        }
    }
     

    void Update()
    {
        for (int i = 0; i < allTrees.Count; i++) //Change this list 'alltrees' to 'nearbytrees' once they have colliders!
        {
            if (!IsVisible(allTrees[i].gameObject))
            {
                if (!nonVisibleTrees.Contains(allTrees[i].gameObject))
                {
                    nonVisibleTrees.Add(allTrees[i].gameObject);
                }        
            }
        }

        for (int i = 0; i < nonVisibleTrees.Count; i++)
        {
            if(IsVisible(nonVisibleTrees[i].gameObject))
                nonVisibleTrees.Remove(nonVisibleTrees[i].gameObject);
        }

        if (!manPeeking)
        {
            SpawnMan();
        }
        else if(manPeeking && spawnedMan != null) //He is peeking
        {
            if (IsVisible(spawnedMan))
            {
                //Animate him going in
                spawnedMan.GetComponent<Animator>().SetBool("isVisible", true);
                cooldownTimer = true;
                
            }
        }

        if (cooldownTimer)
        {
            manSpawnCooldown -= Time.deltaTime;
            if (manSpawnCooldown <= 0)
            {
                manPeeking = false;
                manSpawnCooldown = 5;
                cooldownTimer = false;
            }
        }
    }

    void SpawnMan()
    {
        target = PickTree();

        spawnedMan = Instantiate(peekingMan, target.transform);
        spawnedMan.transform.position = new Vector3(target.transform.position.x + positionOffset.x, transform.localPosition.y + positionOffset.y, target.transform.position.z + positionOffset.z);
        spawnedMan.transform.localScale = scale;
        spawnedMan.GetComponent<FollowCamera>().player = this.transform;
        
        //start playing audio?

        manPeeking = true;
        //put man
    }

    GameObject PickTree()
    {
        //How many trees are not visible?
        //Random number from that 

        int r = Random.Range(0, nonVisibleTrees.Count);
        Debug.Log(r);
        return nonVisibleTrees[r];
    }

    private bool IsVisible(GameObject target)
    {
        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(playerCamera);
        return planes.All(plane=> plane.GetDistanceToPoint(target.transform.position) >= 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        //Trees need collider!
        if (other.CompareTag("Tree"))
        {
            nearbyTrees.Add(other.transform);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //Trees need collider!
        if (other.tag == "Tree" && nearbyTrees.Contains(other.transform))
        {
            nearbyTrees.Remove(other.transform);
        }
    }

}
