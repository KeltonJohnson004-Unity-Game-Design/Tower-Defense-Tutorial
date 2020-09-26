using UnityEngine.EventSystems;
using UnityEngine;

public class Node : MonoBehaviour
{

    public Color hoverColor;
    public Color notEnoughMoneyColor;
    public Vector3 postionOffset;




    private Renderer rend;
    private Color originalColor;

    [Header("Optional")]
    public GameObject turret;

    BuildManager buildManager;
    private void Start()
    {
        rend = GetComponent<Renderer>();
        originalColor = rend.material.color;
        buildManager = BuildManager.instance;
    }

    private void OnMouseDown()
    {
        if (!buildManager.CanBuild)
            return;
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        if (turret != null)
        {
            Debug.Log("Turret Already Built Here! - TODO: Display on Screen");
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
        rend.material.color = originalColor;
    }


    public Vector3 GetBuildPosition()
    {
        return transform.position + postionOffset;
    }
}
