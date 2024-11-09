using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;     // Prefab del enemigo
    public int enemiesPerWave = 5;     // Número de enemigos por oleada
    public float timeBetweenWaves = 5f; // Tiempo entre oleadas
    public Transform spawnPoint;       // Punto de aparición de los enemigos

    private List<GameObject> activeEnemies = new List<GameObject>(); // Lista para enemigos activos

    private void Start()
    {
        StartCoroutine(SpawnWave());
    }

    private IEnumerator SpawnWave()
    {
        while (true)
        {
            for (int i = 0; i < enemiesPerWave; i++)
            {
                GameObject newEnemy = Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
                activeEnemies.Add(newEnemy);
                yield return new WaitForSeconds(0.5f); 
            }

            yield return new WaitUntil(() => AreAllEnemiesDead());

            yield return new WaitForSeconds(timeBetweenWaves);
        }
    }

    private bool AreAllEnemiesDead()
    {
        activeEnemies.RemoveAll(enemy => enemy == null);
        return activeEnemies.Count == 0;
    }
}
