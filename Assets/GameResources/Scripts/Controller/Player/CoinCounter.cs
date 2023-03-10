using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// —четчик монет
/// </summary>
public class CoinCounter : MonoBehaviour
{
    [SerializeField]
    private Text _coinText;

    private int _coins = 0;

    public void AddCoin(int coin)
    {
        _coins += coin;
        _coinText.text = _coins.ToString();
    }

    public bool DleteCoin(int coin)
    {
        if (_coins - coin < 0)
        {
            return false;
        }
        _coins -= coin;
        _coinText.text = _coins.ToString();
        return true;
    }
}
