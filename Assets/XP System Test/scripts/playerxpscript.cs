using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

//
//  Dodaj na Player
//


public class playerxpscript : MonoBehaviour
{
    [SerializeField] private getxp xpStats;   // tuka ke stoi objektot na koi mu e dodaden 'getxp' scriptata (Level Window)

    private void Awake()
    {
        XpSystem xpSystem = new XpSystem();
        xpStats.SetXpSystem(xpSystem);
    }
}
