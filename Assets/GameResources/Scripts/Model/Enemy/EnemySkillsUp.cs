using UnityEngine;

/// <summary>
/// Компонент прокачки врагов
/// </summary>
public class EnemySkillsUp : MonoBehaviour
{
    [SerializeField]
    private BaseCharacter _baseCharacter;

    public void UpAttackStrength(int coeficientToUp)
    {
        ((MeleeEnemyAttack)_baseCharacter.BaseAttack).UpAttackDamage(0.1f * coeficientToUp);
    }

    public void UpAttackSpeed(int coeficientToUp)
    {
        ((MeleeEnemyAttack)_baseCharacter.BaseAttack).UpAttackSpeed(0.1f * coeficientToUp);
    }

    public void UpHpMaxUp(int coeficientToUp)
    {
        ((EnemyHp)_baseCharacter.BaseHp).UpHpMax(1f * coeficientToUp);
    }

    public void UpCoinsToDeath(int coeficientToUp)
    {
        ((EnemyCharacter)_baseCharacter).UpCoinForDeath(coeficientToUp);
    }

    public void UpAllkills(int coeficientToUp)
    {
        UpAttackStrength(coeficientToUp);
        UpAttackSpeed(coeficientToUp);
        UpHpMaxUp(coeficientToUp);
    }
}
