using UnityEngine;
using System.Collections;

/// <summary>
/// базовый класс движения
/// </summary>
public abstract class BaseMove : MonoBehaviour
{
    public abstract void Action(bool isAction);
    protected abstract void Animation();
}
