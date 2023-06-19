using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Color notEnoughMoneyColor;
    private Color startColor;

    private Renderer rend;

    [Header("Optional")]
    public GameObject turret;

    public Vector3 positionOffset;
    public BuildManager buildManager;



    private void Start()
    {
        buildManager = BuildManager.Instance;

        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }



    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }



    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;
            
        if (!buildManager.CanBuild)
            return;

        if (turret != null)
        {
            Debug.Log("Cant build here!");
            return;
        }

        buildManager.BuildTurretOn(this);
    }



    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (!buildManager.CanBuild)
            return;

        if (buildManager.HasMoney)
        {
            rend.material.color = hoverColor;
        }
        else
        { 
            rend.material.color = notEnoughMoneyColor;
        }
    }



    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
