using UnityEngine;

public class PlayerCharacter : BaseCharacter
{
    public bool IsAttack { get; private set; }
    
    protected override void ChangeState(bool isAttack)
    {
        IsAttack = isAttack;
        base.ChangeState(isAttack);
    }
}
