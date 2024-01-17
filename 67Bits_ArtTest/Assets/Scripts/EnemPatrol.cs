using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemPatrol : MonoBehaviour
{
    public Transform[] patrolPoints;
    public float speed;
    public float rotationSpeed;
    public float pauseDuration = 2.0f; // Tempo de pausa em segundos

    private Animator animator;
    private int targetPoint;
    private bool isPaused;
    private float pauseTimer;

    private static readonly int IsPatrolling = Animator.StringToHash("IsPatrolling");

    void Start()
    {
        targetPoint = 0;
        animator = GetComponent<Animator>();
        isPaused = false;
        pauseTimer = 0f;
    }

    void Update()
    {
        if (!isPaused)
        {
            MoveToNextPatrolPoint();
        }
        else
        {
            // Aguarde o tempo de pausa
            pauseTimer += Time.deltaTime;
            if (pauseTimer >= pauseDuration)
            {
                isPaused = false;
                pauseTimer = 0f;
                increaseTargetInt();
            }
        }

        // Configura o par�metro "IsPatrolling" no Animator com base na l�gica de patrulha
        animator.SetBool(IsPatrolling, !isPaused);
    }

    void MoveToNextPatrolPoint()
    {
        Vector3 direction = (patrolPoints[targetPoint].position - transform.position).normalized;

        // Verifica se o personagem est� se movendo
        if (direction.magnitude > 0.1f)
        {
            // Rotaciona suavemente o personagem na dire��o do pr�ximo ponto de patrulha
            RotateCharacter(direction);

            // Move o personagem usando a velocidade
            transform.position = Vector3.MoveTowards(transform.position, patrolPoints[targetPoint].position, speed * Time.deltaTime);
        }

        // Verifica se o personagem chegou pr�ximo o suficiente ao ponto de patrulha
        if (Vector3.Distance(transform.position, patrolPoints[targetPoint].position) < 0.1f)
        {
            isPaused = true;
        }
    }

    void RotateCharacter(Vector3 direction)
    {
        // Calcula a rota��o desejada na dire��o do pr�ximo ponto de patrulha
        Quaternion targetRotation = Quaternion.LookRotation(direction, Vector3.up);

        // Interpola suavemente a rota��o atual para a rota��o desejada
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

    void increaseTargetInt()
    {
        targetPoint++;
        if (targetPoint >= patrolPoints.Length)
        {
            targetPoint = 0; // Volta para o primeiro ponto de patrulha
        }
    }
}
