using System;
using TMPro;
using UnityEngine;

public class BuildingPlate : MonoBehaviour
{
    BuildManager buildManager;
    Status status;

    public enum plateType { NORMAL, FIRE, RANGE, SPEED };
    public plateType type;
    public GameObject towerChoiceScene;    
    public Color hoverColor;

    private GameObject tower;
    private Renderer rend;
    private Color startColor;
    private GameObject magicBuff;


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
        
        if (type != plateType.NORMAL)
        {
            SetupMagicBuff();
        }
    }

    private void SetupMagicBuff()
    {
        Vector3 pos = new Vector3(transform.position.x, transform.position.y - 1, transform.position.z);
        magicBuff = Instantiate(buildManager.magicBuff, pos, transform.rotation);
        if (type == plateType.FIRE)
            magicBuff.GetComponentsInChildren<ParticleSystem>()[1].startColor = Color.blue;
        else if (type == plateType.RANGE)
            magicBuff.GetComponentsInChildren<ParticleSystem>()[1].startColor = Color.white;
        else if (type == plateType.SPEED)
            magicBuff.GetComponentsInChildren<ParticleSystem>()[1].startColor = Color.red;

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

