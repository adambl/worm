using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormController : MonoBehaviour
{
    public GameObject wormBodyPartPrefab;
    LinkedList<GameObject> wormPartsList = new LinkedList<GameObject>();

    void AddWormPart()
    {
        GameObject lastGameObject = wormPartsList.Last.Value;
        Vector3 lastPosition = lastGameObject.GetComponent<Rigidbody2D>().transform.position;
        GameObject newWormBodyPart = Instantiate(
            wormBodyPartPrefab,
            lastPosition,
            Quaternion.identity,
            GetComponent<Transform>());
        wormPartsList.AddLast(newWormBodyPart);
    }

    // Start is called before the first frame update
    IEnumerator AddWormPartCoroutine()
    {
        yield return new WaitForSeconds(5);
        AddWormPart();
        StartCoroutine(AddWormPartCoroutine());
    }
    
    void Start()
    {
        GameObject wormHead = GameObject.FindWithTag("WormHead") as GameObject;
        wormPartsList.AddFirst(wormHead);
        StartCoroutine(AddWormPartCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        LinkedListNode<GameObject> currentNode = wormPartsList.First;
        Vector3 currentNodePosition = currentNode.Value.GetComponent<Rigidbody2D>().position;

        while (currentNode != null)
        {
            LinkedListNode<GameObject> nextNode = currentNode.Next;

            if (nextNode != null)
            {
                Vector3 prevNextPos = nextNode.Value.GetComponent<Rigidbody2D>().position;
                nextNode.Value.GetComponent<Rigidbody2D>().position = currentNodePosition;
                currentNodePosition = prevNextPos;
            }
            currentNode = nextNode;
        }
    }
}
