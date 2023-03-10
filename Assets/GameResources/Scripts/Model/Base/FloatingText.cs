using System.Collections;
using TMPro;
using UnityEngine;

/// <summary>
/// �������� �������� ������
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

    //TODO: ������� ����������� ������������
    private IEnumerator LifeTime()
    {
        Vector3 startPostiton = GetComponentInParent<Transform>().localPosition;
        Vector3 highestPosition = startPostiton + (Vector3.up * _liftingHeight);

        for (float i = 0; i < _lifeTime; i += Time.deltaTime)
        {
            float lerp = i / _lifeTime;


            transform.localPosition = new Vector3(startPostiton.x, Mathf.Lerp(startPostiton.y, highestPosition.y, lerp), startPostiton.z);

            yield return null;
        }

        Destroy(gameObject);
    }

    public void UpdateText(string damage)
    {
        _damageText.text = $"-{damage}";
    }
}
