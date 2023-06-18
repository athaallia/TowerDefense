using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    private Color startColor;

    private Renderer rend;

    private GameObject turret;
    public Vector3 positionOffset;

    public BuildManager buildManager;



    private void Start()
    {
        buildManager = BuildManager.Instance;

        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }



    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;
            
        if (buildManager.GetTurretToBuild() == null)
            return;

        if (turret != null)
        {
            Debug.Log("Cant build here!");
            return;
        }

        // Build turret
        GameObject turretToBuild = buildManager.GetTurretToBuild();
        turret = (GameObject)Instantiate(turretToBuild, transform.position + positionOffset, transform.rotation);
    }



    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (buildManager.GetTurretToBuild() == null)
            return;

        rend.material.color = hoverColor;
    }



    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
