using UnityEngine;

public class MouseSpawner : MonoBehaviour
{
    public Mouse MousePrefab;
    private Settings settings;

    private void Awake() {
        settings = Resources.Load<Settings>("Settings");

        EventsManager.MouseDead += OnMouseDead;
        EventsManager.NewGame += OnNewGame;
    }

    private void OnNewGame()
    {
        for (int i = 0; i < settings.MouseMaximumCount; i++)
        {
            SpawnMouse();
        }
    }

    public void OnMouseDead(Mouse mouse)
    {
        SpawnMouse();
    }

    private void SpawnMouse()
    {
        Vector3 randomPosition = new Vector3(
            Random.Range(-settings.SpawnRadius, settings.SpawnRadius), 0.0f, Random.Range(-settings.SpawnRadius, settings.SpawnRadius));
        Instantiate<Mouse>(MousePrefab, randomPosition, Quaternion.identity);
    }

    private void OnDestroy()
    {
        EventsManager.MouseDead -= OnMouseDead;
        EventsManager.NewGame -= OnNewGame;
    }
}
