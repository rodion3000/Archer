using System;
using System.Collections;
using System.Collections.Generic;
using Spine;
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
    public Skeleton skeleton;

    private Bone gunBone; // Ссылка на кость "gun"
    public float tiltSpeed = 5f; // Скорость наклона
    public float maxTiltAngle = 30f; // Максимальный угол наклона
    private Vector3 lastMousePosition; // Последняя позиция мыши
    private bool isAttacking = false; // Флаг для отслеживания атаки

    private void Start()
    {
        skeletonAnimation = GetComponent<SkeletonAnimation>();
        spineAnimationState = skeletonAnimation.AnimationState;
        skeleton = skeletonAnimation.Skeleton;

        // Получаем ссылку на кость "gun"
        gunBone = skeleton.FindBone("gun");
        if (gunBone == null)
        {
            Debug.LogError("Кость 'gun' не найдена!");
        }
        lastMousePosition = Input.mousePosition; // Инициализируем последнюю позицию мыши
    }

    private void Update()
    {
        if (isAttacking) // Проверяем, идет ли атака
        {
            Vector3 mouseDelta = Input.mousePosition - lastMousePosition; // Вычисляем изменение позиции мыши

            // Изменяем угол наклона в зависимости от перемещения мыши
            if (gunBone != null)
            {
                float newAngle = gunBone.Rotation + (-mouseDelta.y * tiltSpeed * Time.deltaTime);
                newAngle = Mathf.Clamp(newAngle, -maxTiltAngle, maxTiltAngle); // Ограничиваем угол наклона
                gunBone.Rotation = newAngle;
            }
        }
        
        lastMousePosition = Input.mousePosition; // Обновляем последнюю позицию мыши

        if (!isAttacking && !IsPlayingIdle()) // Если не атакуем и не в состоянии idle
        {
            PlayerIdleAnimation(); // Переходим в состояние idle
        }
    }

    private void PlayStartAttackAnimation()
    {
        var currentAnimation = spineAnimationState.GetCurrent(0);
        
        if (currentAnimation == null || currentAnimation.Animation.Name != attack_start)
        {
            spineAnimationState.SetAnimation(0, attack_start, false); 
            isAttacking = true; // Устанавливаем флаг атаки в true
        }
    }

    private void PlayerIdleAnimation()
    {
        var currentAnimation = spineAnimationState.GetCurrent(0);
        
        if (currentAnimation == null || currentAnimation.Animation.Name != idle)
        {
            spineAnimationState.SetAnimation(0, idle, true); 
            isAttacking = false; // Сбрасываем флаг атаки при переходе в состояние idle
        }
    }

    private bool IsPlayingIdle()
    {
        var currentAnimation = spineAnimationState.GetCurrent(0);
        return currentAnimation != null && currentAnimation.Animation.Name == idle;
    }

    private void OnMouseDown() // Этот метод вызывается при нажатии на объект с коллайдером
    {
        PlayStartAttackAnimation();
    }

    private void OnMouseUp() // Этот метод вызывается при отпускании кнопки мыши
    {
        isAttacking = false; // Сбрасываем флаг атаки при отпускании кнопки мыши
    }
}
