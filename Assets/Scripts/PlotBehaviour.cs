using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlotBehaviour : MonoBehaviour
{
    [Header("Game Stats")]
    public int balance = 0;
    public int defaultPlant = 1;
    public bool defaultGrowthStatus = false;
    public int balanceMultiplier = 1;
    int growth = 0;

    private Animator anim;

    // Awake is called on object initialisation
    void Awake()
    {
        anim = GetComponent<Animator>();
        ChangePlant(defaultPlant);
        SetGrowthStatus(defaultGrowthStatus);
    }

    //Detects clicks on object
    void OnMouseDown()
    {
        if(GrowthStatus())
            Harvest();
        else
            GrowPlant();
    }

    void GrowPlant()
    {
        growth++;
        AudioManager.instance.WaterSound();
        if(growth==5)
            SetGrowthStatus(true);
            AudioManager.instance.GrowSound();
    }

    void Harvest()
    {
        balance = balance+(CurrentPlant()*10*balanceMultiplier);
        growth = 0;
        SetGrowthStatus(false);
        AudioManager.instance.PopSound();
    }

    //Getter/setter methods to make it easier to get and change growth status and current plant as those are held in animator
    bool GrowthStatus()
    {
        return anim.GetBool("grown");
    }

    void SetGrowthStatus(bool status)
    {
        anim.SetBool("grown", status);
    }

    int CurrentPlant()
    {
        return anim.GetInteger("plant");
    }

    void ChangePlant(int newPlant)
    {
        anim.SetInteger("plant", newPlant);
    }

    //Responses to UI buttons
    public void BuyTomatoes()
    {
        if(balance>=500)
        {
            balance = balance-100;
            ChangePlant(2);
            Debug.Log(balance);
        }
    }

    public void BuyCarrots()
    {
        if(balance>=1000)
        {
            balance = balance-1000;
            ChangePlant(3);
            Debug.Log(balance);
        }
    }

}
