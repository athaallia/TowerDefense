using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    private Color startColor;

    private Renderer rend;

    private GameObject turret;
    public Vector3 positionOffset;



    private void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }



    private void OnMouseDown()
    {
        if (turret != null)
        {
            Debug.Log("Cant build here!");
            return;
        }

        // Build turret
        GameObject turretToBuild = BuildManager.Instance.GetTurretToBuild();
        turret = (GameObject)Instantiate(turretToBuild, transform.position + positionOffset, transform.rotation);
    }



    private void OnMouseEnter()
    {
        rend.material.color = hoverColor;
    }



    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
