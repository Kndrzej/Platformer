using UnityEngine;

public class Key : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        DoorManager.Instance.door.SetActive(true);
        gameObject.SetActive(false);
    }
}
