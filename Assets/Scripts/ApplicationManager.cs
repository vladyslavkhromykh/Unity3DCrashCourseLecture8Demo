using UnityEngine;

public class ApplicationManager : MonoBehaviour
{
    private void Start()
    {
        EventsManager.OnNewGame();
    }
}
