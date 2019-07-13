using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public Player playerPrefab;
    private Settings settings;

    private void Awake()
    {
        settings = Resources.Load<Settings>("Settings");
        EventsManager.NewGame += OnNewGame;
    }

    
    private void OnNewGame()
    {
        Instantiate<Player>(playerPrefab);
    }

    private void OnDestroy()
    {
        EventsManager.NewGame -= OnNewGame;
    }
}
