using UnityEngine;
using UnityEngine.UI;

public sealed class GameplayScreen : GUIScreen
{
    public Image HP;
    private Settings settings;

    private void Awake()
    {
        settings = Resources.Load<Settings>("Settings");
        EventsManager.PlayerHPChanged += OnPlayerHPChanged;
    }

    private void OnPlayerHPChanged(int hp)
    {
        this.HP.fillAmount = (float)hp / settings.PlayerMaximumHP;
    }

    private void OnDestroy()
    {

    }
}