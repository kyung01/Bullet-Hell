using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Entity entity;
    [SerializeField] float speed = 10;

    public void Update()
    {
        if(!entity.IsAlive)
        {
            return;
        }
        if (Input.GetKey(KeyCode.Space))
        {
            //bool 
            if (entity.IsBulletReady)
            {
                entity.FireBullet();

            }
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            entity.GetComponent<Player>().UseUltimate();

        }

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        entity.transform.position += new Vector3(horizontal, vertical, 0).normalized * speed * Time.deltaTime;
        float x = entity.transform.position.x;
        float y = entity.transform.position.y;

        x = Mathf.Max(Mathf.Min(15.87f, x), - 15.87f);
        y = Mathf.Max(Mathf.Min(7.97f,  y), -7.97f);

        entity.transform.position = new Vector3(x, y, entity.transform.position.z);
        //x min -15.87
        //x max 15.87
        //y 7.97
        //y -7.97

    }

}