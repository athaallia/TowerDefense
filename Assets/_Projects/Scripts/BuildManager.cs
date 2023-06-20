using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager Instance;

    public GameObject buildEffect;

    private TurretBlueprint turretToBuild;
    private Node selectedNode;

    public NodeUI nodeUI;

    public bool CanBuild { get { return turretToBuild != null; } }
    public bool HasMoney { get { return PlayerStats.money >= turretToBuild.cost; } }



    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("More than one BuildManager in the scene!");
            return;
        }

        Instance = this;
    }



    public void SelectNode(Node node)
    {
        if (selectedNode == node)
        {
            DeselectNode();
            return;
        }

        selectedNode = node;
        turretToBuild = null;

        nodeUI.SetTarget(node);
    }



    public void DeselectNode()
    {
        selectedNode = null;
        nodeUI.Hide();
    }



    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
        DeselectNode();
    }



    public TurretBlueprint GetTurretToBuild()
    {
        return turretToBuild;
    }
}
