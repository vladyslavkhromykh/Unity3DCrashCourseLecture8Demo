using UnityEngine;
using System.Linq;

public class EnvironmentBuilder : MonoBehaviour
{
    private Settings settings;
    public Transform[] enviromentPrefabs;

    private void Awake()
    {
        settings = Resources.Load<Settings>("Settings");
    }

    private void Start()
    {
        SpawnEnvironment();
    }

    private void SpawnEnvironment()
    {
        for (int i = 0; i < settings.EnviromentCount; i++)
        {
            Vector3 randomPosition = new Vector3(
                Random.Range(-settings.SpawnRadius, settings.SpawnRadius), 0.0f, Random.Range(-settings.SpawnRadius, settings.SpawnRadius));
            Instantiate<Transform>(enviromentPrefabs[Random.Range(0, enviromentPrefabs.Length)], randomPosition, Quaternion.identity);
        }
    }
}
