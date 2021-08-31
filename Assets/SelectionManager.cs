using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectionManager : MonoBehaviour
{
    public ShopPanel shopPanel;
    public Material transparentMaterial;

    private Transform positionToPlace;
    bool isMouseClicked;

    void Update()
    {
        isMouseClicked = Input.GetMouseButtonDown(0);
        if (isMouseClicked && !shopPanel.isOpened)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, LayerMask.GetMask("WeaponSpot")))
            {
                hit.transform.GetComponent<Renderer>().material = transparentMaterial;
                hit.transform.GetChild(0).GetComponent<Renderer>().material = transparentMaterial;
                positionToPlace = hit.transform;
                shopPanel.Open();
            }
        }
    }

    public void PlaceWeapon(string name)
    {
        GameObject weapon = Resources.Load<GameObject>("Weapons/" + name);
        if (weapon == null)
        {
            Debug.LogError("Weapon doesnt exist");
            return;
        }
        Destroy(positionToPlace.gameObject);
        Instantiate(weapon, PlacePosition(positionToPlace.position), Quaternion.identity);
        shopPanel.Close();
    }

    private Vector3 PlacePosition(Vector3 pos)
    {
        float X_OFFSET = .25f;
        float Y_OFFSET = .25f;
        return new Vector3(pos.x + X_OFFSET, pos.y, pos.z - Y_OFFSET);
    }
}
