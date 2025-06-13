using UnityEngine;
using System.Collections;

public class BatAI : MonoBehaviour
{
    public float speed = 3f;               // Velocidade do morcego
    public float attackCooldown = 2f;      // Tempo entre ataques
    public int damage = 10;                // Dano do ataque
    public float attackRange = 5f;         // Distância para disparar o ataque

    private Vector3 initialPosition;
    private bool isActive = false;
    private bool isAttacking = false;
    private float cooldownTimer;
    private Animator animator;
    private Transform player;

    void Start()
    {
        initialPosition = transform.position;
        animator = GetComponent<Animator>();
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
        {
            player = playerObj.transform;
        }
    }

    void Update()
    {
        if (isActive && !isAttacking && player != null)
        {
            float distance = Vector3.Distance(transform.position, player.position);
            if (distance <= attackRange)
            {
                AttackPlayer();
            }
        }

        // Atualiza o cooldown mesmo fora do ataque
        if (!isAttacking && cooldownTimer > 0)
        {
            cooldownTimer -= Time.deltaTime;
        }
    }

    // Ativa o morcego: sai do idle e entra no estado Fly
    public void ActivateBat()
    {
        isActive = true;
        animator.SetBool("Fly", true);  // Mantém o estado de voo
    }

    // Inicia o ataque se o cooldown permitir
    void AttackPlayer()
    {
        if (cooldownTimer <= 0)
        {
            StartCoroutine(AttackRoutine());
        }
    }

    IEnumerator AttackRoutine()
    {
        isAttacking = true;
        // Captura a posição do jogador no início do ataque
        Vector3 attackTarget = player.position;  

        // Fase de ataque: o morcego se move em direção à posição capturada
        while (Vector3.Distance(transform.position, attackTarget) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, attackTarget, speed * Time.deltaTime);
            yield return null;
        }

        // Se o morcego estiver suficientemente perto do jogador, aplica dano
        if (Vector3.Distance(transform.position, player.position) < 0.5f)
        {
            player.GetComponent<PlayerHealth>()?.TakeDamage(damage);
        }

        // Fase de recuo: o morcego retorna para uma posição relativa à sua posição inicial
        Vector3 retreatDirection = (initialPosition - attackTarget).normalized;
        Vector3 retreatPosition = initialPosition + retreatDirection * 3f;
        while (Vector3.Distance(transform.position, retreatPosition) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, retreatPosition, speed * Time.deltaTime);
            yield return null;
        }

        cooldownTimer = attackCooldown;
        isAttacking = false;
    }
}
