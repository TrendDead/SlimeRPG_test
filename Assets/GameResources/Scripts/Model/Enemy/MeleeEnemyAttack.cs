using System.Collections;
using UnityEngine;

public class MeleeEnemyAttack : BaseAttack
{
    private void Start()
    {
        _targgerTag = PLAYER;
        _triggerCollider.isTrigger = false;
    }

    public void UpAttackDamage(float up)
    {
        _attackDamage += up;
    }

    public void UpAttackSpeed(float up)
    {
        _attackSpeed += up;
    }

    public override void Action(bool isAction)
    {
        if (isAction)
        {
            StartCoroutine(Attack(_enemies[0]));
        }
    }

    private void OnCollisionEnter(Collision collision) //“упо, но не unpdate и € тороплюсь оч, если будет врем€ то поправить
    {

        if (collision.gameObject.TryGetComponent<BaseCharacter>(out BaseCharacter enemy))
        {
            if (collision.gameObject.tag == _targgerTag && !_enemies.Contains(enemy))
            {
                _enemies.Add(enemy);
                if (_enemies.Count == 1)
                {
                    IsAttack?.Invoke(true);
                }
            }
        }
    }

    //protected void OnTriggerEnter(Collider other)
    //{
    //    Debug.Log(gameObject.name);
    //    if (other.TryGetComponent<BaseCharacter>(out BaseCharacter enemy))
    //    {
    //        if (other.gameObject.tag == _targgerTag && !_enemies.Contains(enemy))
    //        {
    //            _enemies.Add(enemy);
    //            if (_enemies.Count == 1)
    //            {
    //                IsAttack?.Invoke(true);
    //            }
    //        }
    //    }
    //}

    protected override IEnumerator Attack(BaseCharacter targgetCharacter)
    {
        bool enemyIsAlive = true;

        while (enemyIsAlive)
        {
            _baseTurner.LookOnTarget(targgetCharacter);

            Animation();

            //FIXME: —верх костыльненько, ждем середины анимации атаки, ѕќѕ–ј¬»“№!!
            yield return new WaitForSeconds(0.3f);

            enemyIsAlive = targgetCharacter.BaseHp.TakeDamage(_attackDamage);

            if (!enemyIsAlive)
            {
                IsEnemyDead(targgetCharacter);

                if (_enemies.Count > 0)
                {
                    Action(true);
                }
            }

            yield return new WaitForSeconds(_timeToAttack / _attackSpeed);
        }
    }
}
