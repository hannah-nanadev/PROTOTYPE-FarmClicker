using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlotBehaviour : MonoBehaviour
{
    [Header("Game Stats")]
    public int balance = 0;
    public int defaultPlant = 1;
    public bool defaultGrowthStatus = false;
    public int fertilizer = 0;
    public int waterers = 0;
    int growth = 0;
    bool stopped = false;

    private Animator anim;
    public ParticleSystem water;
    public ParticleSystem harvestEffect;
    public ParticleSystem manualWater;

    // Awake is called on object initialisation
    void Awake()
    {
        anim = GetComponent<Animator>();
        ChangePlant(defaultPlant);
        SetGrowthStatus(defaultGrowthStatus);
    }

    //FixedUpdate is called every fixed framerate frame
    void FixedUpdate()
    {
        if(!stopped)
        {
            for(int i = 0; i<waterers; i++)
            {
                ClickPlot();
            }
            StartCoroutine(waitASec());
        }

    }

    IEnumerator waitASec()
    {
        stopped = true;
        yield return new WaitForSeconds(1.0f);
        stopped = false;
    }

    //Detects clicks on object
    void OnMouseDown()
    {
        ClickPlot();
        AudioManager.instance.WaterSound();
    }

    void ClickPlot()
    {
        //Controller for whether or not plant is grown or harvested
        if(GrowthStatus())
            Harvest();
        else
            GrowPlant();
    }

    //Game-related methods
    void GrowPlant()
    {
        growth++;
        manualWater.Emit(25);
        if(growth==5)
        {
            SetGrowthStatus(true);
            AudioManager.instance.GrowSound();
        }
    }

    void Harvest()
    {
        int balanceMultiplier = fertilizer+1;
        int plantMultiplier = (int)Mathf.Pow(10f, (float)CurrentPlant());

        balance = balance+(plantMultiplier*balanceMultiplier);
        growth = 0;
        SetGrowthStatus(false);
        AudioManager.instance.PopSound();
        harvestEffect.Emit(50);
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
            balance = balance-500;
            ChangePlant(2);
            Debug.Log(balance);
        }
    }

    public void BuyCarrots()
    {
        if(balance>=50000)
        {
            balance = balance-50000;
            ChangePlant(3);
            Debug.Log(balance);
        }
    }

    public void BuyWaterer()
    {
        int cost = getWatererCost();
        if(balance>=cost)
        {
            balance = balance-cost;
            waterers++;
        }

        //Start water particles on waterer purchase
        water.Play();
    }

    //Calculates current cost of waterers, scaling up as you get more
    public int getWatererCost()
    {
        return ((int)Mathf.Pow((float)(waterers+1), 2))*50;
    }

    public void BuyFertilizer()
    {
        int cost = getFertilizerCost();
        if(balance>=cost)
        {
            balance = balance-cost;
            fertilizer++;
        }
    }

    //Similar method to waterercost but for fertilizer
    public int getFertilizerCost()
    {
        return ((int)Mathf.Pow((float)(fertilizer+1), 2))*100;
    }

}
