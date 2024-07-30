using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallPrefab : MonoBehaviour
{

    public GameObject[] buttonObj;
    Animator ainmation;
    bool isOpen;
    float currentT;
    Vector3 newPos;
    // Start is called before the first frame update
    void Start()
    {
        ainmation = GetComponent<Animator>();
        newPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Cheack();
        Open();

    }
    void Cheack()
    {
        for (int i = 0; i < buttonObj.Length; i++)
        {
            if (buttonObj[i] != null) { return; }
        }
        isOpen = true;
    }
    void Open()
    {
        if (!isOpen) { return; }
        currentT += Time.deltaTime / 1.5f;
        newPos.y = (1 - currentT) * 1 + currentT * -1;
        this.transform.position = newPos;
        if (currentT>1.5f)
        {
            Destroy(this.gameObject);
        }
    }
}
