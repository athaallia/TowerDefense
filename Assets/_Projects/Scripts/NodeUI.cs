using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeUI : MonoBehaviour
{
    private Node target;
    public GameObject gameSpaceCanvas;



    public void SetTarget(Node _target)
    {
        target = _target;
        transform.position = target.GetBuildPosition();

        gameSpaceCanvas.SetActive(true);
    }



    public void Hide()
    {
        gameSpaceCanvas.SetActive(false);
    }
}
