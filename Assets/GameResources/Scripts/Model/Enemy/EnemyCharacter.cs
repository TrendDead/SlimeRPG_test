using System;
using UnityEngine;

public class EnemyCharacter : BaseCharacter
{
    public Action<EnemyCharacter> IsDead = delegate { };
    public int CoinForDeath => _coinForDeath;

    [SerializeField]
    private int _coinForDeath = 1;

    public void UpCoinForDeath(int up)
    {
        _coinForDeath += up;
    }

    private void OnDestroy()
    {
        IsDead?.Invoke(this);
    }
}
