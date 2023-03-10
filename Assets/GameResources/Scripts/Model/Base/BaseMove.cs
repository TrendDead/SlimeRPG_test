using UnityEngine;
using System.Collections;

/// <summary>
/// ������� ����� ��������
/// </summary>
public abstract class BaseMove : MonoBehaviour
{
    [SerializeField]
    private AnimationController _animationController;
    public abstract void Action(bool isAction);
    protected virtual void Animation(bool isMove)
    {
        _animationController.WalkAnimation(isMove);
    }
}
