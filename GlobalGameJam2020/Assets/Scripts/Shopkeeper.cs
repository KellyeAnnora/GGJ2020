using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shopkeeper : MonoBehaviour
{
    PlayerPickups playerPickups;
    UpgradeSystem upgradeSystem;

    Upgrade currentUpgrade;
    public Upgrade[] upgrades;

    private void Start()
    {
        playerPickups = GameObject.FindWithTag("Player").GetComponent<PlayerPickups>();
        upgradeSystem = GameObject.FindWithTag("Player").GetComponent<UpgradeSystem>();
    }

    //This is the function that gets called from the dialog system
    void AttemptPurchase(int upgradeIndex)
    {
        currentUpgrade = upgrades[upgradeIndex];
        int currentCount = playerPickups.partCount;
        if (CheckPartCount(currentCount, currentUpgrade.cost) == true)
        {
            CompletePurchase(currentUpgrade);
            Debug.Log("Player has purchased " + currentUpgrade.name);
        }
    }

    bool CheckPartCount(int parts, int cost)
    {
        if (parts >= cost)
        {
            return true;
        } else
        {
            return false;
        }
    }

    void CompletePurchase (Upgrade upgrade)
    {
        upgradeSystem.UpdatePartsCount(-currentUpgrade.cost);
        upgradeSystem.UpdateHP(currentUpgrade.HPModifier);
        upgradeSystem.UpdatePower(currentUpgrade.powerModifier);
        upgradeSystem.UpdateSpeed(currentUpgrade.speedModifier);
    }

    //checks to see if player has enough parts
    //if they do have enough parts
    //returns true
    //runs the upgrade
    //tells player they got an upgrade

}
