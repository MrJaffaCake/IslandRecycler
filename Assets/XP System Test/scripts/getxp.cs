using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



//
// prikaci na 'Level Window' objektot (roditel na xp UI)
//

public class getxp : MonoBehaviour
{
    private Text lvltext;
    private Image barimg;
    private XpSystem xpSystem;

    private void Awake()
    {
        lvltext = transform.Find("lvltxt").GetComponent<Text>();
        barimg = transform.Find("xpbar").Find("bar").GetComponent<Image>();


        //testovi so kopcinja so soodvetni funkcii

        //dodavanje xp (samo za test nema ingame)
        transform.Find("add10").GetComponent<Button>().onClick.AddListener(add10exp);
        transform.Find("add50").GetComponent<Button>().onClick.AddListener(add50exp);
        transform.Find("add200").GetComponent<Button>().onClick.AddListener(add200exp);

        // kupuvanje od shop (ako ne si dovolen level nema da ti dozvoli, za sea e samo so logs napraveno)
        transform.Find("machine1").GetComponent<Button>().onClick.AddListener(Buyitem1);
        transform.Find("machine2").GetComponent<Button>().onClick.AddListener(Buyitem2);
    }

    private void add10exp() 
    {
        xpSystem.AddXp(10);
    }
    private void add50exp()
    {
        xpSystem.AddXp(50);
    }
    private void add200exp()
    {
        xpSystem.AddXp(100);
    }

    private void Buyitem1()
    {
        if (xpSystem.getlvl() < 4)
        {
            Debug.Log("Level 5 required!");
        }
        else
        {
            Debug.Log("You bought this item!");
        }
    }

    private void Buyitem2()
    {
        if (xpSystem.getlvl() < 9)
        {
            Debug.Log("Level 10 required!");
        }
        else
        {
            Debug.Log("You bought this item!");
        }
    }

    private void TextChange(int lvln)
    {
        lvltext.text = "LEVEL: " + (lvln+1);
    }

    private void BarSize(float xp)
    {
        barimg.fillAmount = xp;
    }

    public void SetXpSystem(XpSystem xpSystem)
    {
        this.xpSystem = xpSystem;

        TextChange(xpSystem.getlvl());
        BarSize(xpSystem.getxpn());

        xpSystem.onXpGain += xp_xpGain;
        xpSystem.onLvlChange += xp_lvlChange;
    }

    private void xp_xpGain(object o, System.EventArgs e)
    {
        BarSize(xpSystem.getxpn());
    }

    private void xp_lvlChange(object o, System.EventArgs e)
    {
        TextChange(xpSystem.getlvl());
    }
}
