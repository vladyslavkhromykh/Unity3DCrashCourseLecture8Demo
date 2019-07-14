using UnityEngine;

public class AmmoSpawner : MonoBehaviour
{
    public GameObject AmmoPrefab;
    private Settings settings;

    private void Awake()
    {
        settings = Resources.Load<Settings>("Settings");

        EventsManager.PlayerRanOutOfAmmo += OnPlayerRanOutOfAmmo;
    }


    public void OnPlayerRanOutOfAmmo()
    {
        SpawnAmmo();
    }

    private void SpawnAmmo()
    {
        Vector3 randomPosition = new Vector3(
            Random.Range(-settings.SpawnRadius, settings.SpawnRadius), 0.0f, Random.Range(-settings.SpawnRadius, settings.SpawnRadius));
        Instantiate<GameObject>(AmmoPrefab, randomPosition, Quaternion.identity);
    }

    private void OnDestroy()
    {
        EventsManager.PlayerRanOutOfAmmo -= OnPlayerRanOutOfAmmo;
    }
}
