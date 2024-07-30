using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastScript : MonoBehaviour
{

    public Ray ray;
    [SerializeField]Camera mainCamera;

    [SerializeField, Header("�f�o�b�O����")] string debugString;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
         ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        debugString = "ray=" + ray.origin+"\n"+ ray.direction;
    }
}
