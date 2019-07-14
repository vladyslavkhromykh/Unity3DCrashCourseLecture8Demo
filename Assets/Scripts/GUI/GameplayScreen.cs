using UnityEngine;
using UnityEngine.UI;

public sealed class GameplayScreen : GUIScreen
{
    public Image HP;
    public Text Ammo;
    private Settings settings;

    private void Awake()
    {
        settings = Resources.Load<Settings>("Settings");
        EventsManager.PlayerHPChanged += OnPlayerHPChanged;
        EventsManager.PlayerShot += OnPlayerShot;
    }

    private void Start()
    {
        this.HP.fillAmount = 1.0f;
        this.Ammo.text = settings.PlayerMaximumAmmo.ToString();
    }

    private void OnPlayerHPChanged(int hp)
    {
        this.HP.fillAmount = (float)hp / settings.PlayerMaximumHP;
    }

    private void OnPlayerShot(int ammo)
    {
        this.Ammo.text = ammo.ToString();
    }

    private void OnDestroy()
    {
        EventsManager.PlayerHPChanged -= OnPlayerHPChanged;
        EventsManager.PlayerShot -= OnPlayerShot;
    }
}