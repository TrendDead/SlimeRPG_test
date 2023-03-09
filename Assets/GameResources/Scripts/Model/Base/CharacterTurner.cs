using System.Collections;
using UnityEngine;

public class CharacterTurner : MonoBehaviour
{
    [SerializeField]
    private float _timeToRotate;

    protected Quaternion _quaternion;

    private void Start()
    {
        _quaternion = transform.rotation;
    }

    /// <summary>
    /// Поврнуться к цели удара
    /// </summary>
    /// <param name="targgetCharacter"></param>
    public void LookOnTarget(BaseCharacter targgetCharacter)
    {
        Vector3 direction = (transform.position - targgetCharacter.transform.position).normalized;
        Quaternion lockRotation = Quaternion.LookRotation(direction);
        StartCoroutine(Rotate(transform.rotation, lockRotation));
    }

    private IEnumerator Rotate(Quaternion startRotait, Quaternion lockRotation)
    {
        for (float i = 0; i <= _timeToRotate; i += Time.deltaTime)
        {
            transform.rotation = Quaternion.Lerp(startRotait, lockRotation, i / _timeToRotate);
            yield return null;
        }
        transform.rotation = lockRotation;
    }

    private void OnDestroy()
    {
        StopCoroutine(Rotate(Quaternion.identity, Quaternion.identity));
    }

    public void LookAhead()
    {
        StartCoroutine(Rotate(transform.rotation, _quaternion));
    }
}
