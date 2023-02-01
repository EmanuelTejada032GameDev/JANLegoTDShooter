using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    [SerializeField] private TextMeshProUGUI _enemiesKilledText;
    private int _enemiesKilledValue = 0;



    //[SerializeField] private TMPro


    private void Awake()
    {
        _enemiesKilledText.text = "0";
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(Instance);
        }
    }


    public void UpdateEnemiesKilled(int value)
    {
        _enemiesKilledValue = _enemiesKilledValue + value;
        _enemiesKilledText.text = (_enemiesKilledValue).ToString();
    }

    public int GetEnemiesKilled()
    {
        return _enemiesKilledValue;
    }


}
