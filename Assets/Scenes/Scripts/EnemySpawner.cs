using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnInterval = 2f;
    public float spawnXOffset = 10f;

    public float minY = -2f;
    public float maxY = 2f;

    public float minSpeed = 2f;
    public float maxSpeed = 5f;

    public float minScale = 0.8f;
    public float maxScale = 1.5f;

    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            SpawnEnemy();
            timer = 0f;
        }
    }

    void SpawnEnemy()
    {
        bool fromRight = Random.value > 0.5f;

        // Posição X (fora da tela)
        float cameraX = Camera.main.transform.position.x;
        float spawnX = fromRight ? cameraX + spawnXOffset : cameraX - spawnXOffset;

        // Posição Y (definida manualmente)
        float spawnY = Random.Range(minY, maxY);
        Vector3 spawnPosition = new Vector3(spawnX, spawnY, 0f);

        GameObject enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);

        // Escala aleatória
        float randomScale = Random.Range(minScale, maxScale);
        enemy.transform.localScale = new Vector3(randomScale, randomScale, 1f);

        // Movimento aleatório
        EnemyMovement movement = enemy.GetComponent<EnemyMovement>();
        if (movement != null)
        {
            movement.moveDirection = fromRight ? Vector3.left : Vector3.right;
            movement.speed = Random.Range(minSpeed, maxSpeed);
        }

        // Rotação 180° para virar o inimigo se vier da direita
        enemy.transform.rotation = Quaternion.Euler(0f, fromRight ? 180f : 0f, 0f);
    }
}
