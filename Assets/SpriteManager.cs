using System.Collections;
using UnityEngine;

public class SpriteManager : MonoBehaviour
{
    public static SpriteManager Singletone;

    public Sprite playerDead; 

    public Sprite
        BULLET_00_PLAYER, BULLET_00_ENEMY;
    public Sprite playerSprite;

    private void Awake()
    {
        Singletone = this;

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