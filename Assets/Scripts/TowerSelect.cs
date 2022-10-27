using UnityEngine;
using UnityEngine.SceneManagement;

public class TowerSelect : MonoBehaviour
{
    BuildManager buildManager;
    public GameObject towerChoiceScene;
    public GameObject towerConfirmScene;

    void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void PurchaseBallistaTower()
    {
        GameObject towerToBuild = buildManager.PendingBallistaTower;
        buildManager.SetPendingTower(Instantiate(towerToBuild, buildManager.selectedPlate.transform.position, buildManager.selectedPlate.transform.rotation));
        buildManager.SetTowerToBuild(buildManager.BallistaTower);
        towerChoiceScene.SetActive(false);
        towerConfirmScene.SetActive(true);
    }

    public void PurchaseFrostTower()
    {
        GameObject towerToBuild = buildManager.PendingFrostTower;
        buildManager.SetPendingTower(Instantiate(towerToBuild, buildManager.selectedPlate.transform.position, buildManager.selectedPlate.transform.rotation));
        buildManager.SetTowerToBuild(buildManager.FrostTower);
        towerChoiceScene.SetActive(false);
        towerConfirmScene.SetActive(true);
    }

    public void PurchaseTinyTower()
    {
        GameObject towerToBuild = buildManager.PendingTinyTower;
        buildManager.SetPendingTower(Instantiate(towerToBuild, buildManager.selectedPlate.transform.position, buildManager.selectedPlate.transform.rotation));
        buildManager.SetTowerToBuild(buildManager.TinyTower);
        towerChoiceScene.SetActive(false);
        towerConfirmScene.SetActive(true);
    }

    public void ConfirmPurchaseTower()
    {
        Destroy(buildManager.GetPendingTower());
        GameObject towerToBuild = buildManager.GetTowerToBuild();
        Instantiate(towerToBuild, buildManager.selectedPlate.transform.position, buildManager.selectedPlate.transform.rotation);
        towerConfirmScene.SetActive(false);
    }

    public void CancelSelect()
    {
        Destroy(buildManager.GetPendingTower());
        towerConfirmScene.SetActive(false);
    }
}
