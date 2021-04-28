using System;
using System.Collections;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] TMPro.TMP_Text text;
    [SerializeField] UnityEngine.UI.Image ultimateIcon00, ultimateIcon01, ultimateIcon02;

    private void Awake()
    {
        player.hdrEntityHealthChanged.Add(hdrOnEntityHealthChanged);
        player.hdrPlayerUltimateNumberChanged.Add(hdrOnPlayerUltimateNumberChanged);
    }

    private void hdrOnPlayerUltimateNumberChanged(int numBefore, int numAfter)
    {
        switch (numAfter)
        {
            case 0:
                ultimateIcon00.gameObject.SetActive(false);
                ultimateIcon01.gameObject.SetActive(false);
                ultimateIcon02.gameObject.SetActive(false);
                break;
            case 1:
                ultimateIcon00.gameObject.SetActive(true);
                ultimateIcon01.gameObject.SetActive(false);
                ultimateIcon02.gameObject.SetActive(false);
                break;
            case 2:
                ultimateIcon00.gameObject.SetActive(true);
                ultimateIcon01.gameObject.SetActive(true);
                ultimateIcon02.gameObject.SetActive(false);
                break;
            case 3:
                ultimateIcon00.gameObject.SetActive(true);
                ultimateIcon01.gameObject.SetActive(true);
                ultimateIcon02.gameObject.SetActive(true);
                break;
            default:
                break;
        }
        //
    }

    private void hdrOnEntityHealthChanged(int healthBefore, int healthAfter)
    {
        //체력숫자가 바뀌어야 한다
        text.text ="x"+ healthAfter;
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