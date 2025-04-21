using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject arrowPrefab; // Префаб стрелы
    public float arrowSpeed = 10f; // Скорость полета стрелы
    public Transform stringObject;
    public float angleAttackSpeed = 5;
    private bool isAttacking = false; // Флаг для отслеживания атаки
    private bool isFinishingAttack = false; // Флаг для отслеживания завершения атаки
    private float scaleFactor = 1f;

    
    

}
