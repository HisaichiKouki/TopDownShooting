using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineRendererScript : MonoBehaviour
{
    LineRenderer lineRenderer;
    public Vector3 pos1;
    public Vector3 pos2;

    float currentT;
    public void SetStart(Vector3 pos1_, Vector3 pos2_)
    {
        pos1=pos1_; pos2=pos2_; 
    }
    // Start is called before the first frame update
    void Start()
    {
        lineRenderer=GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        currentT += Time.deltaTime;
        pos1 = (1 - currentT) * pos1 + currentT * pos2;
        lineRenderer.SetPosition(0, pos1);
        lineRenderer.SetPosition(1, pos2);
        if (currentT>0.5f) { Destroy(this.gameObject); }
    }
}
