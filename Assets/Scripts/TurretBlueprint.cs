﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TurretBlueprint
{
    public GameObject prefab;
    public int cost;
    public GameObject upgradePrefab;
    public int upgradeCost;


    public int GetSaleAmount(bool isUpgraded)
    {
        if (isUpgraded)
            return (cost + upgradeCost) / 2;

        return cost / 2;
    }
}
