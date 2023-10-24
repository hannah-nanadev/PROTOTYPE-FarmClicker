using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    public TextMeshProUGUI balanceText;
    public TextMeshProUGUI watererCount;
    public TextMeshProUGUI fertilizerCount;

    public TextMeshProUGUI watererButton;
    public TextMeshProUGUI fertilizerButton;

    public PlotBehaviour plot;

    // Update is called once per frame
    void Update()
    {
        watererButton.text = "Waterer - $" + (plot.getWatererCost().ToString());
        fertilizerButton.text = "Fertilizer - $" + (plot.getFertilizerCost().ToString());

        balanceText.text = "Balance: $" + (plot.balance.ToString());
        watererCount.text = "Waterers: " + (plot.waterers.ToString());
        fertilizerCount.text = "Fertilizer: " + (plot.fertilizer.ToString());
    }
}
