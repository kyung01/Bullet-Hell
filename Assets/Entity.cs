using System.Collections;
using UnityEngine;

public class Entity : MonoBehaviour
{
    [SerializeField] int health = 10;
    [SerializeField] float bulletFireDelay = 1.0f;

    float bulletFireDelayTimeElapsed = 0f;
    bool isBulletReady = true;
    bool isAlive = true;

    public void TakeDamage(int damage)
    {
        health -= damage;
        if(health <= 0)
        {
            Kill();
        }
    }

    public void Kill()
    {
        isAlive = false;

    }

    //프로퍼티 Property 라고 합니다
    public bool IsBulletReady
    {
        get
        {
            return this.isBulletReady;
        }
    }


    
    //가상함수가 사실 아닙니다 
    public void FireBullet()
    {
        if (isBulletReady)
        {
            isBulletReady = false;
            prcFireBullet();
        }
    }

    //예가 우리가 필요한 가상함수 입니다 
    public virtual void prcFireBullet()
    {

    }


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!isBulletReady)
        {
            bulletFireDelayTimeElapsed += Time.deltaTime;
            if(bulletFireDelayTimeElapsed > bulletFireDelay)
            {
                isBulletReady = true;
                bulletFireDelayTimeElapsed = 0;
            }

        } 

    }
}