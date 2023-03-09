using UnityEngine;
using System.Collections;

/// <summary>
/// Компонент атаки игрока
/// </summary>
public class PlayerAttack : BaseAttack
{
    [SerializeField]
    private PlayerBullet _playerBulletPrefab;
    [SerializeField]
    private Transform _bulletSpawnPosition;

    private void Start()
    {
        _targgerTag = EMENY;
        _triggerCollider.isTrigger = true;
    }

    public void UpAttackDamage(float up)
    {
        _attackDamage += up;
        //Отобразить повышение дамага
    }

    public void UpAttackSpeed(float up)
    {
        _attackSpeed += up;
        //Отобразить повышение скорости дамага
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

            PlayerBullet playerBullet = Instantiate(_playerBulletPrefab, _bulletSpawnPosition);
            Debug.Log(1);
            playerBullet.Init(targgetCharacter.transform, _timeToAttack / _attackSpeed);
            Debug.Log(2);

            Animation();

            Debug.Log(3);
            yield return new WaitForSeconds(_timeToAttack / _attackSpeed);
            Debug.Log(4);
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
