using UnityEngine;
using UnityEngine.UI;

public class GameManagerBehavior : MonoBehaviour
{
    public Text goldLabel;

    public bool gameOver = false;

    private int _gold;
    public int Gold
    {
        get
        {
            return _gold;
        }
        set
        {
            _gold = value;
            goldLabel.GetComponent<Text>().text = "GOLD:" + _gold;
        }
    }

    private void Start()
    {
        Gold = 1000;
    }
}
