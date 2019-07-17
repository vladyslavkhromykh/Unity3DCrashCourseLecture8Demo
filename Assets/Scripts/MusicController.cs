using UnityEngine;

public class MusicController : MonoBehaviour
{
    public float gameVolume;
    public float gameOverVolume;
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        EventsManager.PlayerDead += OnPlayerDead;
        EventsManager.NewGame += OnNewGame;
    }

    private void OnNewGame()
    {
        audioSource.volume = gameVolume;
    }

    private void OnPlayerDead()
    {
        audioSource.volume = gameOverVolume;
    }

    private void OnDestroy()
    {
        EventsManager.PlayerDead -= OnPlayerDead;
        EventsManager.NewGame -= OnNewGame;
    }
}
