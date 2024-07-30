using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetWepon : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Destroy(this.gameObject);
            other.transform.parent.GetComponent<PlayerScript>().SetIsGetWepon();
            Debug.Log("hit");
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
            Debug.Log("get");
        }
    }
}
