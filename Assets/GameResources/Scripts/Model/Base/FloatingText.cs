using System.Collections;
using TMPro;
using UnityEngine;

/// <summary>
/// Компонет порящего текста
/// </summary>
public class FloatingText : MonoBehaviour
{
    [SerializeField]
    private float _lifeTime;
    [SerializeField]
    private float _liftingHeight;

    private TextMeshProUGUI _damageText;

    private void OnEnable()
    {
        _damageText = GetComponent<TextMeshProUGUI>();
        StartCoroutine(LifeTime());
    }

    private IEnumerator LifeTime()
    {
        Vector3 startPostiton = GetComponentInParent<Transform>().position;
        Vector3 highestPosition = startPostiton + (Vector3.up * _liftingHeight);

        for (float i = 0; i < _lifeTime; i += Time.deltaTime)
        {
            float lerp = i / _lifeTime;

            transform.position = new Vector3(startPostiton.x, Mathf.Lerp(startPostiton.y, highestPosition.y, lerp), startPostiton.z);
            _damageText.color = new Color(_damageText.color.r, _damageText.color.g, _damageText.color.b, Mathf.Lerp(1, 0, lerp));

            yield return null;
        }

        Destroy(gameObject);
    }

    public void UpdateText(string damage)
    {
        _damageText.text = $"-{damage}";
    }
}
