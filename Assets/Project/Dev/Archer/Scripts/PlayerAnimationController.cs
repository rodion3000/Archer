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
    private bool isAttacking = false; // Флаг для отслеживания атаки
    private bool isFinishingAttack = false; // Флаг для отслеживания завершения атаки
    
    private PlayerController _playerController;
    private PlayerAttack _playerAttack;

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
        
    }
    
}
