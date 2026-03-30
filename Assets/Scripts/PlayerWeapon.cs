using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] private ParticleSystem[] lasers;
    [SerializeField] private RectTransform crosshair;
    [SerializeField] private GameObject targetObject;

    private const float objectDistance = 100f;
    private bool isFiring;
    private Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;
        Cursor.visible = false;
    }

    private void Update()
    {
        CrosshairMovement();
        MoveTargetPoint();
        AimLasers();
    }

    public void OnFire(InputValue value)
    {
        isFiring = value.isPressed;
        FiringProcess();
    }

    private void FiringProcess()
    {
        foreach (ParticleSystem laser in lasers)
        {
            var particleEmission = laser.emission;
            particleEmission.enabled = isFiring;
        }
    }

    private void CrosshairMovement()
    {
        crosshair.position = Input.mousePosition;
    }

    private void MoveTargetPoint()
    {
        Vector3 targetPointPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, objectDistance);
        targetObject.transform.position = mainCamera.ScreenToWorldPoint(targetPointPosition);
    }

    private void AimLasers()
    {
        foreach (ParticleSystem laser in lasers)
        {
            Vector3 fireDirection = targetObject.transform.position - transform.position;
            Quaternion rotationToTarget = Quaternion.LookRotation(fireDirection);
            laser.transform.rotation = rotationToTarget;
        }
    }
}
