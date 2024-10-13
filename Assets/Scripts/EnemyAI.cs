using UnityEngine;
using UnityEngine.AI;

// Класс поведение ботов
public class EnemyAI : Creature
{
    // NavMeshAgent
    public NavMeshAgent agent;
    // Трансформ игрока
    public Transform player;
    // Слой орудия бота
    public GameObject weaponObject;

    // Частицы смерти ботов
    public GameObject deathParticles;

    // Слой поверхностей по которым ходят боты
    public LayerMask whatIsGround;
    // Слой с игроком
    public LayerMask whatIsPlayer;

    [Space]
    [Header("Patroling")]
    // Точка интереса до которой идет бот
    public Vector3 walkPoint;
    // Установлена точка интереса или нет
    public bool walkPointSet;
    // Дистанция на которую может отойти бот при выборе точки
    public float walkPointRange;

    [Space]
    [Header("Attacking")]
    // Радиус видения бота
    public float sightRange;
    // Радиус атаки бота
    public float attackRange;
    // Кулдаун между атаками
    public float timeBetweenAttacks;

    bool alredyAttacked;
    private Weapon weapon;
    private bool playerInSightRange;
    private bool playerInAttackRange;

    private void Start()
    {
        creatureName = "Bot";
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        weapon = weaponObject.GetComponent<Weapon>();
    }

    private void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerInSightRange && !playerInAttackRange) Patroling();
        if (playerInSightRange && !playerInAttackRange) ChasePlayer();
        if (playerInSightRange && playerInAttackRange) AttackPlayer();
    }

    private void Patroling()
    {
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
            agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;
    }

    private void SearchWalkPoint()
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;
    }

    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
    }

    private void AttackPlayer()
    {
        agent.SetDestination(transform.position);

        transform.LookAt(player);
        weaponObject.transform.LookAt(player);

        if (!alredyAttacked)
        {
            weapon.Use(creatureName);

            alredyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    private void ResetAttack()
    {
        alredyAttacked = false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }

    public void Death()
    {
        var score = player.GetComponent<Score>();
        score.ModifyScore(1);
        var particles = Instantiate(deathParticles, transform.position, Quaternion.identity);
        Destroy(particles, 5.0f);
    }
}
