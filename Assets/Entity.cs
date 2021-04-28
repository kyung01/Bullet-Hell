using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public delegate void DEL_ENTITY_HEALTH_CHANGED(int healthBefore, int healthAfter);

    public List<DEL_ENTITY_HEALTH_CHANGED> hdrEntityHealthChanged = new List<DEL_ENTITY_HEALTH_CHANGED>();

    protected void raiseOnEntityHealthChanged(int healthBefore, int healthAfter)
    {
        for (int i = 0; i < hdrEntityHealthChanged.Count; i++)
        {
            hdrEntityHealthChanged[i](healthBefore, healthAfter);
        }
    }
    [SerializeField] int health = 10;
    [SerializeField] float bulletFireDelay = 1.0f;

    float bulletFireDelayTimeElapsed = 0f;
    bool isBulletReady = true;
    bool isAlive = true;

    public bool IsAlive
    {
        get
        {
            return isAlive;
        }
    }
    public int Health
    {
        get
        {
            return health;
        }
    }



    public virtual void TakeDamage(int damage)
    {
        int healthBefore = Health;
        health -= damage;
        if(health <= 0)
        {
            Kill();
        }
        int healthAfter = Health;
        raiseOnEntityHealthChanged(healthBefore, healthAfter);
    }

    public virtual void Kill()
    {
        isAlive = false;

    }
    public virtual void Reset()
    {
        isAlive = true;
        //체력을 기본 최대 체력으로 설정해야되요
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
    public virtual void Update()
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