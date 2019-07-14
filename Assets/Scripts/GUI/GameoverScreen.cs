using UnityEngine;
using UnityEngine.UI;

public class GameoverScreen : GUIScreen
{
    public Button replay;

    private void Awake()
    {
        replay.onClick.AddListener(new UnityEngine.Events.UnityAction(OnReplayClick));
    }

    private void OnReplayClick()
    {
        EventsManager.OnNewGame();
    }

    private void OnDestroy()
    {
        replay.onClick.RemoveAllListeners();
    }
}
