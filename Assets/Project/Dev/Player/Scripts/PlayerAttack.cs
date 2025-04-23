using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine;
using Spine.Unity;
using Zenject;

public class PlayerAttack : MonoBehaviour
{
    public GameObject arrowPrefab; // Префаб стрелы
    public float arrowSpeed = 10f; // Скорость полета стрелы
    public float tiltSpeed = 5f; // Скорость наклона
    public Transform stringObject;
    public float angleAttackSpeed = 5;
    public float maxTiltAngle = 30f; // Максимальный угол наклона
    private float scaleFactor = 1f;
    private Bone gunBone; // Ссылка на кость "gun"
    private Bone bulletBone; // Ссылка на кость "bullet"
    private Bone string_c;
    public Skeleton skeleton;
    private SkeletonAnimation skeletonAnimation;
    private Vector3 lastMousePosition; // Последняя позиция мыши
    private PlayerAnimationController _playerAnimationController;

    [Inject]
    private void Construct(PlayerAnimationController playerAnimationController)
    {
        _playerAnimationController = playerAnimationController;
    }
    private void Start()
    {
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
    }
    
    private void Attack()
    {
        if (_playerAnimationController.isAttacking)
        {
            Vector3 mouseDelta = Input.mousePosition - lastMousePosition;

            // Изменяем угол наклона в зависимости от перемещения мыши
            if (gunBone != null)
            {
                float newAngle = gunBone.Rotation + (-mouseDelta.y * tiltSpeed * Time.deltaTime);
                newAngle = Mathf.Clamp(newAngle, -maxTiltAngle, maxTiltAngle); // Ограничиваем угол наклона
                gunBone.Rotation = newAngle;

                AdjustStringLength();
                stringPositionAndIncrease();
            }
        }
    }
    
    private void AdjustStringLength()
    {
        // Получаем текущую позицию мыши в мировых координатах
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane));

        // Вычисляем расстояние по оси X между позицией объекта и позицией мыши
        float distanceX = transform.position.x - mouseWorldPosition.x;

        // Проверяем, находится ли мышь слева от объекта
        if (distanceX > 0)
        {
            // Устанавливаем масштаб линии натяжения в зависимости от расстояния
            scaleFactor = Mathf.Clamp(distanceX / 2f, 1f, 3f); // Измените делитель и пределы по необходимости

            // Увеличиваем линию натяжения по оси X (или Y в зависимости от вашей логики)
            stringObject.transform.localScale = new Vector3(1, scaleFactor, 1f); 
        }
        else
        {
            // Если мышь справа от объекта, устанавливаем масштаб на минимальное значение
            stringObject.transform.localScale = new Vector3(1f, 1f, 1f);
            scaleFactor = 1f; // Сбрасываем scaleFactor
        }
    }
    
    private void stringPositionAndIncrease()
    {
        Vector3 stringPos = string_c.GetWorldPosition(transform);
        stringObject.transform.position = stringPos + new Vector3(1.5f, -0.6f, 0);
        
        var stringRot = string_c.WorldRotationY;
        stringObject.transform.rotation = Quaternion.Euler(0, 0, stringRot);
    }
    public void ShootArrow()
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
                rb.velocity = direction * arrowSpeed * scaleFactor; 
            }
            
        }
    }
}
