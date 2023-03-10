using UnityEngine;
using UnityEngine.UI;

public class PlayerStatsView : MonoBehaviour
{
    [SerializeField]
    private Text _textAttackStrength;
    [SerializeField]
    private Text _textAttckSpeed;
    [SerializeField]
    private Text _textHp;
    [SerializeField]
    private Text _textHpRecovery;
    [SerializeField]
    private BaseCharacter _baseCharacter;

    private void Start()
    {
        UpdateInfo();
    }

    public void UpdateInfo()
    {
        _textAttackStrength.text = ((PlayerAttack)_baseCharacter.BaseAttack).AttackDamage.ToString();
        _textAttckSpeed.text = ((PlayerAttack)_baseCharacter.BaseAttack).AttackSpeed.ToString();
        _textHp.text = ((PlayerHp)_baseCharacter.BaseHp).MaxHP.ToString();
        _textHpRecovery.text = ((PlayerHp)_baseCharacter.BaseHp).HPRegen.ToString();
    }
}
