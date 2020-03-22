using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectingDot : MonoBehaviour
{
    public Vector3 lineStart;
    private Vector3 endLine;

    private Vector3 targetCircle;
    public LineRenderer line;

    private bool activeLine;
    private bool inCircle;

    public GameObject dotObject;

    int counter = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        lineStart = transform.position;
        line.numPositions = 2;
        line.SetPosition(0,lineStart);
        line.SetPosition(1, lineStart);
    }

    // Update is called once per frame
    void Update()
    {

        if (Staticer.firstPress && Staticer.currentCircle.activeLine)
        {
            Staticer.currentCircle.endLine = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Staticer.currentCircle.endLine.z = 0;
            Staticer.currentCircle.line.SetPosition(1, Staticer.currentCircle.endLine);
        }
    }

    private void OnMouseDown()
    {
        Staticer.firstPress = true;
        Staticer.currentCircle = this;
        Staticer.currentCircle.activeLine = true;
        Staticer.continueLine = true;
        Staticer.firstCircle = this;
        
    }

    private void OnMouseUp()
    {
        if(Staticer.currentCircle != null)
        {
            Staticer.currentCircle.activeLine = false;
            Staticer.terminateLine = true;
            Staticer.continueLine = false;
            if (!Staticer.currentCircle.inCircle)
            {
                Staticer.currentCircle.line.SetPosition(0, Staticer.currentCircle.lineStart);
                Staticer.currentCircle.line.SetPosition(1, Staticer.currentCircle.lineStart);
                Staticer.currentCircle.inCircle = false;
            }
        }

    }

    public void OnMouseEnter()
    {
        if (Staticer.currentCircle != null)
        {
            if (Staticer.firstPress && Staticer.currentCircle != this)
            {
                //Staticer.currentCircle.endLine = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Staticer.currentCircle.endLine = this.gameObject.transform.position;
                Staticer.currentCircle.endLine.z = 0;
                Staticer.currentCircle.line.SetPosition(1, Staticer.currentCircle.endLine);
                Staticer.currentCircle.activeLine = false;
                Staticer.currentCircle.inCircle = true;
                Staticer.currentCircle = this;
                if (counter == 0)
                {
                    Staticer.dotNode.addEnd(dotObject);
                    counter++;
                    Debug.Log("enter");
                }

            }
        }
    }

    private void OnMouseExit()
    {
        if(Staticer.currentCircle != Staticer.firstCircle)
        {
            if (Staticer.terminateLine)
            {
                Staticer.currentCircle.activeLine = false;
                Staticer.terminateLine = false;
            }
            else if (Staticer.firstPress && Staticer.continueLine)
            {
                Staticer.currentCircle = this;
                Staticer.currentCircle.line.SetPosition(0, lineStart);
                Staticer.currentCircle.activeLine = true;
            }
        }
    }
}
