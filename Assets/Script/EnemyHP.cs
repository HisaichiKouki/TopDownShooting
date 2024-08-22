using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    [SerializeField, Header("“G‚ÌHP")] int setHitPoint;
    int currentHitPoint;

    public void Damage()
    {
        currentHitPoint--;
        if(currentHitPoint <= 0)
        {
            Destroy(this.gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        currentHitPoint = setHitPoint; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
