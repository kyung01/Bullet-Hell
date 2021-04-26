using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Entity entity;
    [SerializeField] float speed = 10;

    public void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            //bool 
            if (entity.IsBulletReady)
            {
                entity.FireBullet();

            }
        }
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        entity.transform.position += new Vector3(horizontal, vertical, 0).normalized * speed * Time.deltaTime;
    }
}