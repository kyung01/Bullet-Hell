using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public enum BulletTarget {PLAYER,ENEMY }
    public enum BulletType {DEFAULT, RECTANGLE }

    [SerializeField] SpriteRenderer spriteRenderer;

    BulletTarget bTarget;
    BulletType bType;
    
    private void Awake()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    public void Reset(BulletTarget bTarget, BulletType bType)
    {
        this.bTarget = bTarget;
        this.bType = bType;

        if(bType == BulletType.DEFAULT)
        {
            if(bTarget == BulletTarget.ENEMY)
            {
                //플레이어 총알임
                spriteRenderer.sprite = SpriteManager.Singletone.BULLET_00_PLAYER;
            }
            else
            {
                //적이 쏘는 총알이에요
                spriteRenderer.sprite = SpriteManager.Singletone.BULLET_00_ENEMY;
            }
        }
    }
}