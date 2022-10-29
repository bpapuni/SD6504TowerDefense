using TMPro;
using UnityEngine;

public class BuildingPlate : MonoBehaviour
{
    BuildManager buildManager;
    Status status;
    public GameObject towerChoiceScene;
    
    public Color hoverColor;

    private GameObject tower;
    private Renderer rend;
    private Color startColor;


    private void Start()
    {
        buildManager = BuildManager.instance;
        status = Status.instance;
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;

        towerChoiceScene.SetActive(true);
        GameObject.FindGameObjectsWithTag("TowerCostText")[0].GetComponent<TMP_Text>().text = buildManager.BallistaCost.ToString();
        GameObject.FindGameObjectsWithTag("TowerCostText")[1].GetComponent<TMP_Text>().text = buildManager.FrostCost.ToString();
        GameObject.FindGameObjectsWithTag("TowerCostText")[2].GetComponent<TMP_Text>().text = buildManager.TinyCost.ToString();
        towerChoiceScene.SetActive(false);
    }

    void OnMouseEnter()
    {
        if (tower != null || buildManager.selectedPlate != null)
            return;
        rend.material.color = hoverColor;
    }

    void OnMouseExit()
    {
        if (buildManager.selectedPlate != null)
            return;

        rend.material.color = startColor;
    }

    void OnMouseUp()
    {
        if (tower != null || buildManager.selectedPlate != null)
            return;

        towerChoiceScene.SetActive(true);
        buildManager.selectedPlate = gameObject;
    }

    public void SetTower(GameObject _tower)
    {
        tower = _tower;
    }

    public GameObject GetTower()
    {
        return tower;
    }
}

