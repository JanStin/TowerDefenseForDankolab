using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSpot : MonoBehaviour
{
    public GameObject towerPrefab;
    private GameObject _tower;

    
    private void OnMouseUp()
    {
        if (CanPlaceTower())
        {
            _tower = (GameObject)Instantiate(towerPrefab, transform.position, Quaternion.identity);
           // TODO: �������� ������
        }
        else if (CanUpgradeTower())
        {
            
            _tower.GetComponent<TowerData>().IncreaseLevel();
            // TODO: �������� ������
        }
    }

    private bool CanPlaceTower()
    {
        return _tower == null;
    }

    private bool CanUpgradeTower()
    {
        print("d");
        if (_tower != null)
        {
            print("if 1");
            TowerData towerData = _tower.GetComponent<TowerData>();
            TowerLevel nextLevel = towerData.GetNextLevel();
            // TODO: �������� ������. ���-�� ���� �����
            if (nextLevel != null) //&& gameManager.Gold >= nextLevel.cost)
            {
                print("f2");
                return true;
            }
        }

        return false;
    }
}
