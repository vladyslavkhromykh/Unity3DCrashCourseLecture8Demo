using UnityEngine;

public class Ammo : MonoBehaviour
{
    private void OnTriggerEnter(Collider collider)
    {
        
        if (collider.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            collider.attachedRigidbody.gameObject.GetComponent<Player>().gun.LoadAmmo();
            Destroy(gameObject);
        }
    }
}
