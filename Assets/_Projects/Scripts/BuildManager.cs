using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager Instance;

    private GameObject turretToBuild;
    public GameObject standardTurretPrefab;



    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("More than one BuildManager in the scene!");
            return;
        }
    
        Instance = this;
    }



    private void Start()
    {
        turretToBuild = standardTurretPrefab;
    }



    public GameObject GetTurretToBuild()
    {
        return turretToBuild;
    }
}
