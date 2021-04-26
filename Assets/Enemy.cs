using System.Collections;
using UnityEngine;

public class Enemy : Entity
{

    public override void prcFireBullet()
    {
        base.prcFireBullet();
        Debug.Log("적 총 쏨");
        BulletManager.Singletone.FireBullet(
         Bullet.BulletTarget.PLAYER, Bullet.BulletType.DEFAULT,
         this.transform.position, Vector3.down);
    }
}