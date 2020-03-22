using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Staticer : MonoBehaviour
{

    public static bool firstPress;
    public static bool continueLine;
    public static bool terminateLine;
    public static ConnectingDot currentCircle;
    public static ConnectingDot firstCircle;
    
    public static CircularLinkedList dotNode = new CircularLinkedList();

    Node dot = dotNode.first;
    Node cek = CircularCircle.CLL.first;

    int checker = 0;
    
    private void Update()
    {
        for (int i = 0; i < 4; i++)
        {
            if (dot.gameObject.Equals(cek.gameObject))
            {
                dot = dot.next;
                cek = cek.next;
                checker++;
                Debug.Log("tes");
            }
        }
        if (checker == 4)
        {
            Debug.Log("berhasil");
        }
    }
}
