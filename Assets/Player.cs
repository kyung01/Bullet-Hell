using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    public override void prcFireBullet()
    {
        base.prcFireBullet();
        Debug.Log("�÷��̾� �� ��");
        BulletManager.Singletone.FireBullet(
            Bullet.BulletTarget.ENEMY, Bullet.BulletType.DEFAULT, 
            this.transform.position, Vector3.up);
    }
}
