using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

/// <summary>
/// Базовый класс атаки
/// </summary>
public abstract class BaseAttack : MonoBehaviour
{
    protected const string PLAYER = "Player";
    protected const string EMENY = "Enemy";

    public Action<bool> IsAttack = delegate { };

    [SerializeField]
    private Vector3 _sizeTriggerAttack;
    [SerializeField]
    protected float _attackDamage;
    [SerializeField]
    protected float _attackSpeed;
    [SerializeField]
    protected float _timeToAttack;
    [SerializeField]
    protected BoxCollider _triggerCollider;

    protected List<BaseCharacter> _enemies = new List<BaseCharacter>();
    protected CharacterTurner _baseTurner;
    protected string _targgerTag;


    private void Awake()
    {
        _baseTurner = GetComponent<CharacterTurner>();
        _triggerCollider.size = _sizeTriggerAttack;
    }

    protected virtual void IsEnemyDead(BaseCharacter targgetCharacter)
    {
        _enemies.Remove(targgetCharacter);
        if (_enemies.Count == 0)
        {
            IsAttack?.Invoke(false);
        }
        Destroy(targgetCharacter.gameObject);
    }

    /// <summary>
    /// Поиск ближайшей цели
    /// </summary>
    /// <param name="targgetList"></param>
    /// <returns></returns>
    protected virtual BaseCharacter SelectTargget(List<BaseCharacter> targgetList)
    {
        BaseCharacter targget = null;
        float minDistance = 10000;

        if (targgetList.Count != 0)
        {
            foreach (var enemy in targgetList)
            {
                Vector3 newVector = transform.position - enemy.transform.position;
                if (Mathf.Sqrt(Mathf.Pow(newVector.x, 2) + Mathf.Pow(newVector.y, 2)) <= minDistance)
                {
                    targget = enemy;
                }
            }
        }

        return targget;
    }

    public abstract void Action(bool isAction);

    protected abstract IEnumerator Attack(BaseCharacter targgetCharacter);

    protected abstract void Animation();
}
