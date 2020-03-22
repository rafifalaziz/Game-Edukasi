using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircularCircle : MonoBehaviour
{
    public GameObject gameObject1;
    public GameObject gameObject2;
    public GameObject gameObject3;
    public GameObject gameObject4;

    public static CircularLinkedList CLL = new CircularLinkedList();

    // Start is called before the first frame update
    public void Start()
    {
        CLL.addEnd(gameObject1);
        CLL.addEnd(gameObject2);
        CLL.addEnd(gameObject3);
        CLL.addEnd(gameObject4);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

public class Node
{
    public GameObject gameObject;
    public Node next;
}

public class CircularLinkedList
{
    public Node first;
    public Node last;

    public CircularLinkedList()
    {
        first = null;
        last = null;
    }

    public void addEnd(GameObject gameObject)
    {
        Node baru = new Node();
        baru.gameObject = gameObject;
        baru.next = baru;

        if(first==null)
        {
            first = baru;
            last = baru;
        }
        else
        {
            baru.next = last.next;
            last.next = baru;
            last = baru;
        }
    }
    
}
