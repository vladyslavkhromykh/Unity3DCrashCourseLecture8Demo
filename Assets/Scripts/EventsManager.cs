using UnityEngine;
using System;

public class EventsManager : MonoBehaviour
{
    public static event Action NewGame;
    public static event Action<Mouse> MouseDead;
    public static event Action PlayerRanOutOfAmmo;
    public static event Action PlayerDead;

    public static void OnNewGame() => NewGame?.Invoke();
    public static void OnMouseDead(Mouse mouse) => MouseDead?.Invoke(mouse);
    public static void OnPlayerRanOutOfAmmo() => PlayerRanOutOfAmmo?.Invoke();
    public static void OnPlayerDead() => PlayerDead?.Invoke();
}
