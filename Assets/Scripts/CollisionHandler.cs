using Unity.VisualScripting;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] private GameObject playerDestroyedVFX;
    
    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Enemy")) return;
        Instantiate(playerDestroyedVFX, transform.position, Quaternion.identity); 
        Destroy(gameObject);
    }
}
