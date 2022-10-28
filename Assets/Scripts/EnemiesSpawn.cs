using System.Collections;
using UnityEngine;

public class EnemiesSpawn : MonoBehaviour
{
    public enum SpawnState { SPAWNING,WAITING,COUNTING};

    [System.Serializable]
    public class Wave
    {
        public string name;
        public Transform enemy;
        public int count;
        public float rate;

    }

    public Wave[] waves;
    private int nextWave = 0;

    public Transform[] spawnPoints;

    public float timeBetweenWaves = 5f;
    private float waveCountdown;

    private float searchCountdown = 1f;
    
    private SpawnState state = SpawnState.COUNTING;

    [SerializeField] private GameManager gm;

    [SerializeField] public int currentEnemiesKilled;

    void Start()
    {
        if (spawnPoints.Length == 0)
        {
            Debug.LogError("No spawn points referenced");
        }

        waveCountdown = timeBetweenWaves;
    }

     void Update()
    {
        if (state == SpawnState.WAITING)
        {
            if (!EnemyIsAlive())
            {
                WaveCompleted();


                return;
            
            }
            else
            {
                return;
            }
        }


        if (waveCountdown <= 0)
        {
            if(state != SpawnState.SPAWNING)
            {
                StartCoroutine(SpawnWave(waves[nextWave] ) );
            }

        }
        else
        {
            waveCountdown -= Time.deltaTime;
        }
    }
    
    void WaveCompleted ()
    {
        Debug.Log("Wave Completed");

        state = SpawnState.COUNTING;
        waveCountdown = timeBetweenWaves;

        if (nextWave + 1 > waves.Length - 1)
        {
            nextWave = 0;
            Debug.Log("ALL WAVES COMPLETED! Looping...");
            //This is where you put Congratalations you have finished the game!
        }
        else
        {
            nextWave++;
        }

        currentEnemiesKilled = 0;
    }

    bool EnemyIsAlive()
    {
        /*searchCountdown -= Time.deltaTime;
        if (searchCountdown <= 0f)
        {
            searchCountdown = 1f;
            if (GameObject.FindGameObjectsWithTag("Enemy") == null)
            {
                print("asdasd");
                return false;
            }
        }
        return true;*/

        if(currentEnemiesKilled >= waves[nextWave].count)
        {
            return false;
        }
        return true;
    }
    IEnumerator SpawnWave(Wave _wave)
    {
        Debug.Log("Spawning Wave: " + _wave.name);
        state = SpawnState.SPAWNING;

        for (int i = 0; i < _wave.count; i++)
        {
            SpawnEnemy(_wave.enemy);
            yield return new WaitForSeconds( 1f/_wave.rate);
        }

        state = SpawnState.WAITING;
        
        yield break;
    }

    void SpawnEnemy(Transform _enemy)
    {
        Debug.Log("Spawning Enemy: " + _enemy.name);
        
        Transform _sp = spawnPoints[Random.Range(0,spawnPoints.Length) ];
        GameObject newEnemy = Instantiate(_enemy,new Vector3(_sp.position.x, 0, _sp.position.z) * Random.insideUnitCircle * 2, _sp.rotation).gameObject;

        newEnemy.GetComponent<EnemyController>().target = gm.player.transform;
    }

}
