using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;
using static UnityEngine.GraphicsBuffer;

public class EnemyScript : MonoBehaviour
{
    public GameObject weponObj;

    Ray enemyEyeRay;
    RaycastHit enemyEyeHitObj;
    Ray weponRay;
    RaycastHit hitObj;
    [SerializeField, Header("射撃間隔")] float initShotCoolTime;
    [SerializeField, Header("弾数")] int initBulletNum;
    int culletnBulletNum;
    [SerializeField, Header("リロード時間")] float rerodeTime;
    float currentRerodeTime;
    float shotCoolTime;
    public LineRendererScript shotLinePrefab;
    public bool isShooting;
    public bool isSerching;
    public bool isLookOutOver;

    public SplineAnimate spline;
    GameObject target;

    [SerializeField, Header("キョロキョロタイム")] float lookOutTime;
    float currentLookOutTime;
    float lookOutNum;
    [SerializeField, Header("キョロキョロで動く幅")] float lookSpeed;
    float currentLookSpeed;
    // Start is called before the first frame update
    void Start()
    {
        culletnBulletNum = initBulletNum;
        isSerching = true;
        isShooting = false;
        isLookOutOver = false;
        currentLookSpeed = lookSpeed;
        lookOutNum = 1;
    }

    // Update is called once per frame
    void Update()
    {
        enemyEyeRay.origin = transform.position;
        enemyEyeRay.direction = transform.forward;

        Move();
        WeponShot();
        LookOutOver();
    }

    void Move()
    {
        if (!isSerching) { return; }

        if (Physics.Raycast(enemyEyeRay, out enemyEyeHitObj, 1000.0f))
        {
            if (enemyEyeHitObj.transform.tag == "Player")
            {
                isSerching = false;
                isLookOutOver = false;
                isShooting = true;
                spline.Pause();
                target = enemyEyeHitObj.transform.gameObject;
            }
        }
    }
    void LookOutOver()
    {
        if(!isLookOutOver) { return; }
        transform.Rotate(0f, currentLookSpeed * Time.deltaTime, 0f);
        currentLookOutTime += Time.deltaTime;
        if (Physics.Raycast(enemyEyeRay, out enemyEyeHitObj, 1000.0f))
        {
            if (enemyEyeHitObj.transform.tag == "Player")
            {
                isSerching = false;
                isLookOutOver = false;
                isShooting = true;
                spline.Pause();
                target = enemyEyeHitObj.transform.gameObject;
                currentLookOutTime = 0;
                currentLookSpeed = lookSpeed;
                lookOutNum = 1;
                return;
            }
        }
        if (currentLookOutTime > lookOutTime* lookOutNum / 3)
        {
            currentLookSpeed *= -0.7f;
            lookOutNum++;
        }
        if(currentLookOutTime> lookOutTime)
        {
            currentLookOutTime = 0;
            currentLookSpeed = lookSpeed;
            lookOutNum = 1;
            isSerching = true;
            isShooting = false;
            isLookOutOver = false;
            spline.Play();
        }
    }
    void WeponShot()
    {
        if (!isShooting) { return; }
        if (culletnBulletNum <= 0)
        {
            currentRerodeTime += Time.deltaTime;
            if (currentRerodeTime > rerodeTime)
            {
                currentRerodeTime = 0;
                culletnBulletNum = initBulletNum;
                if (Physics.Raycast(enemyEyeRay, out enemyEyeHitObj, 1000.0f))
                {
                    if (enemyEyeHitObj.transform.tag != "Player")
                    {
                        isSerching = false;
                        isShooting = false;
                        isLookOutOver = true;
                        //SetSplinePlay();
                        currentLookSpeed = lookSpeed;
                        lookOutNum = 1;
                    }
                }
            }
            return;
        }
        if (shotCoolTime > 0)
        {
            weponObj.gameObject.transform.LookAt(target.transform);
            this.gameObject.transform.LookAt(target.transform);
            shotCoolTime -= Time.deltaTime;
            return;
        }
        culletnBulletNum--;
        weponRay.origin = weponObj.transform.position;

        weponRay.direction = weponObj.transform.forward;

        shotCoolTime = initShotCoolTime;
        //Debug.Log("Shot");

        if (Physics.Raycast(weponRay, out hitObj, 1000.0f))
        {
            if (hitObj.transform.tag == "Button")
            {
                hitObj.transform.GetComponent<SelfDestroy>().Destroy();
                Debug.Log("HitButton");

            }

            LineRendererScript shotLine = Instantiate(shotLinePrefab);
            shotLine.SetStart(weponObj.transform.position, hitObj.point);
        }




    }
}
