using UnityEngine;

public class Player : MonoBehaviour
{
    [Range(0.5f, 3.0f)]
    public float Speed;

    public int MaximumHP;
    private int currentHP;

    private void Awake()
    {
        currentHP = MaximumHP;
    }


    private void Update()
    {
        transform.Rotate(0.0f, Input.GetAxis("Horizontal"), 0.0f, Space.Self);
        transform.Translate(0.0f, 0.0f, Input.GetAxis("Vertical") * Speed * Time.deltaTime, Space.Self);

        if (Input.GetKeyDown(KeyCode.Space) && transform.position.y < 0.1f)
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * 5.0f, ForceMode.Impulse);
        }
    }

    public void GetHit()
    {
        currentHP--;
    }
}
