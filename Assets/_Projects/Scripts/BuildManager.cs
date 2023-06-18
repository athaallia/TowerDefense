using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager Instance;

    public GameObject standardTurretPrefab;
    public GameObject missileLauncherPrefab;
    private GameObject turretToBuild;



    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("More than one BuildManager in the scene!");
            return;
        }

        Instance = this;
    }



    public GameObject GetTurretToBuild()
    {
        return turretToBuild;
    }



    public void SetTurretToBuild(GameObject turret)
    {
        turretToBuild = turret;
    }
}
