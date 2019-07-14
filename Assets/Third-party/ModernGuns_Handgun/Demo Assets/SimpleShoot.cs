using UnityEngine;

public class SimpleShoot : MonoBehaviour
{
    public GameObject casingPrefab;
    public GameObject muzzleFlashPrefab;
    public Transform barrelLocation;
    public Transform casingExitLocation;
    public float shotPower = 100f;

    private Settings settings;
    private int ammo;

    private void Awake()
    {
        settings = Resources.Load<Settings>("Settings");
        ammo = settings.PlayerMaximumAmmo;
    }

    void Start()
    {
        if (barrelLocation == null)
            barrelLocation = transform;
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (ammo == 0)
            {
                EventsManager.OnPlayerRanOutOfAmmo();
            } else
            {
                GetComponent<Animator>().SetTrigger("Fire");
                ammo--;
                EventsManager.OnPlayerShot(ammo);
            }
        }
    }

    void Shoot()
    {
       GameObject tempFlash = Instantiate(muzzleFlashPrefab, barrelLocation.position, barrelLocation.rotation);
       Destroy(tempFlash, 0.5f);
        GetComponentInParent<Player>().OnShot();
    }

    void CasingRelease()
    {
         GameObject casing;
        casing = Instantiate(casingPrefab, casingExitLocation.position, casingExitLocation.rotation) as GameObject;
        casing.GetComponent<Rigidbody>().AddExplosionForce(550f, (casingExitLocation.position - casingExitLocation.right * 0.3f - casingExitLocation.up * 0.6f), 1f);
        casing.GetComponent<Rigidbody>().AddTorque(new Vector3(0, Random.Range(100f, 500f), Random.Range(10f, 1000f)), ForceMode.Impulse);
    }


}
