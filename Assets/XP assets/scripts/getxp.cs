using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



//
// prikaci na 'Level Window' objektot (roditel na xp UI) ili na canvasot
//

public class getxp : MonoBehaviour
{
    public Text levelText, toNextLevelText, moneyText;
    public Image levelBar;
    private XpSystem xpSystem;

    public GameObject levelUpdate, gainTxt;
    public Text levelUpdate2, gainTxt2;

    public GameObject smallLvl, littleMoney;
    public Text smallLvlTxt;

    public Button buy1, buy2, buy3;

    private void Awake()
    {
        //testovi so kopcinja so soodvetni funkcii

        //dodavanje xp (samo za test nema ingame)
        transform.Find("add10").GetComponent<Button>().onClick.AddListener(add10exp);
        transform.Find("add50").GetComponent<Button>().onClick.AddListener(add50exp);
        transform.Find("add200").GetComponent<Button>().onClick.AddListener(add200exp);

        // kupuvanje od shop (ako ne si dovolen level nema da ti dozvoli, za sea e samo so logs napraveno)
        //transform.Find("machine1").GetComponent<Button>().onClick.AddListener(Buyitem1);
        //transform.Find("machine2").GetComponent<Button>().onClick.AddListener(Buyitem2);
        //transform.Find("machine3").GetComponent<Button>().onClick.AddListener(Buyitem3);

        Button b1 = buy1.GetComponent<Button>();
        b1.onClick.AddListener(Buyitem1);

        Button b2 = buy2.GetComponent<Button>();
        b2.onClick.AddListener(Buyitem2);

        Button b3 = buy3.GetComponent<Button>();
        b3.onClick.AddListener(Buyitem3);
    }

    private void add10exp() 
    {
        xpSystem.AddXp(10);
    }

    public void addcollectexp(int xp, int money)
    {
        xpSystem.AddXp(xp);
        xpSystem.AddMoney(money);

        TextChange5(xp, money);
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
        if (xpSystem.getlvl() >= 4)
        {
            if (xpSystem.getmoney() >= 50)
            {
                FindObjectOfType<AudioManager>().Play("purchase");
                xpSystem.AddMoney(-50);
            }
            else
            {
                FindObjectOfType<AudioManager>().Play("alert");
                littleMoney.SetActive(true);
            }
        }
        else
        {
            FindObjectOfType<AudioManager>().Play("alert");
            Text lowlvl = smallLvlTxt.GetComponent<Text>();
            lowlvl.text = "Level 5 required!";
            smallLvl.SetActive(true);
        }
    }

    private void Buyitem2()
    {
        if (xpSystem.getlvl() >= 9)
        {
            if (xpSystem.getmoney() >= 100)
            {
                FindObjectOfType<AudioManager>().Play("purchase");
                xpSystem.AddMoney(-100);
            }
            else
            {
                FindObjectOfType<AudioManager>().Play("alert");
                littleMoney.SetActive(true);
            }
        }
        else
        {
            FindObjectOfType<AudioManager>().Play("alert");
            Text lowlvl = smallLvlTxt.GetComponent<Text>();
            lowlvl.text = "Level 10 required!";
            smallLvl.SetActive(true);
        }
    }

    private void Buyitem3()
    {
        if (xpSystem.getlvl() >= 0)
        {
            if(xpSystem.getmoney() >= 10)
            {
                FindObjectOfType<AudioManager>().Play("purchase");
                xpSystem.AddMoney(-10);
            }
            else
            {
                FindObjectOfType<AudioManager>().Play("alert");
                littleMoney.SetActive(true);
            }
        }
        else
        {
            FindObjectOfType<AudioManager>().Play("alert");
            Text lowlvl = smallLvlTxt.GetComponent<Text>();
            lowlvl.text = "Level 2 required!";
            smallLvl.SetActive(true);
        }
    }

    private void TextChange(int lvln)
    {
        Text lvltext = levelText.GetComponent<Text>();
        lvltext.text = "LEVEL: " + (lvln + 1);
    }

    private void TextChange2(int xp)
    {
        Text xptxt = toNextLevelText.GetComponent<Text>();
        xptxt.text = "To next level: " + (100 - xp);
    }

    private void TextChange3(int money)
    {
        Text mntxt = moneyText.GetComponent<Text>();
        mntxt.text = "Money: " + money + "$";
    }

    private void TextChange4(int lvln)
    {
        Text newlvl = levelUpdate2.GetComponent<Text>();
        newlvl.text = "You leveled up to level " + (lvln+1) + "!";
        levelUpdate.SetActive(true);
    }

    private void TextChange5(int xp, int money)
    {
        Text gaintxt = gainTxt2.GetComponent<Text>();
        gaintxt.text = "+" + xp + "xp" + "\n+" + money + "$";
        gainTxt.SetActive(true);
    }

    private void BarSize(float xp)
    {
        Image barimg = levelBar.GetComponent<Image>();
        barimg.fillAmount = xp;
    }

    public void SetXpSystem(XpSystem xpSystem)
    {
        this.xpSystem = xpSystem;

        TextChange(xpSystem.getlvl());
        BarSize(xpSystem.getxpn());

        xpSystem.onXpGain += xp_xpGain;
        xpSystem.onLvlChange += xp_lvlChange;

        xpSystem.onMoneyGain += mn_mnGain;
    }

    private void xp_xpGain(object o, System.EventArgs e)
    {
        BarSize(xpSystem.getxpn());
        TextChange2(xpSystem.getxp());
    }

    private void xp_lvlChange(object o, System.EventArgs e)
    {
        FindObjectOfType<AudioManager>().Play("lvlUp");
        TextChange(xpSystem.getlvl());
        TextChange4(xpSystem.getlvl());
    }

    private void mn_mnGain(object o, System.EventArgs e)
    {
        TextChange3(xpSystem.getmoney());
    }
}
