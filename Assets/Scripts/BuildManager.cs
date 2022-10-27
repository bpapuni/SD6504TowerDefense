using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    public GameObject PendingBallistaTower;
    public GameObject PendingFrostTower;
    public GameObject PendingTinyTower;
    public GameObject BallistaTower;
    public GameObject FrostTower;
    public GameObject TinyTower;
    public GameObject selectedPlate;
    private GameObject pendingTower;
    private GameObject towerToBuild;


    void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than 1");
            return;
        }

        instance = this;
    }

    public GameObject GetPendingTower()
    {
        return pendingTower;
    }

    public void SetPendingTower(GameObject tower)
    {
        pendingTower = tower;
    }

    public GameObject GetTowerToBuild()
    {
        return towerToBuild;
    }

    public void SetTowerToBuild(GameObject tower)
    {
        towerToBuild = tower;
    }
}
