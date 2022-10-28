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
        buildManager.SetPendingTower(buildManager.PendingBallistaTower);
        buildManager.SetTowerToBuild(buildManager.BallistaTower);
        buildManager.ShowPendingTower();
        HideHighlight();
    }

    public void PurchaseFrostTower()
    {
        buildManager.SetPendingTower(buildManager.PendingFrostTower);
        buildManager.SetTowerToBuild(buildManager.FrostTower);
        buildManager.ShowPendingTower();
        HideHighlight();
    }

    public void PurchaseTinyTower()
    {
        buildManager.SetPendingTower(buildManager.PendingTinyTower);
        buildManager.SetTowerToBuild(buildManager.TinyTower);
        buildManager.ShowPendingTower();
        HideHighlight();
    }

    public void ConfirmPurchaseTower()
    {
        // TODO move costs from status to buildManager
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

        status.UpdateGold(-TowerCost);
        buildManager.BuildTower();
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
        status.UpdateGold(TowerCost / 2);
        buildManager.confirmTowerDelete.SetActive(false);
    }

    public void CancelSelect()
    {
        buildManager.HidePendingTower();
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
