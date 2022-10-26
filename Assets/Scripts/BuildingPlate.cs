using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingPlate : MonoBehaviour
{
    public GameObject towerChoiceScene;

    public static GameObject selectedPlate;
    public static Transform platePos;

    private void Awake()
    {
        towerChoiceScene.SetActive(false);
    }

    private void Start()
    {
        
    }

    public void OnMouseUp()
    {
        if(gameObject.tag == "BuildingPlate")
        {
            selectedPlate = gameObject;
            platePos = gameObject.transform;
            towerChoiceScene.SetActive(true);
        }
    }
}

