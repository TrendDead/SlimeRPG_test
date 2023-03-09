using System.Collections;
using UnityEngine;

/// <summary>
/// Комопнент работы с жизнями игрока
/// </summary>
public class PlayerHp : BaseHp
{
    [SerializeField]
    private float _hpRegen;
    [SerializeField]
    private float _timeToRegen;

    private void Start()
    {
        StartCoroutine(HPRegenerator(_timeToRegen));
    }

    private IEnumerator HPRegenerator(float timeToRegen)
    {
        while (true)
        {
            yield return new WaitForSeconds(timeToRegen);
            AddHp(_hpRegen);
        }
    }

    private void OnDestroy()
    {
        StopCoroutine(HPRegenerator(_timeToRegen));
    }

    protected override void Animation()
    {
        
    }

    public void UpHpMax(float up)
    {
        _maxHP += up;
        //_textHP.text = Math.Round(_hp, 2).ToString(); Обновить инфу на панели
        AddHp(up);
    }

    public void UpHpRegen(float up)
    {
        _hpRegen += up;
        //_textHPR.text = Math.Round(_hpRegen, 2).ToString();  Обновить инфу на панели
    }

    private void AddHp(float addHp)
    {
        _hp = _hp + addHp <= _maxHP ? _hp + addHp : _maxHP;
        //_hpView.UpdateHpInfo();
        //_hpBatText.text = Math.Round(_hp, 2).ToString();
        //_hpBar.fillAmount = _hp / _maxHp;
    }
}
