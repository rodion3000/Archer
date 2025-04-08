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
    
    public GameObject arrowPrefab; // Префаб стрелы
    public float arrowSpeed = 10f; // Скорость полета стрелы

    public float tiltSpeed = 5f; // Скорость наклона
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
        bulletBone = skeleton.FindBone("bullet"); // Получаем ссылку на кость "bullet"
        
        if (gunBone == null)
        {
            Debug.LogError("Кость 'gun' не найдена!");
        }
        
        if (bulletBone == null)
        {
            Debug.LogError("Кость 'bullet' не найдена!");
        }

        lastMousePosition = Input.mousePosition; // Инициализируем последнюю позицию мыши
    }

    private void Update()
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
            }
        }
        
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
            // Создаем экземпляр стрелы
            GameObject arrowInstance = Instantiate(arrowPrefab);
        
            // Получаем мировую позицию кости bullet
            Vector3 bulletPosition = bulletBone.GetWorldPosition(transform);
        
            // Устанавливаем позицию стрелы в полученную мировую позицию
            arrowInstance.transform.position = bulletPosition;

            // Получаем мировое вращение кости bullet
            Quaternion bulletRotation = bulletBone.GetQuaternion();
        
            // Устанавливаем вращение стрелы в соответствии с вращением bulletBone
            arrowInstance.transform.rotation = bulletRotation;

            // Получаем компонент Rigidbody2D для управления физикой стрелы
            Rigidbody2D rb = arrowInstance.GetComponent<Rigidbody2D>();
        
            if (rb != null)
            {
                // Используем направление из вращения для установки скорости
                Vector2 direction = bulletRotation * Vector2.right; // Используем правый вектор как направление
                rb.velocity = direction * arrowSpeed; // Устанавливаем скорость полета стрелы
            }
        
            Debug.Log("Стрела вылетела!");
        }
        else
        {
            Debug.LogError("Префаб стрелы или кость 'bullet' не установлены!");
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
