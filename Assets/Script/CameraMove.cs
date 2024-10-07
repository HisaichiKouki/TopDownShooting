using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraMove : MonoBehaviour
{
    Transform player;
    Vector3 ray;
    RayCastScript rayCastScript;
    Vector3 length;
    Vector3 newPosition;
    Vector3 currentPos;
    public float easeT;
    public float ratio;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").transform;
        rayCastScript = GetComponent<RayCastScript>();
        currentPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        ray = rayCastScript.hit.point;

        length = player.position - ray;
        length *= ratio;
        newPosition = player.position - length;
        //if (length.magnitude<5)
        //{
        //    newPosition = player.position - length;

        //}
        currentPos.x = (1.0f - easeT) * currentPos.x + newPosition.x * easeT;
        currentPos.z = (1.0f - easeT) * currentPos.z + (newPosition.z - 5) * easeT;
        //currentPos.x= newPosition.x;
        //currentPos.z= newPosition.z-5;
        this.transform.position = currentPos;
        //this.transform.LookAt(player.position);




    }
}
