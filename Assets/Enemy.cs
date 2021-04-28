using System.Collections;
using UnityEngine;

public class Enemy : Entity
{
   // Vector3 dirFiring = Vector3.down;

    public override void prcFireBullet()
    {
        base.prcFireBullet();
        Debug.Log("적 총 쏨");
        BulletManager.Singletone.FireBullet(
         Bullet.BulletTarget.PLAYER, Bullet.BulletType.DEFAULT,
         this.transform.position, Vector3.down );

    }
    public override void Update()
    {
        base.Update();


        FireBullet();


    }
}