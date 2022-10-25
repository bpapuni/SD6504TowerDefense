using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickFunction : MonoBehaviour
{
    public GameObject towerChoiceScene;
    public Towers towers;
    public Transform platePos;

    public GameObject selectedPlate;


    


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

            Debug.Log(2);
            selectedPlate = gameObject;
            platePos = gameObject.transform;
            towerChoiceScene.SetActive(true);
        }
        


    }

}

