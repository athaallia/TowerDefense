using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager Instance;

    public GameObject buildEffect;

    private TurretBlueprint turretToBuild;



    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("More than one BuildManager in the scene!");
            return;
        }

        Instance = this;
    }



    public bool CanBuild { get { return turretToBuild != null; } }
    public bool HasMoney { get { return PlayerStats.money >= turretToBuild.cost; } }



    public void BuildTurretOn(Node node)
    {
        if (PlayerStats.money < turretToBuild.cost)
        {
            Debug.Log("Not enough money!");
            return;
        }

        PlayerStats.money -= turretToBuild.cost;

        // build turret
        GameObject turret = (GameObject)Instantiate(turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
        node.turret = turret;

        GameObject effect = (GameObject)Instantiate(buildEffect, node.GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);

        Debug.Log("Money left: " + PlayerStats.money);
    }



    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
    }
}
