using UnityEngine.UI;
using UnityEngine;

public class NodeUI : MonoBehaviour
{
    public GameObject ui;
    
    private Node target;
    public Text upgradeCost;
    public Text sellCost;
    public Button upgradeButton;

    public Text sellAmount;
    public void SetTarget(Node _target)
    {
        target = _target;
        transform.position = target.GetBuildPosition();

        if (!target.isUpgraded)
        {
            upgradeCost.text = "$ " + target.turretBlueprint.upgradeCost;
            upgradeButton.interactable = true;
        }
        else
        {
            upgradeButton.interactable = false;
            upgradeCost.text = "Done";
        }

        sellAmount.text = "$ " + target.turretBlueprint.GetSaleAmount(target.isUpgraded);

        ui.SetActive(true);
    }

    public void Hide()
    {
        ui.SetActive(false);
    }

    public void Upgrade()
    {
        target.UpgradeTurret();
        BuildManager.instance.DeselectNode();
    }

    public void Sell()
    {

        target.SellTurret();
        BuildManager.instance.DeselectNode();
    }
}
