using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCharacter : BaseCharacter
{
    [SerializeField]
    private BackgrondRotator _backgrondRotator;
    
    protected override void ChangeState(bool isAttack)
    {
        _backgrondRotator.IsMove = !isAttack;
        base.ChangeState(isAttack);
    }

    private void OnDestroy()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
