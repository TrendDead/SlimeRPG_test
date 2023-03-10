using UnityEngine;

/// <summary>
/// ѕќвышение уровн€ навыков персонажа
/// </summary>
public class PlayerSkillsUp : MonoBehaviour
{
    [SerializeField]
    private BaseCharacter _baseCharacter;
    [SerializeField]
    private CoinCounter _coinCounter;
    [SerializeField]
    private PlayerStatsView _playerStatsView;
    [SerializeField]
    private CoinsToUpView _coinsToUpView;

    private int[] _requirementsForUp = new int[] { 1, 1, 1, 1 };

    public void UpAttackStrength()
    {
        bool isSucsess = _coinCounter.DleteCoin(_requirementsForUp[0]);
        if (isSucsess)
        {
            _requirementsForUp[0] += 1;
            ((PlayerAttack)_baseCharacter.BaseAttack).UpAttackDamage(0.1f);
            _playerStatsView.UpdateInfo();
            _coinsToUpView.UpdateInfo(_requirementsForUp);
        }
    }

    public void UpAttackSpeed()
    {
        bool isSucsess = _coinCounter.DleteCoin(_requirementsForUp[1]);
        if (isSucsess)
        {
            _requirementsForUp[1] += 1;
            ((PlayerAttack)_baseCharacter.BaseAttack).UpAttackSpeed(0.1f);
            _playerStatsView.UpdateInfo();
            _coinsToUpView.UpdateInfo(_requirementsForUp);
        }
    }

    public void UpHpMaxUp()
    {
        bool isSucsess = _coinCounter.DleteCoin(_requirementsForUp[2]);
        if (isSucsess)
        {
            _requirementsForUp[2] += 1;
            ((PlayerHp)_baseCharacter.BaseHp).UpHpMax(1f);
            _playerStatsView.UpdateInfo();
            _coinsToUpView.UpdateInfo(_requirementsForUp);
        }
    }

    public void UpHpRegen()
    {
        bool isSucsess = _coinCounter.DleteCoin(_requirementsForUp[3]);
        if (isSucsess)
        {
            _requirementsForUp[3] += 1;
            ((PlayerHp)_baseCharacter.BaseHp).UpHpRegen(0.1f);
            _playerStatsView.UpdateInfo();
            _coinsToUpView.UpdateInfo(_requirementsForUp);
        }
    }
}
