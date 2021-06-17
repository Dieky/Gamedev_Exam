using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{

    BuildManager buildManager;
    [Header("Optional")]
    public GameObject turret;

    public Color hoverColor;
    public Color notEnoughMoneyColor;
    public Vector3 positionOffset;

    private Renderer rend;

    private Color startColor;

    void OnMouseEnter()
    {

         // prevents mouse from clicking on a node when a game UI is in front of the node. Example is to avoid placing a turret when selecting a turret
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        if (!buildManager.CanBuild)
        {
            return;
        }
        if(buildManager.HasMoney)
        {
            rend.material.color = hoverColor;
        }else
        {
            rend.material.color = notEnoughMoneyColor;
        }
    }

    void OnMouseExit()
    {
        rend.material.color = startColor;
    }
    void Start()
    {
        buildManager = BuildManager.instance;
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }

    void OnMouseDown()
    {
        // prevents mouse from clicking on a node when a game UI is in front of the node. Example is to avoid placing a turret when selecting a turret
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (turret != null)
        {
            buildManager.SelectNode(this);
            return;

        }
        if (!buildManager.CanBuild)
        {
            return;
        }

        // build turret
        buildManager.BuildTurretOn(this);
        // GameObject turretToBuild = buildManager.GetTurretToBuild();
        // turret = (GameObject)Instantiate(turretToBuild, transform.position + positionOffset, transform.rotation);

    }

}
