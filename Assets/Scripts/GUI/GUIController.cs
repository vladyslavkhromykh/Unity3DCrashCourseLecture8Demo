using UnityEngine;

public class GUIController : MonoBehaviour
{
    public Transform parent;
    private GUIScreen current;

    private void Awake()
    {
        EventsManager.NewGame += OnNewGame;
        EventsManager.PlayerDead += OnPlayerDead;
    }

    private void OnPlayerDead()
    {
        CreateScreen<GameoverScreen>();
    }

    private void OnNewGame()
    {
        CreateScreen<GameplayScreen>();
    }

    private void OnDestroy()
    {
        EventsManager.NewGame -= OnNewGame;
        EventsManager.PlayerDead -= OnPlayerDead;

        Clear();
    }

    private void Clear()
    {
        if (current != null)
        {
            GameObject.Destroy(current.gameObject);
        }
        current = null;
    }

    private T CreateScreen<T>() where T : GUIScreen
    {
        Clear();
        T screen = GameObject.Instantiate(Resources.Load<T>("GUI/Screens/" + typeof(T).Name));
        screen.transform.SetParent(this.parent);
        current = screen;
        return screen;
    }
}