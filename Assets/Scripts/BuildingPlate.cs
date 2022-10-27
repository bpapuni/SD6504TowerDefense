using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingPlate : MonoBehaviour
{
    BuildManager buildManager;
    public GameObject towerChoiceScene;
    
    public Color hoverColor;

    private GameObject tower;
    private Renderer rend;
    private Color startColor;


    private void Start()
    {
        buildManager = BuildManager.instance;
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }

    void OnMouseEnter()
    {
        if (tower != null)
            return;
        rend.material.color = hoverColor;
    }

    void OnMouseExit()
    {
        rend.material.color = startColor;
    }

    void OnMouseUp()
    {
        if (tower != null)
            return;

        towerChoiceScene.SetActive(true);
        buildManager.selectedPlate = gameObject;

        //if(gameObject.tag == "BuildingPlate")
        //{
        //    selectedPlate = gameObject;
        //    platePos = gameObject.transform;
        //    towerChoiceScene.SetActive(true);
        //}
    }

    public void SetTower(GameObject _tower)
    {
        tower = _tower;
    }
}

