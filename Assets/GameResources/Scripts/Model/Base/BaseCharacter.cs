using UnityEngine;

/// <summary>
/// Базовый класс персонажа
/// </summary>
public abstract class BaseCharacter : MonoBehaviour
{
    public BaseHp BaseHp => _baseHp;
    public BaseAttack BaseAttack => _baseAttack;
    public BaseMove BaseMove => _baseMove;

    protected BaseHp _baseHp;
    protected BaseAttack _baseAttack;
    protected BaseMove _baseMove;

    private void Awake()
    {
        _baseAttack = GetComponent<BaseAttack>();
        _baseMove = GetComponent<BaseMove>();
        _baseHp = GetComponent<BaseHp>();

        _baseAttack.IsAttack += ChangeState;
    }

    private void Start()
    {
        ChangeState(false);
    }

    private void OnDestroy()
    {
        _baseAttack.IsAttack -= ChangeState;
    }

    protected virtual void ChangeState(bool isAttack)
    {
        //Debug.Log($"{gameObject.name} - status isAttack - {isAttack}");
        _baseAttack.Action(isAttack);
        _baseMove.Action(!isAttack);
    }

}
