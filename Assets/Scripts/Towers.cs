using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Towers : MonoBehaviour
{

    public GameObject Tower;
    public GameObject towerRange;

    private int frostTowerCount = 0;

    private Button frostTowerBtn;
    private Button ballistaTowerBtn;
    private Button tinyTowerBtn;

    public GameObject towerChoiceScene;

    private Transform selectedTowerLocation;
    private int damage;
    private float reloadTime;




    public Towers() { } //Default Constructor

    public Towers(Transform _towerLocation)
    {
        this.selectedTowerLocation = _towerLocation;
    }


    public Towers(Transform _towerLocation, int _damage, float _reloadTime)
    {
        this.selectedTowerLocation = _towerLocation;
        this.damage = _damage;
        this.reloadTime = _reloadTime;
    }

    public Transform TowerLocation
    {
        get { return selectedTowerLocation; }
        set { selectedTowerLocation = value; }

    }

    public int Damage
    {
        get { return damage; }
        set { damage = value; }
    }

    public float ReloadTIme
    {
        get { return reloadTime; }
        set { reloadTime = value; }

    }

    private void Awake()
    {


    }

    // Start is called before the first frame update
    void Start()
    {
        //clickFunction = GameObject.FindGameObjectWithTag("BuildingPlate").GetComponent<ClickFunction>();
        

    }

    void Update()
    {
    }

    public void CreateTower(GameObject Tower)
    {
        towerChoiceScene.SetActive(false);

        if (gameObject.CompareTag("FrostTower") || gameObject.CompareTag("BallistaTower") || gameObject.CompareTag("TinyTower"))
        {
            Instantiate(Tower, BuildingPlate.selectedPlate.transform.position, BuildingPlate.selectedPlate.transform.rotation);
            Vector3 rangePosition = new Vector3(BuildingPlate.selectedPlate.transform.position.x, 0, BuildingPlate.selectedPlate.transform.position.z);
            Instantiate(towerRange, rangePosition, BuildingPlate.selectedPlate.transform.rotation);

            BuildingPlate.selectedPlate = null;
        }



    }

    public void DestoryTower()
    {

    }

    public void EditTower()
    {

    }

    public void OnMouseDown()
    {
        if (gameObject.tag == "BuildingPlate")
        {

        }
    }
}
