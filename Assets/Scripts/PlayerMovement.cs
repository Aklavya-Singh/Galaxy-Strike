using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 10f;
    [SerializeField] private float clampedXRange = 5f;
    [SerializeField] private float clampedYRange = 5f;

    [SerializeField] private float sideRotation = 10f;
    [SerializeField] private float rotationSpeed = 10f;
    [SerializeField] private float frontRotation = 10f;
    
    private Vector2 movement;

    private void Update()
    {
        MovementTranslation();
        RotationTranslation();
    }

    public void OnMove(InputValue value)
    {
        movement = value.Get<Vector2>();
    }

    private void MovementTranslation()
    {
        // X position
        float xOffset = movement.x * movementSpeed * Time.deltaTime;
        float rawXPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(rawXPos, -clampedXRange, clampedXRange);
        
        // Y position
        float yOffset = movement.y * movementSpeed * Time.deltaTime;
        float rawYPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(rawYPos, -clampedYRange, clampedYRange);
        
        transform.localPosition = new Vector3(clampedXPos, clampedYPos, 0f);
    }
    
    private void RotationTranslation()
    {
        float pitch = -frontRotation * movement.y;
        float roll = -sideRotation * movement.x;
        
        // "-sideRotation" because the rotation is opposite in the editor (positive to left and negative to right)
        Quaternion targetRotation = Quaternion.Euler(pitch, 0f, roll );
        transform.localRotation = Quaternion.Lerp(transform.localRotation, targetRotation, Time.deltaTime * rotationSpeed);
        
        
    }
    
}
