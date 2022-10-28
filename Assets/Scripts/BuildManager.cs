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
    public GameObject selectedTower;
    public GameObject rangeIndicatorObj;
    public GameObject towerChoice;
    public GameObject confirmTowerChoice;
    public GameObject confirmTowerDelete;

    private GameObject pendingTower;
    private GameObject towerToBuild;
    private GameObject rangeIndicator;


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

    public void ShowPendingTower()
    {
        Vector3 rangeIndLoc = new Vector3(selectedPlate.transform.position.x, 0f, selectedPlate.transform.position.z);
        rangeIndicator = Instantiate(rangeIndicatorObj, rangeIndLoc, selectedPlate.transform.rotation);
        pendingTower = Instantiate(pendingTower, selectedPlate.transform.position, selectedPlate.transform.rotation);
        towerChoice.SetActive(false);
        confirmTowerChoice.SetActive(true);
    }

    public void HidePendingTower()
    {
        Destroy(rangeIndicator);
        Destroy(pendingTower);
        selectedPlate.GetComponent<Renderer>().material.color = Color.white;
        selectedPlate = null;
    }

    public void BuildTower()
    {
        selectedPlate.GetComponent<BuildingPlate>().SetTower(Instantiate(towerToBuild, selectedPlate.transform.position, selectedPlate.transform.rotation));
        HidePendingTower();
    }
}
