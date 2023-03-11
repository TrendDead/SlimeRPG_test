using System;

public class EnemyHp : BaseHp
{
    public void UpHpMax(float up)
    {
        _maxHP += up;
        _hp = _maxHP;
        _hpView.ChangeHP(_maxHP, _maxHP);
    }
}
