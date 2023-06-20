using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class NodeUI : MonoBehaviour
{
    private Node target;
    public GameObject gameSpaceCanvas;
    public TextMeshProUGUI upgradeCost;
    public Button upgradeButton;



    public void SetTarget(Node _target)
    {
        target = _target;
        transform.position = target.GetBuildPosition();

        if (!target.isUpgraded)
        {
            upgradeCost.text = "$" + target.turretBlueprint.upgradeCost;
            upgradeButton.interactable = true;
        }
        else
        {
            upgradeCost.text = "DONE";
            upgradeButton.interactable = false;
        }

        gameSpaceCanvas.SetActive(true);
    }



    public void Hide()
    {
        gameSpaceCanvas.SetActive(false);
    }



    public void Upgrade()
    {
        Debug.Log("UPGRADE");
        target.UpgradeTurret();
        BuildManager.Instance.DeselectNode();
    }
}
