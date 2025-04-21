using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine;
using Spine.Unity;
using Zenject;

public class PlayerAnimationController : MonoBehaviour
{
    [SpineAnimation] public string idle;
    [SpineAnimation] public string attack_start;
    [SpineAnimation] public string attack_target;
    [SpineAnimation] public string attack_finish;

    private SkeletonAnimation skeletonAnimation;
    public Spine.AnimationState spineAnimationState;
    public Skeleton skeleton;

    private Bone gunBone; // Ссылка на кость "gun"
    private Bone bulletBone; // Ссылка на кость "bullet"
    private Bone string_c;
    private PlayerController _playerController;
    private PlayerAttack _playerAttack;
    private bool dfdf;

    [Inject]
    private void Construct(PlayerController playerController, PlayerAttack playerAttack)
    {
        _playerController = playerController;
        _playerAttack = playerAttack;
    }
    private void Start()
    {
        skeletonAnimation = GetComponent<SkeletonAnimation>();
        spineAnimationState = skeletonAnimation.AnimationState;
        skeleton = skeletonAnimation.Skeleton;

        gunBone = skeleton.FindBone("gun");
        bulletBone = skeleton.FindBone("bullet");
        string_c = skeleton.FindBone("string_c");
    }
    
    private void PlayStartAttackAnimation()
    {
        var currentAnimation = spineAnimationState.GetCurrent(0);

        if (currentAnimation == null || currentAnimation.Animation.Name != attack_start)
        {
            spineAnimationState.SetAnimation(0, attack_start, false);
        }
    }
}
