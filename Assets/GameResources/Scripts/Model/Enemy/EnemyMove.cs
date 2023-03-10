using UnityEngine;

public class EnemyMove : BaseMove
{
    [SerializeField]
    private float _moveSpeed = 1;

    private bool _isMove = false;

    public override void Action(bool isAction)
    {
        _isMove = isAction;
        // Тут запускаем анимацию
    }
    private void Update()
    {
        if (_isMove)
        {
            transform.position += Vector3.left * _moveSpeed * Time.deltaTime;
        }
    }

    protected override void Animation()
    {
       
    }
}
