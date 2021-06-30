using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSpot : MonoBehaviour
{
    public GameObject towerPrefab;
    private GameObject _tower;

    private bool CanPlaceTower()
    {
        return _tower == null;
    }

    private void OnMouseUp()
    {
        if (CanPlaceTower())
        {
            _tower = (GameObject)Instantiate(towerPrefab, transform.position, Quaternion.identity);
           // TODO: Вычитать золото
        }
    }
}
