using UnityEngine;

/// <summary>
/// Базовый класс жизней
/// </summary>
public abstract class BaseHp : MonoBehaviour
{
    [SerializeField]
    protected float _maxHP;
    [SerializeField]
    protected float _hp;
    [SerializeField]
    protected HpView _hpView;

    private void OnEnable()
    {
        _hp = _maxHP;
    }

    public bool TakeDamage(float damage)
    {
        _hp -= damage;

        Animation();
        //_hpView.ShowDamage(damage, _hp);

        if (_hp <= 0)
        {
            return false;
        }

        return true;
    }

    protected abstract void Animation();
}
