using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    public TextMeshProUGUI balanceText;
    public TextMeshProUGUI watererButton;
    public PlotBehaviour plot;

    // Update is called once per frame
    void Update()
    {
        balanceText.text = "Balance: $" + ((plot.balance).ToString());
        watererButton.text = "Waterer - $" + (plot.getWatererCost().ToString());
    }
}
