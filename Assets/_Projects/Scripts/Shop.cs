using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    BuildManager buildManager;



    private void Start()
    {
        buildManager = BuildManager.Instance;
    }



    public void PurchaseStandartTurret()
    {
        Debug.Log("Standart Turret Purchase");
        buildManager.SetTurretToBuild(buildManager.standardTurretPrefab);
    }



    public void PurchaseMissileLauncher()
    {
        Debug.Log("Missile Launcher Purchase");
        buildManager.SetTurretToBuild(buildManager.missileLauncherPrefab);
    }
}
