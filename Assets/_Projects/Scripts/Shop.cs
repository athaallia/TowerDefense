using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    BuildManager buildManager;
    public TurretBlueprint standartTurret;
    public TurretBlueprint missileLauncher;



    private void Start()
    {
        buildManager = BuildManager.Instance;
    }



    public void SelectStandartTurret()
    {
        Debug.Log("Standart Turret Purchase");
        buildManager.SelectTurretToBuild(standartTurret);
    }



    public void SelectMissileLauncher()
    {
        Debug.Log("Missile Launcher Purchase");
        buildManager.SelectTurretToBuild(missileLauncher);
    }
}
