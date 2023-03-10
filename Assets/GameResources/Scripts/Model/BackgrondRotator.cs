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

    private void Start()
    {
        _meshOffset = _meshRenderer[0].sharedMaterial.mainTextureOffset;
    }

    private void OnDisable()
    {
        foreach (var mesh in _meshRenderer)
        {
            mesh.sharedMaterial.mainTextureOffset = _meshOffset;
        }
    }

    private void Update()
    {
        if(IsMove)
        {
            foreach (var mesh in _meshRenderer)
            {
                mesh.sharedMaterial.mainTextureOffset = new Vector2(Mathf.Repeat(Time.time * _speed, 1), _meshOffset.y);
            }
        }
    }
}
