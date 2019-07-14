using UnityEngine;

public class Player : MonoBehaviour
{
    public SimpleShoot gun;
    public bool isDead { get; private set; }
    private Settings settings;
    private int hp;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        settings = Resources.Load<Settings>("Settings");
        hp = settings.PlayerMaximumHP;
    }

    private void Update()
    {
        if (isDead)
        {
            return;
        }

        transform.Rotate(0.0f, Input.GetAxis("Mouse X"), 0.0f, Space.Self);
        transform.Translate(Input.GetAxis("Horizontal") * settings.PlayerMovementSpeed * Time.deltaTime, 0.0f, 0.0f, Space.Self);
        if (Input.GetKey(KeyCode.LeftShift)) {
            transform.Translate(0.0f, 0.0f, Input.GetAxis("Vertical") * settings.PlayerMovementSpeed * 2.0f * Time.deltaTime, Space.Self);
        } else
        {
            transform.Translate(0.0f, 0.0f, Input.GetAxis("Vertical") * settings.PlayerMovementSpeed * Time.deltaTime, Space.Self);
        }

        GetComponentInChildren<Camera>().transform.Rotate(-Input.GetAxis("Mouse Y"), 0.0f, 0.0f, Space.Self);
    }

    public void OnShot()
    {
        Ray ray = GetComponentInChildren<Camera>().ViewportPointToRay(new Vector3(0.5f, 0.5f, 0.0f));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Mouse"))
            {
                hit.collider.GetComponentInParent<Mouse>().Die();
            }
        }
    }

    public void GetHit()
    {
        if (isDead)
        {
            return;
        }

        hp--;
        EventsManager.OnPlayerHPChanged(hp);
        if (hp == 0)
        {
            isDead = true;
            Destroy(GetComponentInChildren<SimpleShoot>());
            EventsManager.OnPlayerDead();
        }
    }
}
