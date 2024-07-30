using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    Transform player;
    Vector3 ray;
    RayCastScript rayCastScript;
    Vector3 length;
    Vector3 newPosition;
    Vector3 currentPos;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").transform;
        rayCastScript=GetComponent<RayCastScript>();
        currentPos= transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //ray = rayCastScript.hit.point;
        //length = player.position- ray;
        //if (length.magnitude<5)
        //{
        //    newPosition = player.position - length;
           
        //}
        currentPos.x= player.position.x;
        currentPos.z= player.position.z-5;
        this.transform.position = currentPos;
        this.transform.LookAt(player.position);




    }
}
