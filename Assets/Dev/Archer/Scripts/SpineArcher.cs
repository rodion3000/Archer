using System;
using System.Collections;
using System.Collections.Generic;
using Spine;
using Spine.Unity;
using Unity.Mathematics;
using UnityEngine;

public class SpineArcher : MonoBehaviour
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
    
    public GameObject arrowPrefab; // Префаб стрелы
    public float arrowSpeed = 10f; // Скорость полета стрелы
    public Transform stringObject;

    public float tiltSpeed = 5f; // Скорость наклона
    public float angleAttackSpeed = 5;
    public float maxTiltAngle = 30f; // Максимальный угол наклона
    private Vector3 lastMousePosition; // Последняя позиция мыши
    private bool isAttacking = false; // Флаг для отслеживания атаки
    private bool isFinishingAttack = false; // Флаг для отслеживания завершения атаки

    private void Start()
    {
        skeletonAnimation = GetComponent<SkeletonAnimation>();
        spineAnimationState = skeletonAnimation.AnimationState;
        skeleton = skeletonAnimation.Skeleton;

        gunBone = skeleton.FindBone("gun");
        bulletBone = skeleton.FindBone("bullet");
        string_c = skeleton.FindBone("string_c");
        
        lastMousePosition = Input.mousePosition; // Инициализируем последнюю позицию мыши
    }

    private void Update()
    {
       Attack();
        
        lastMousePosition = Input.mousePosition; 

        if (!isAttacking && !IsPlayingIdle() && !isFinishingAttack) 
        {
            PlayerIdleAnimation(); 
        }

        if (isFinishingAttack && IsPlayingIdle()) 
        {
            isFinishingAttack = false; 
        }
    }

    private void PlayStartAttackAnimation()
    {
        var currentAnimation = spineAnimationState.GetCurrent(0);
        
        if (currentAnimation == null || currentAnimation.Animation.Name != attack_start)
        {
            spineAnimationState.SetAnimation(0, attack_start, false); 
            isAttacking = true; 
        }
    }

    private void Attack()
    {
        if (isAttacking) 
        {
            Vector3 mouseDelta = Input.mousePosition - lastMousePosition; 

            // Изменяем угол наклона в зависимости от перемещения мыши
            if (gunBone != null)
            {
                float newAngle = gunBone.Rotation + (-mouseDelta.y * tiltSpeed * Time.deltaTime);
                newAngle = Mathf.Clamp(newAngle, -maxTiltAngle, maxTiltAngle); // Ограничиваем угол наклона
                gunBone.Rotation = newAngle;
                stringPositionAndIncrease();
            }
        }
    }

    private void stringPositionAndIncrease()
    {
        Vector3 stringPos = string_c.GetWorldPosition(transform);
        stringObject.transform.position = stringPos;
        var stringRot = string_c.WorldRotationY;
        stringObject.transform.rotation = Quaternion.Euler(0, 0, stringRot);
    }
    private void PlayFinishAttack()
    {
        var currentAnimation = spineAnimationState.GetCurrent(0);
        
        if (currentAnimation == null || currentAnimation.Animation.Name != attack_finish)
        {
            spineAnimationState.SetAnimation(0, attack_finish, false);
            isFinishingAttack = true; 
            Debug.Log("Запуск анимации завершения атаки");

            ShootArrow(); // Запускаем стрелу при завершении атаки
        }
    }

    private void ShootArrow()
    {
        if (arrowPrefab != null && bulletBone != null)
        {
            GameObject arrowInstance = Instantiate(arrowPrefab);
            Vector3 bulletPosition = bulletBone.GetWorldPosition(transform);
            arrowInstance.transform.position = bulletPosition;
            float bulletRotation = bulletBone.WorldRotationY;
            arrowInstance.transform.rotation = Quaternion.Euler(0, 0, bulletRotation - 180f);
            Rigidbody2D rb = arrowInstance.GetComponent<Rigidbody2D>();
        
            if (rb != null)
            {
                Vector2 direction = Quaternion.Euler(0, 0, bulletRotation - 90f) * Vector2.right; 
                rb.velocity = direction * arrowSpeed; 
            }
            
        }
    }

    private void PlayerIdleAnimation()
    {
        var currentAnimation = spineAnimationState.GetCurrent(0);
        
        if (currentAnimation == null || currentAnimation.Animation.Name != idle)
        {
            spineAnimationState.SetAnimation(0, idle, true); 
            isAttacking = false; 
        }
    }

    private bool IsPlayingIdle()
    {
        var currentAnimation = spineAnimationState.GetCurrent(0);
        return currentAnimation != null && currentAnimation.Animation.Name == idle;
    }

    private void OnMouseDown() 
    {
        PlayStartAttackAnimation();
    }

    private void OnMouseUp() 
    {
        isAttacking = false; 
        PlayFinishAttack(); 
    }
}
