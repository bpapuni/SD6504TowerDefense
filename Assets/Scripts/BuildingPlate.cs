using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingPlate : MonoBehaviour
{
    public GameObject towerChoiceScene;
    
    public Color hoverColor;

    private GameObject tower;
    private Color startColor;
    private Renderer rend;

    BuildManager buildManager;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        buildManager = BuildManager.instance;
        startColor = rend.material.color;
    }

    void OnMouseEnter()
    {
        //if (buildManager.GetTowerToBuild() == null)
        //    return;
        rend.material.color = hoverColor;
    }

    void OnMouseExit()
    {
        rend.material.color = startColor;
    }

    void OnMouseUp()
    {
        towerChoiceScene.SetActive(true);
        buildManager.selectedPlate = gameObject;
        //if(gameObject.tag == "BuildingPlate")
        //{
        //    selectedPlate = gameObject;
        //    platePos = gameObject.transform;
        //    towerChoiceScene.SetActive(true);
        //}
    }
}

