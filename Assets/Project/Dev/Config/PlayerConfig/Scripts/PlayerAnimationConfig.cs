using Spine;
using Spine.Unity;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerAnimationConfig", menuName = "Configs/PlayerConfig/Player Animation Config")]
public class PlayerAnimationConfig : ScriptableObject
{
    [field: SerializeField] [SpineAnimation] public string idle;
    [field: SerializeField][field: SpineAnimation] public string attack_start {get; private set;}
    [field: SerializeField][field: SpineAnimation] public string attack_target {get; private set;}
    [field: SerializeField][field: SpineAnimation] public string attack_finish {get; private set;}
    [field: SerializeField] public SkeletonAnimation skeletonAnimation {get; private set;}
}
