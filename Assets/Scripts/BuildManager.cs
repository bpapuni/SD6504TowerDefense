using System.Collections;
using System.Linq;
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
    public int BallistaCost;
    public int FrostCost;
    public int TinyCost;
    public GameObject selectedPlate;
    public GameObject selectedTower;
    public GameObject rangeIndicatorObj;
    public GameObject magicBuff;
    public GameObject towerChoice;
    public GameObject confirmTowerChoice;
    public GameObject confirmTowerDelete;

    private GameObject pendingTower;
    private float pendingTowerRange;
    private GameObject towerToBuild;
    public GameObject rangeIndicator;
    public GameObject bonusRangeIndicator;
    private Renderer[] rend;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than 1");
            return;
        }

        instance = this;

        GameObject[] buildPlates = GameObject.FindGameObjectsWithTag("BuildingPlate");
        int[] magicNums = new int[3];
        for (int i = 0; i < 3; i++)
        {
            int rand;
            do
            {
                rand = Random.Range(0, buildPlates.Length);
            } while (magicNums.Contains(rand));
            magicNums[i] = rand;
        }

        for (int i = 0; i < buildPlates.Length; i++)
        {
            if (i == magicNums[0])
            {
                buildPlates[i].GetComponent<BuildingPlate>().type = BuildingPlate.plateType.FIRE;
            }
            else if (i == magicNums[1])
            {
                buildPlates[i].GetComponent<BuildingPlate>().type = BuildingPlate.plateType.RANGE;
            }
            else if (i == magicNums[2])
            {
                buildPlates[i].GetComponent<BuildingPlate>().type = BuildingPlate.plateType.SPEED;
            }
            else
                buildPlates[i].GetComponent<BuildingPlate>().type = BuildingPlate.plateType.NORMAL;
        }
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
        pendingTowerRange = tower.GetComponent<Tower>().range;
    }

    public void ShowPendingTower()
    {
        Vector3 rangeIndLoc = new Vector3(selectedPlate.transform.position.x, 0f, selectedPlate.transform.position.z);
        rangeIndicator = Instantiate(rangeIndicatorObj, rangeIndLoc, selectedPlate.transform.rotation);
        rangeIndicator.transform.localScale = new Vector3(pendingTowerRange*2, 0.1f, pendingTowerRange*2);
        pendingTower = Instantiate(pendingTower, selectedPlate.transform.position, selectedPlate.transform.rotation);

        if (selectedPlate.GetComponent<BuildingPlate>().type == BuildingPlate.plateType.RANGE)
        {
            bonusRangeIndicator = Instantiate(rangeIndicatorObj, rangeIndLoc, selectedPlate.transform.rotation);
            bonusRangeIndicator.transform.localScale = new Vector3(pendingTowerRange*2, 0.1f, pendingTowerRange*2) * 1.2f;
        }
        
        towerChoice.SetActive(false);
        confirmTowerChoice.SetActive(true);
    }

    public void HidePendingTower()
    {
        Destroy(rangeIndicator);
        if (bonusRangeIndicator)
            Destroy(bonusRangeIndicator);
        Destroy(pendingTower);
        selectedPlate.GetComponent<Renderer>().material.color = Color.white;
        selectedPlate = null;
    }

    public void BuildTower()
    {
        selectedPlate.GetComponent<BuildingPlate>().SetTower(Instantiate(towerToBuild, selectedPlate.transform.position, selectedPlate.transform.rotation));
        HidePendingTower();
    }

    public void DeleteTower()
    {
        Destroy(selectedTower.GetComponent<Tower>().rangeIndicator);
        Destroy(selectedTower);
        selectedPlate.GetComponent<Renderer>().material.color = Color.white;
        selectedPlate = null;
    }

    public void CancelDelete()
    {
        rend = selectedTower.GetComponentsInChildren<Renderer>();
        for (int i = 0; i < rend.Length; i++)
            rend[i].material.color = Color.white;
        selectedPlate.GetComponent<Renderer>().material.color = Color.white;
        selectedTower.GetComponent<Tower>().rangeIndicator.SetActive(false);
        selectedTower = null;
        selectedPlate = null;
    }
}
