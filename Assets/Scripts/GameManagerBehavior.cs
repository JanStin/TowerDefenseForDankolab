using UnityEngine;
using UnityEngine.UI;

public class GameManagerBehavior : MonoBehaviour
{
    public Text goldLabel;
    public Text waveLabel;

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

    private int _wave;
    public int Wave
    {
        get
        {
            return _wave;
        }
        set
        {
            _wave = value;
            waveLabel.text = "WAVE:" + _wave + 1;
        }
    }


    private void Start()
    {
        Gold = 1000;
        Wave = 0;
    }
}
