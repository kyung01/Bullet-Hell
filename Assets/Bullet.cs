using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public enum BulletTarget {PLAYER,ENEMY }
    public enum BulletType {DEFAULT, RECTANGLE }


    [SerializeField] SpriteRenderer spriteRenderer;

    [SerializeField] int damage;
    [SerializeField] float speed;

    BulletTarget bTarget;
    BulletType bType;
    bool isHit = false;
    
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
    public void Update()
    {

        this.transform.position += this.transform.up *speed* Time.deltaTime;
        if (isHit)
        {
            Kill();
        }
        //
    }
    void Kill()
    {
        //삭제하면 안되요
        //우리는 이거를 재활용 하고 잇습니다 BulletManager !
        this.transform.position = new Vector3(-100, -100, -100);
        this.enabled = false;
    }

    //나중에 학생분들이 혼자서 금요일날 만들어볼껀데요
    //관통하는것도 할수있으신분들은 만드는걸로 해봅시다?
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var entity = collision.GetComponentInParent<Entity>();
        if (entity == null) return;

        switch (bTarget)
        {
            case BulletTarget.PLAYER:
                // 플레이어에게 데미지를 준다
                if(entity.tag == "Player"){
                    entity.TakeDamage(damage);
                    //플레이어에게 데미지를 준다.
                    isHit = true;
                }
                break;
            case BulletTarget.ENEMY:
                //아무것도 하지 않는다
                if (entity.tag == "Enemy")
                {
                    entity.TakeDamage(damage);
                    //적에게 데미지를 준다.
                    isHit = true;
                }
                break;
            default:
                break;
        }

        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        
    }

    private void FixedUpdate()
    {
        
    }
}