using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    Rigidbody mRigidBody;
    public float speed;
    public float maxSpeed;
    RayCastScript rayScript;
    public GameObject weponObj;

    bool isGetWepon;
    Ray weponRay;
    RaycastHit hitObj;
    [SerializeField,Header("ŽËŒ‚ŠÔŠu")] float initShotCoolTime;
    float shotCoolTime;
    public LineRendererScript shotLinePrefab;
    GameManager gameManager;
    public void SetIsGetWepon()
    {
        isGetWepon = true;
        weponObj.SetActive(true);
    }
    // Start is called before the first frame update
    void Start()
    {
        mRigidBody = GetComponent<Rigidbody>();
        rayScript = GetComponent<RayCastScript>();
        weponObj.SetActive(false);
        gameManager=FindAnyObjectByType<GameManager>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameManager.GetGameClear())
        {
            Move();
            Look();
            WeponLook();
            WeponShot();
        }
        else
        {
            mRigidBody.velocity = new Vector3(0, 0, speed);
        }
        
    }
    void Move()
    {
        if (Input.GetKey(KeyCode.D))
        {
            mRigidBody.AddForce(new Vector3(speed, 0, 0));
        }
        else if (Input.GetKey(KeyCode.A))
        {
            mRigidBody.AddForce(new Vector3(-speed, 0, 0));
        }
        if (Input.GetKey(KeyCode.W))
        {
            mRigidBody.AddForce(new Vector3(0, 0, speed));
        }
        else if (Input.GetKey(KeyCode.S))
        {
            mRigidBody.AddForce(new Vector3(0, 0, -speed));
        }
        mRigidBody.velocity = Vector3.ClampMagnitude(mRigidBody.velocity, maxSpeed);
    }
    void Look()
    {
        Vector3 newVector = rayScript.hit.point;
        newVector.y = 1;
        transform.LookAt(newVector);
        //transform.rotation = new Quaternion(0, transform.rotation.y, 0, 1);
    }
    void WeponLook()
    {
        if (!isGetWepon) { return; }
        Vector3 newVector = rayScript.hit.point;
        newVector.y = 1.05f;
        weponObj.transform.LookAt(newVector);
    }

    void WeponShot()
    {
        if (!isGetWepon) { return; }
        if( shotCoolTime > 0)
        {
            shotCoolTime-=Time.deltaTime;
            return;
        }
        weponRay.origin = weponObj.transform.position;

        weponRay.direction = weponObj.transform.forward;
        if (Input.GetMouseButton(0))
        {
            shotCoolTime = initShotCoolTime;
            Debug.Log("Shot");

            if (Physics.Raycast(weponRay, out hitObj, 1000.0f))
            {
                if (hitObj.transform.tag == "Button")
                {
                    hitObj.transform.GetComponent<SelfDestroy>().Destroy();
                    Debug.Log("HitButton");

                }
                else if (hitObj.transform.tag =="Enemy")
                {
                    hitObj.transform.GetComponent<EnemyHP>().Damage();
                }

                LineRendererScript shotLine = Instantiate(shotLinePrefab);
                shotLine.SetStart(weponObj.transform.position, hitObj.point);
            }
        }
        


    }
}
