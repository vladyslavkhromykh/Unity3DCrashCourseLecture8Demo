using UnityEngine;

[CreateAssetMenu(fileName = "Settings", menuName = "Settings", order = 0)]
public class Settings : ScriptableObject
{
    public int SpawnRadius;

    [Range(3, 10)]
    public int PlayerMaximumAmmo;
    public float PlayerMovementSpeed;
    [Range(1, 10)]
    public int PlayerMaximumHP;

    public float MouseMovementSpeed;
    [Range(1, 10)]
    public int MouseMaximumCount;

    [Range(10, 200)]
    public int EnviromentCount;
}
