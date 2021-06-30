using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSpot : MonoBehaviour
{
    public GameObject towerPrefab;
    private GameObject _tower;
    private GameManagerBehavior _gameManager;

    private void Start()
    {
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManagerBehavior>();
    }

    private void OnMouseUp()
    {
        if (CanPlaceTower())
        {
            _tower = (GameObject)Instantiate(towerPrefab, transform.position, Quaternion.identity);

            _gameManager.Gold -= _tower.GetComponent<TowerData>().CurrentLevel.cost;
        }
        else if (CanUpgradeTower())
        {
            
            _tower.GetComponent<TowerData>().IncreaseLevel();

            _gameManager.Gold -= _tower.GetComponent<TowerData>().CurrentLevel.cost;
        }
    }

    private bool CanPlaceTower()
    {
        int cost = towerPrefab.GetComponent<TowerData>().levels[0].cost;

        return _tower == null && _gameManager.Gold >= cost;
    }

    private bool CanUpgradeTower()
    {
        print("d");
        if (_tower != null)
        {
            print("if 1");
            TowerData towerData = _tower.GetComponent<TowerData>();
            TowerLevel nextLevel = towerData.GetNextLevel();
            
            if (nextLevel != null&& _gameManager.Gold >= nextLevel.cost)
            {
                print("f2");
                return true;
            }
        }

        return false;
    }
}
