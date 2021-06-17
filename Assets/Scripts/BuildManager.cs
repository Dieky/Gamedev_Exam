using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{

    public static BuildManager instance; // making a singleton

    void Awake()
    {
        instance = this;
    }


    private TurretBlueprint turretToBuild;
    private Node SelectedNode;

    public TurretUI turretUI;


    public bool CanBuild { get { return turretToBuild != null; } } // its a short form of checking if turretToBuild is null or not, could be a normal function that checks the value of turretToBuild and returns true/false if not null/null

    public bool HasMoney { get { return PlayerStats.Money >= turretToBuild.cost; } }
    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
        
        DeselectNode();
    }

    public void SelectNode(Node node)
    {
        if(SelectedNode == node)
        {
            DeselectNode();
            return;
        }
        SelectedNode = node;
        // deselect turret
        turretToBuild = null;
        turretUI.SetTarget(node);
        
    }

    public void DeselectNode()
    {
        SelectedNode = null;
        turretUI.Hide();
    }

    public void BuildTurretOn(Node node)
    {
        if(PlayerStats.Money < turretToBuild.cost)
        {
            Debug.Log("Not enough gold");
            return;
        }

        PlayerStats.Money -= turretToBuild.cost;
        GameObject turret = (GameObject)Instantiate(turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
        node.turret = turret;
    }
}
