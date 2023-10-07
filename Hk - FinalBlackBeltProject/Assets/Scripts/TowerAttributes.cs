﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class TowerAttributes : MonoBehaviour
{
    [Header("TowerNumbers")]
    public int MoneyAmount;
    public Text MoneyText; 
    public int SellAmount;
    public Text SellPriceText;
    public int UpgradeAmount;
    public Text UpgradePriceText; 
    public int AttackAmount;
    public Text AttackText;
    public int AttackSpeed;
    public Text AtkSpeedText;
    public int Range;
    public Text RangeAmountText;

    [Header("SpecificFactors")]
    public GameObject[] Targets;
    public GameObject Towers;
    public PlacementScript placementScript;
    bool sellingTower; 
    

    // Start is called before the first frame update
    void Start()
    {
        sellingTower = false; 
        placementScript = placementScript.GetComponent<PlacementScript>(); 
        MoneyAmount = 1000;
        SellAmount = 50; 
    }

    // Update is called once per frame
    void Update()
    {

        MoneyText.text = MoneyAmount.ToString();
        SellPriceText.text = SellAmount.ToString();
        UpgradePriceText.text = UpgradeAmount.ToString(); 
        AttackText.text = AttackAmount.ToString();
        AtkSpeedText.text = AttackSpeed.ToString();
        RangeAmountText.text = Range.ToString(); 
        
        if (placementScript.selectedObject != null)
        {
            sellingTower = true; 
        }

        Targets = GameObject.FindGameObjectsWithTag("Enemy");
        float minDistance = 1000;

        foreach (GameObject Targets in Targets)
        {
            float TargetDistance = Vector3.Distance(transform.position, Targets.transform.position);
            if (TargetDistance < minDistance)
            {
                minDistance = TargetDistance; 
            }
        }
    }

    public void SellButtonPressed()
    {
        if (placementScript.selectedObject.CompareTag("Towers") && sellingTower)
        {
            Destroy(placementScript.selectedObject);
            placementScript.UpgradeCanvas.SetActive(false);
            MoneyAmount += SellAmount;
            sellingTower = false;
            Debug.Log("Button Is Clicked");
            placementScript.CancelButton.SetActive(false); 
        }
    }

    public void CancelButton()
    {
        placementScript.CancelButton.SetActive(false);
        placementScript.UpgradeCanvas.SetActive(false); 
        placementScript.selectedObject = null; 
    }
}
