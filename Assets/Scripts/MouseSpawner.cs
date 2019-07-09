using UnityEngine;

public class MouseSpawner : MonoBehaviour
{
    public int MaximumMouseCount = 10;
    public GameObject MousePrefab;

    private void Awake() {
        for (int i = 0; i < MaximumMouseCount; i++)
        {
            SpawnMouse();
        }
    }

    public void MouseDie()
    {
        SpawnMouse();
    }

    private void SpawnMouse()
    {
        Vector3 randomPosition = new Vector3(Random.Range(-100.0f, 100.0f), 0.0f, Random.Range(-100.0f, 100.0f));
        Instantiate<GameObject>(MousePrefab, randomPosition, Quaternion.identity);
    }
}
