using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    public delegate void DEL_PLAYER_ULTIMATE_NUMBER_CHANGED(int numBefore, int numAfter);
    public List<DEL_PLAYER_ULTIMATE_NUMBER_CHANGED> hdrPlayerUltimateNumberChanged = new List<DEL_PLAYER_ULTIMATE_NUMBER_CHANGED>();

    private void raiseOnPlayerUltimateNumberChanged(int numBefore, int numAfter)
    {
        for (int i = 0; i < hdrPlayerUltimateNumberChanged.Count; i++)
        {
            hdrPlayerUltimateNumberChanged[i](numBefore, numAfter);
        }
    }
    int ultimateCount = 3;

    public override void prcFireBullet()
    {
        base.prcFireBullet();
        Debug.Log("ÇÃ·¹ÀÌ¾î ÃÑ ½ô");
        BulletManager.Singletone.FireBullet(
            Bullet.BulletTarget.ENEMY, Bullet.BulletType.DEFAULT, 
            this.transform.position, Vector3.up);
    }
    public override void Kill()
    {
        base.Kill();
        this.GetComponentInChildren<SpriteRenderer>().sprite = SpriteManager.Singletone.playerDead;
        this.GetComponentInChildren<BoxCollider2D>().enabled = false;
    }

    public override void Reset()
    {
        base.Reset();
        this.GetComponentInChildren<SpriteRenderer>().sprite = SpriteManager.Singletone.playerSprite;
        this.GetComponentInChildren<BoxCollider2D>().enabled = true;
    }

    public void UseUltimate()
    {
        int numBefore = ultimateCount;
        if (ultimateCount == 0) return;
        ultimateCount--;
        int numAfter = ultimateCount;
        BulletManager.Singletone.ResetAllBullets();


        raiseOnPlayerUltimateNumberChanged(numBefore, numAfter);
    }

}
