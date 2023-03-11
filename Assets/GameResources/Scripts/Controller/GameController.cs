using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Контроллер игры
/// </summary>
public class GameController : MonoBehaviour
{
    [SerializeField]
    private EnemyCharacter _enemyPrefab;
    [SerializeField]
    private EnemyCharacter _enemyBossPrefab;
    [SerializeField]
    private Transform _spawnEnemyPosition;
    [SerializeField]
    private Text _gameStatus;

    private List<EnemyCharacter> _enemies = new List<EnemyCharacter>();
    private float _enemyInLevel;
    private float _killedEnemiesCount;
    private int _levelCount = 1;

    private void Start()
    {
        StartLevel();
    }

    private void StartLevel()
    {
        _killedEnemiesCount = 0;
        _enemyInLevel = (int)Random.Range((3 + _levelCount) * (_levelCount * 0.8f), (5 + _levelCount) * (_levelCount * 0.8f));
        //Debug.Log($"_enemyInLevel - {_enemyInLevel}");
        UpdateInfo();
        SpawnEnemy();
    }

    private void UpdateInfo()
    {
        _gameStatus.text = $"Level - {_levelCount} \nPass Percentage - {(int)((_killedEnemiesCount / _enemyInLevel) * 100)}%";
    }

    private void SpawnEnemy()
    {
        if ((_killedEnemiesCount / _enemyInLevel) < 1)
        {
            int waveSpawnCounter = (int)Random.Range((1 + _levelCount) < (_enemyInLevel - _killedEnemiesCount) ? 1 + _levelCount : (_enemyInLevel - _killedEnemiesCount),
                ((1 + _levelCount) * (1 + _levelCount) / 2) < (_enemyInLevel - _killedEnemiesCount) ? 1 + (1 + _levelCount) * (1 + _levelCount) / 2 : (_enemyInLevel - _killedEnemiesCount));
            //Debug.Log($"Спавнит в диапазоне от {((1 + _levelCount) < (_enemyInLevel - _killedEnemiesCount) ? 1 + _levelCount : _enemyInLevel - _killedEnemiesCount)} до {(((1 + _levelCount) * (1 + _levelCount) / 2) < (_enemyInLevel - _killedEnemiesCount) ? 1 + (1 + _levelCount) * (1 + _levelCount) / 2 : _enemyInLevel - _killedEnemiesCount)}, Заспавнил - {waveSpawnCounter}" );
            for (int i = 0; i < waveSpawnCounter; i++)
            {
                Vector3 spawnPoint = new Vector3(_spawnEnemyPosition.position.x + i + 0.5f, 0f, Random.Range(-1.5f, 1.5f));
                var enemy = Instantiate(_enemyPrefab, _spawnEnemyPosition);
                enemy.transform.position = spawnPoint;
                EnemySkillsUp skillsUp = enemy.GetComponent<EnemySkillsUp>();
                skillsUp.UpAllkills((_levelCount - 1) * (_levelCount - 1));
                skillsUp.UpCoinsToDeath(_levelCount - 1);
                _enemies.Add(enemy);
                enemy.IsDead += CheckLevelStatus;
            }
        }
        else
        {
            var enemy = Instantiate(_enemyBossPrefab, _spawnEnemyPosition);
            EnemySkillsUp skillsUp = enemy.GetComponent<EnemySkillsUp>();
            skillsUp.UpAllkills((_levelCount - 1) * 2);
            skillsUp.UpCoinsToDeath(_levelCount - 1);
            skillsUp.UpHpMaxUp(10 * (_levelCount - 1));
            _enemies.Add(enemy);
            enemy.IsDead += CheckLevelStatus;
        }
    }

    private void CheckLevelStatus(EnemyCharacter deadEnemy)
    {
        _enemies.Remove(deadEnemy);
        _killedEnemiesCount += 1;
        UpdateInfo();
        if(_enemies.Count == 0)
        {
            if((_killedEnemiesCount / _enemyInLevel) <= 1)
            {
                SpawnEnemy();
            }
            else
            {
                _levelCount += 1;
                StartLevel();
            }
        }

    }
}
