using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    BuildManager buildManager;
    public TurretBlueprint standartTurret;
    public TurretBlueprint missileLauncher;
    public TurretBlueprint laserBeamer;




    private void Start()
    {
        buildManager = BuildManager.Instance;
    }



    public void SelectStandartTurret()
    {
        Debug.Log("Standart Turret Selected");
        buildManager.SelectTurretToBuild(standartTurret);
    }



    public void SelectMissileLauncher()
    {
        Debug.Log("Missile Launcher Selected");
        buildManager.SelectTurretToBuild(missileLauncher);
    }



    public void SelectLaserBeamer()
    {
        Debug.Log("Laser Beamer Selected");
        buildManager.SelectTurretToBuild(laserBeamer);
    }
}
