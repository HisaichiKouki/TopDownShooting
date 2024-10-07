using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    bool gameClear;
    public FadeScript fadePrefab;
    public bool GetGameClear() { return gameClear; }
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
        if (other.gameObject.tag == "Player")
        {
            gameClear = true;
            FadeScript fadeObj=Instantiate(fadePrefab);
            fadeObj.SetSceneName("GameClearScene");
        }
    }
}
