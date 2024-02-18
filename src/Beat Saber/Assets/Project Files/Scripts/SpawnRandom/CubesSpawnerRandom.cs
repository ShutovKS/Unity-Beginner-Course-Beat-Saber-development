using UnityEngine;
using Random = UnityEngine.Random;

public class CubesSpawnerRandom : MonoBehaviour
{
    [SerializeField] private GameObject[] cubesPrefabs;

    [Space, SerializeField] private Transform[] spawnPoints;
    
    private bool _isHandler = true;
    private float _beat;
    private float _timer;

    private void Start()
    {
        GameManager.Instance.OnGameOver += () => _isHandler = false;
        
        _beat = GameManager.Instance.GameData.CubSpawnerTime;
        
        if (cubesPrefabs.Length == 0)
        {
            Debug.LogError("Cubes prefabs are not assigned!");
        }

        if (spawnPoints.Length == 0)
        {
            Debug.LogError("Spawn points are not assigned!");
        }
    }

    private void Update()
    {
        if (_isHandler && _timer > _beat)
        {
            var rotation = 90 * Random.Range(0, 4);
            var cubePrefab = cubesPrefabs[Random.Range(0, cubesPrefabs.Length)];
            var spawnPointPosition = spawnPoints[Random.Range(0, spawnPoints.Length)].position;
            var instantiate = Instantiate(cubePrefab, spawnPointPosition, Quaternion.identity);
            instantiate.transform.Rotate(0, 0, rotation);
            
            _timer -= _beat;
        }

        _timer += Time.deltaTime;
    }
}