using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastScript : MonoBehaviour
{

    public Ray ray;
    public RaycastHit hit;
    Camera mainCamera;

    [SerializeField, Header("デバッグ文字")] string debugString;
    public GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera=Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
         ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out hit, 1000.0f);

        Vector3 newVector = hit.point;
        newVector.y = 0f;
        hit.point = newVector;

        debugString = "ray=" + ray.origin+"\n"+ ray.direction+ "\nhit"+ hit.point;
        if(target != null)
        {
            target.transform.position = hit.point;
        }
    }
}
