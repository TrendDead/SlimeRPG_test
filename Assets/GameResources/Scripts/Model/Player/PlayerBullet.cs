using System.Collections;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    [SerializeField]
    private AnimationCurve _dashCurve;
    [SerializeField]
    private float _shotHeight;

    private Vector3 _startPosition;

    public void Init(Transform target, float timeAttack)
    {
        _startPosition = gameObject.transform.position;
        try
        {
            StartCoroutine(CruveShoot(target, timeAttack));
        }
        catch (System.Exception)
        {
            //Destroy(gameObject);
        }
    }

    private IEnumerator CruveShoot(Transform target, float timeAttack)
    {
        for (float i = 0; i <= timeAttack; i += Time.deltaTime)
        {
            float lerp = i / timeAttack;

            Vector3 positionOffset = ((Vector3.up * _dashCurve.Evaluate(lerp)) * _shotHeight);
            transform.position = new Vector3(Mathf.Lerp(_startPosition.x, target.position.x, lerp), positionOffset.y,
               Mathf.Lerp(_startPosition.z, target.position.z, lerp));

            yield return null;
        }

        Destroy(gameObject);
    }
}
