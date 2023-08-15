using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _enemyPrefab;

    [SerializeField]
    private float _minimumSpawnTime;

    [SerializeField]
    private float _maximumSpawnTime;

    private float _timeUntilSpawn;
    private int spawnplaceschoice;
    private Vector3 spawnplace;
    private int enemychoice;
    private gamemanager manager;

    void Awake()
    {
        SetTimeUntilSpawn();
        manager = GameObject.Find("gamemanager").GetComponent<gamemanager>();
    }

    void Update()
    {
        _timeUntilSpawn -= Time.deltaTime;
        
        spawnplaceschoice = Random.Range(1, 5);
        if (spawnplaceschoice == 1)
        {
            spawnplace = new Vector3(79, 1.46f, 73);
        }
        if (spawnplaceschoice == 2)
        {
            spawnplace = new Vector3(79, 1.46f, -73);
        }
        if (spawnplaceschoice == 3)
        {
            spawnplace = new Vector3(-79, 1.46f, 73);
        }
        if (spawnplaceschoice == 4)
        {
            spawnplace = new Vector3(-79, 1.46f, -73);
        }

        enemychoice = Random.Range(0, _enemyPrefab.Length);

        if (_timeUntilSpawn <= 0 && manager.active)
        {
            Instantiate(_enemyPrefab[enemychoice], spawnplace, Quaternion.identity);
            SetTimeUntilSpawn();
        }
    }

    private void SetTimeUntilSpawn()
    {
        _timeUntilSpawn = Random.Range(_minimumSpawnTime, _maximumSpawnTime);
    }
}
