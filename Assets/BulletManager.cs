using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    static public BulletManager Singletone; 

    [SerializeField] Bullet PREFAB_BULLET;
    List<Bullet> bulletReady = new List<Bullet>();
    List<Bullet> bulletNotReady = new List<Bullet>() ;


    private void Awake()
    {
        Singletone = this;

        for(int i = 0;  i < 100; i++)
        {
            var b = Instantiate(PREFAB_BULLET);
            bulletReady.Add(b);
            b.transform.position = new Vector3(-100,-100,0);
        }
    }


    public void FireBullet(Bullet.BulletTarget bTarget,Bullet.BulletType bType, 
        Vector3 position,
        Vector3 direction)
    {
        if (bulletReady.Count == 0) return;
        var bullet = bulletReady[0];
        bulletReady.RemoveAt(0);
        bulletNotReady.Add(bullet);

        bullet.enabled = true;

        bullet.transform.position = position;
        bullet.transform.rotation = Quaternion.Euler(0, 0, -90+
            Mathf.Atan2(direction.y, direction.x) * 180.0f / Mathf.PI);
        bullet.Reset(bTarget, bType);


    }


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}