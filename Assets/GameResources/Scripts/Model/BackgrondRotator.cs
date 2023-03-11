using UnityEngine;

/// <summary>
/// Компонент вращения задников
/// </summary>
public class BackgrondRotator : MonoBehaviour
{
    public bool IsMove = true;

    [SerializeField]
    private float _speed = 1;
    [SerializeField]
    private MeshRenderer[] _meshRenderer;

    private Vector2 _meshOffset;
    private float _timer = 0;

    private void Start()
    {
        _meshOffset = _meshRenderer[0].sharedMaterial.mainTextureOffset;
    }

    private void Update()
    {
        if(IsMove)
        {
            _timer += Time.deltaTime;
            foreach (var mesh in _meshRenderer)
            {
                mesh.sharedMaterial.mainTextureOffset = new Vector2(Mathf.Repeat(_timer * _speed, 1), _meshOffset.y);
            }
        }
    }
}
