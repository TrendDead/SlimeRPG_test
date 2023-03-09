using UnityEngine;
using System.Collections;

/// <summary>
/// ��������� ����� ������
/// </summary>
public class PlayerAttack : BaseAttack
{
    [SerializeField]
    private PlayerBullet _playerBulletPrefab;

    private void Start()
    {
        _targgerTag = EMENY;
        _triggerCollider.isTrigger = true;
    }

    public void UpAttackDamage(float up)
    {
        _attackDamage += up;
        //���������� ��������� ������
    }

    public void UpAttackSpeed(float up)
    {
        _attackSpeed += up;
        //���������� ��������� �������� ������
    }

    public override void Action(bool isAction)
    {
        if(isAction)
        {
            StartCoroutine(Attack(_enemies[0]));
        }
        else
        {
            _baseTurner.LookAhead();
        }
    }

    protected void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<BaseCharacter>(out BaseCharacter enemy))
        {
            if (other.gameObject.tag == _targgerTag && !_enemies.Contains(enemy))
            {
                _enemies.Add(enemy);
                if (_enemies.Count == 1)
                {
                    IsAttack?.Invoke(true);
                }
            }
        }
    }

    protected override IEnumerator Attack(BaseCharacter targgetCharacter)
    {
        bool enemyIsAlive = true;

        while (enemyIsAlive)
        {
            _baseTurner.LookOnTarget(targgetCharacter);
            //������������ ���
            Animation();
            yield return new WaitForSeconds(_timeToAttack / _attackSpeed);
            enemyIsAlive = targgetCharacter.BaseHp.TakeDamage(_attackDamage);
        }
        if (!enemyIsAlive)
        {
            IsEnemyDead(targgetCharacter);
            if(_enemies.Count > 0)
            {
                Action(true);
            }
        }
    }

    private void OnDestroy()
    {
        StopCoroutine(Attack(null));
    }

    protected override void Animation()
    {
        
    }
}
