using UnityEngine;

/// <summary>
/// Аниматор персонажа
/// </summary>
[RequireComponent(typeof(Animator))]
public class AnimationController : MonoBehaviour
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void StartAnimationDamage()
    {
        _animator.SetTrigger("TakeDamage");
    }

    public void StartAnimationAttack()
    {
        _animator.SetTrigger("Attack");
    }

    public void WalkAnimation(bool isWalk)
    {
        _animator.SetBool("Walk", isWalk);
    }

}
