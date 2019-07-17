using UnityEngine;

public class SoundController : MonoBehaviour
{
    public AudioClip GunShot;
    public AudioClip MouseHit;
    public AudioClip AmmoLoad;
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        EventsManager.MouseHit += OnMouseHit;
        EventsManager.PlayerShot += OnPlayerShot;
        EventsManager.PlayerAmmoLoad += OnPlayerAmmoLoad;
    }

    private void OnPlayerAmmoLoad(int ammo)
    {
        audioSource.PlayOneShot(AmmoLoad);
    }

    private void OnPlayerShot(int ammo)
    {
        audioSource.PlayOneShot(GunShot);
    }

    private void OnMouseHit()
    {
        audioSource.PlayOneShot(MouseHit);
    }

    private void OnDestroy()
    {
        EventsManager.MouseHit -= OnMouseHit;
        EventsManager.PlayerShot -= OnPlayerShot;
        EventsManager.PlayerAmmoLoad -= OnPlayerAmmoLoad;
    }
}
