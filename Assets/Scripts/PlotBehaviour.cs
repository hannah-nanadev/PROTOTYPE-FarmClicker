using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlotBehaviour : MonoBehaviour
{
    [Header("Game Stats")]
    public int balance = 0;
    public int plant = 1;
    int growth = 0;
    bool grown = false;

    // Awake is called on object initialisation
    void Awake()
    {
        
    }

    void ChangePlant(int newPlant)
    {
        plant = newPlant;
    }

    void OnMouseDown()
    {
        GrowPlant();
        if(grown)
            Harvest();
    }

    void GrowPlant()
    {
        growth++;
        if(growth==6)
            grown = true;
    }

    void Harvest()
    {
        balance = balance+(plant*10);
        growth = 0;
        grown = false;
    }
}
