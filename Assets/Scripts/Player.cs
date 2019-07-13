using UnityEngine;

public class Player : MonoBehaviour
{
    public bool isDead { get; private set; }
    private Settings settings;
    private int hp;

    private void Awake()
    {
        settings = Resources.Load<Settings>("Settings");
        hp = settings.PlayerMaximumHP;
    }

    private void Update()
    {
        transform.Rotate(0.0f, Input.GetAxis("Horizontal"), 0.0f, Space.Self);
        transform.Translate(0.0f, 0.0f, Input.GetAxis("Vertical") * settings.PlayerMovementSpeed * Time.deltaTime, Space.Self);

        if (Input.GetKeyDown(KeyCode.Space) && transform.position.y < 0.1f)
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * 5.0f, ForceMode.Impulse);
        }
    }

    public void GetHit()
    {
        if (isDead)
        {
            return;
        }

        hp--;
        if (hp == 0)
        {
            isDead = true;
            EventsManager.OnPlayerDead();
        }
    }
}
