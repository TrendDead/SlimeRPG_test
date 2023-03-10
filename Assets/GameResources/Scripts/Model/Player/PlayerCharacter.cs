using UnityEngine;

public class PlayerCharacter : BaseCharacter
{
    [SerializeField]
    private BackgrondRotator _backgrondRotator;
    
    protected override void ChangeState(bool isAttack)
    {
        _backgrondRotator.IsMove = !isAttack;
        base.ChangeState(isAttack);
    }
}
