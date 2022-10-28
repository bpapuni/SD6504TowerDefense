using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TowerSelect : MonoBehaviour
{
    BuildManager buildManager;
    Status status;
    private Image border;

    void Start()
    {
        buildManager = BuildManager.instance;
        status = Status.instance;
        border = transform.parent.GetComponent<Image>();
    }

    public void PurchaseBallistaTower()
    {
        GameObject towerToBuild = buildManager.PendingBallistaTower;
        buildManager.SetPendingTower(Instantiate(towerToBuild, buildManager.selectedPlate.transform.position, buildManager.selectedPlate.transform.rotation));
        buildManager.SetTowerToBuild(buildManager.BallistaTower);
        HideHighlight();
        buildManager.towerChoice.SetActive(false);
        buildManager.confirmTowerChoice.SetActive(true);
    }

    public void PurchaseFrostTower()
    {
        GameObject towerToBuild = buildManager.PendingFrostTower;
        buildManager.SetPendingTower(Instantiate(towerToBuild, buildManager.selectedPlate.transform.position, buildManager.selectedPlate.transform.rotation));
        buildManager.SetTowerToBuild(buildManager.FrostTower);
        HideHighlight();
        buildManager.towerChoice.SetActive(false);
        buildManager.confirmTowerChoice.SetActive(true);
    }

    public void PurchaseTinyTower()
    {
        GameObject towerToBuild = buildManager.PendingTinyTower;
        buildManager.SetPendingTower(Instantiate(towerToBuild, buildManager.selectedPlate.transform.position, buildManager.selectedPlate.transform.rotation));
        buildManager.SetTowerToBuild(buildManager.TinyTower);
        HideHighlight();
        buildManager.towerChoice.SetActive(false);
        buildManager.confirmTowerChoice.SetActive(true);
    }

    public void ConfirmPurchaseTower()
    {
        int TowerCost = 0;
        GameObject towerToBuild = buildManager.GetTowerToBuild();

        if (towerToBuild.tag == "BallistaTower")
            TowerCost = status.BallistaCost;
        else if (towerToBuild.tag == "FrostTower")
            TowerCost = status.FrostCost;
        else if (towerToBuild.tag == "TinyTower")
            TowerCost = status.TinyCost;

        if (status.gold < TowerCost)
        {
            CancelSelect();
            status.ShowMessage("Not enough gold!", 3);
            buildManager.confirmTowerChoice.SetActive(false);
            return;
        }

        status.gold -= TowerCost;
        status.UpdateGold();
        Destroy(buildManager.GetPendingTower());
        BuildingPlate selectedPlate = buildManager.selectedPlate.GetComponent<BuildingPlate>();
        
        selectedPlate.SetTower(Instantiate(towerToBuild, buildManager.selectedPlate.transform.position, buildManager.selectedPlate.transform.rotation));
        buildManager.confirmTowerChoice.SetActive(false);
    }

    public void ConfirmDeleteTower()
    {
        int TowerCost = 0;
        GameObject towerToDelete = buildManager.selectedTower;

        if (towerToDelete.tag == "BallistaTower")
            TowerCost = status.BallistaCost;
        else if (towerToDelete.tag == "FrostTower")
            TowerCost = status.FrostCost;
        else if (towerToDelete.tag == "TinyTower")
            TowerCost = status.TinyCost;

        Destroy(towerToDelete);
        status.gold += TowerCost / 2;
        status.UpdateGold();
        buildManager.confirmTowerDelete.SetActive(false);
    }

    public void CancelSelect()
    {
        Destroy(buildManager.GetPendingTower());
        border.color = new Color(255, 255, 255, 1);
        buildManager.confirmTowerChoice.SetActive(false);
        buildManager.confirmTowerDelete.SetActive(false);
    }

    public void ShowHighlight()
    {
        border.color = new Color(0, 255, 0, 1);
    }

    public void HideHighlight()
    {
        border.color = new Color(255, 255, 255, 1);
    }
}
