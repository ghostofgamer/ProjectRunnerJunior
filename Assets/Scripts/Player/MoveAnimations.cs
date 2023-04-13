using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAnimations : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private const string Speed = "Speed";
    private const string Jump = "Jump";
    private const string Jumpings = "Jumpings";
    private const string IsGrounded = "_isGrounded";
    private const string Slide = "Slide";

    public void Move(float value)
    {
        _animator.SetFloat(Speed, value);
    }

    public void Jumping(bool flag)
    {
        _animator.SetBool(IsGrounded, flag);
    }

    public void SetJumpingsTrigger()
    {
        _animator.SetTrigger(Jumpings);
    }

    public void SetJumpTrigger()
    {
        _animator.SetTrigger(Jump);
    }

    public void SetSlide()
    {
        _animator.SetTrigger(Slide);
    }
}
