using UnityEngine;
using System.Collections;

/// <summary>
/// Компонент атаки игрока
/// </summary>
public class PlayerAttack : BaseAttack
{
    public float AttackDamage => _attackDamage;
    public float AttackSpeed => _attackSpeed;

    [SerializeField]
    private PlayerBullet _playerBulletPrefab;
    [SerializeField]
    private Transform _bulletSpawnPosition;
    [SerializeField]
    private CoinCounter _coinCounter;


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
        int coinsForEnemy = ((EnemyCharacter)targgetCharacter).CoinForDeath;

        while (enemyIsAlive)
        {
            _baseTurner.LookOnTarget(targgetCharacter);

            PlayerBullet playerBullet = Instantiate(_playerBulletPrefab, _bulletSpawnPosition);
            playerBullet.Init(targgetCharacter.transform, _timeToAttack / _attackSpeed);

            Animation();

            yield return new WaitForSeconds(_timeToAttack / _attackSpeed);
            enemyIsAlive = targgetCharacter.BaseHp.TakeDamage(_attackDamage);
        }
        if (!enemyIsAlive)
        {
            _coinCounter.AddCoin(coinsForEnemy);
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
}
