using System;
using System.Collections;
using System.Collections.Generic;
using Spine.Unity;
using UnityEngine;

public class SpineArcher : MonoBehaviour
{
    [SpineAnimation] public string idle;
    [SpineAnimation] public string attack_start;
    [SpineAnimation] public string attack_target;
    [SpineAnimation] public string attack_finish;
    private SkeletonAnimation skeletonAnimation;
    public Spine.AnimationState spineAnimationState;
    public Spine.Skeleton skeleton;

    private void Start()
    {
        skeletonAnimation = GetComponent<SkeletonAnimation>();
        spineAnimationState = skeletonAnimation.AnimationState;
        skeleton = skeletonAnimation.Skeleton;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            PlayStartAttackAnimation();
        }
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
