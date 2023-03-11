using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Компонент отображения хп
/// </summary>
public class HpView : MonoBehaviour
{
    [SerializeField]
    protected Image _hpBar;
    [SerializeField]
    private TextMeshProUGUI _hpText;
    [SerializeField]
    private FloatingText _floatingTextPrefab;
    [SerializeField]
    private Transform _floatingTextPositionStart;

    private Transform _camera;

    private void Start()
    {
        _camera = Camera.main.transform;
    }

    private void Update()
    {
        transform.LookAt(transform.position + _camera.forward);
    }

    public void ChangeHP(float newHP, float maxHp, float takenDamage = 0)
    {
        _hpText.text = Math.Round(newHP, 2).ToString();
        _hpBar.fillAmount = newHP / maxHp;
        if (takenDamage != 0)
        {
            var text = Instantiate(_floatingTextPrefab, _floatingTextPositionStart);
            text.transform.localPosition = _floatingTextPositionStart.position;
            text.UpdateText(Math.Round(takenDamage, 2).ToString());
        }
    }
}
