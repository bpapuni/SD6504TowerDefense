using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickFunction : MonoBehaviour
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

    public void OnMouseDown()
    {
        if(gameObject.tag == "BuildingPlate")
        {
            selectedPlate = gameObject;
            platePos = gameObject.transform;
            towerChoiceScene.SetActive(true);
        }
    }
}

