using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Отображение скиллапа
/// </summary>
public class CoinsToUpView : MonoBehaviour
{
    [SerializeField]
    private Text _textCoinsToStrength;
    [SerializeField]
    private Text _textCoinsToSpeed;
    [SerializeField]
    private Text _textCoinsToHp;
    [SerializeField]
    private Text _textCoinsToHpRecovery;

    public void UpdateInfo(int[] newRequirements)
    {
        _textCoinsToStrength.text = newRequirements[0].ToString();
        _textCoinsToSpeed.text = newRequirements[1].ToString();
        _textCoinsToHp.text = newRequirements[2].ToString();
        _textCoinsToHpRecovery.text = newRequirements[3].ToString();
    }

}
