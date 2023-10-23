using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    public TextMeshProUGUI balanceText;
    public PlotBehaviour plot;

    // Update is called once per frame
    void Update()
    {
        balanceText.text = (plot.balance).ToString();
    }
}
