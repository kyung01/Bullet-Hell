using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    static public BulletManager Singletone;

    [SerializeField] Bullet PREFAB_BULLET;
    List<Bullet> bulletReady = new List<Bullet>();
    List<Bullet> bulletNotReady = new List<Bullet>();


    private void Awake()
    {
        Singletone = this;

        for (int i = 0; i < 100; i++)
        {
            var b = Instantiate(PREFAB_BULLET);
            bulletReady.Add(b);
            b.transform.position = new Vector3(-100, -100, 0);
        }
    }


    public void FireBullet(Bullet.BulletTarget bTarget, Bullet.BulletType bType,
        Vector3 position,
        Vector3 direction)
    {
        if (bulletReady.Count == 0) return;
        var bullet = bulletReady[0];
        bulletReady.RemoveAt(0);
        bulletNotReady.Add(bullet);

        bullet.enabled = true;

        bullet.transform.position = position;
        bullet.transform.rotation = Quaternion.Euler(0, 0, -90 +
            Mathf.Atan2(direction.y, direction.x) * 180.0f / Mathf.PI);
        bullet.Reset(bTarget, bType);


    }


    // Use this for initialization
    void Start()
    {

    }

    public void ResetAllBullets()
    {
        for(int i = bulletNotReady.Count-1; i >= 0; i--)
        {
            //모든 총알을 리셋 시켜야해요.
            resetBullet(bulletNotReady[i]);
            bulletNotReady.RemoveAt(i);

        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = bulletNotReady.Count - 1; i >= 0; i--)
        {
            var bNotReady = bulletNotReady[i];
            bool isReset = false;
            if (bNotReady.IsHit)
            {
                //다시 준비되게 해라
                //reset 을 해라
                isReset = true;
            }
            //만약 화면 밖이면 그냥 리셋을 해라
            else 
            {
                bool isOutSideScreen = false;
                if(bNotReady.transform.position.y > 11  || bNotReady.transform.position.y < -11
                    || bNotReady.transform.position.x < -20 || bNotReady.transform.position.x > 20)
                {
                    isOutSideScreen = true;
                }

                if (isOutSideScreen)
                {
                    isReset = true;
                }
            }
            if (isReset)
            {
                resetBullet(bNotReady);
                bulletNotReady.RemoveAt(i);
            }

        }
    }
    void resetBullet(Bullet b)
    {
        b.Reset();
        b.transform.position = new Vector3(100, 100, 100);
        bulletReady.Add(b);
    }
}