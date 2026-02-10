using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class RotationManagement : MonoBehaviour
{
    private LevelManager _levelManager;
    
    [SerializeField] private InputActionReference _clickAction;
    [SerializeField] private InputActionReference _pointerAction;

    [SerializeField] private UnityEvent OnDragReleased;
    
    private float rotationSpeed = 20f;
    private Vector2 lastPointer;
    private bool isDragging = false;

    private void Awake()
    {
        _levelManager = GetComponent<LevelManager>();
    }
    
    private void OnEnable()
    {
        _clickAction.action.Enable();
        _pointerAction.action.Enable();
        
        _clickAction.action.started += OnClicked;
        _clickAction.action.canceled += OnReleased;
    }

    private void OnDisable()
    {
        _clickAction.action.started -= OnClicked;
        _clickAction.action.canceled -= OnReleased;
        
        _clickAction.action.Disable();
        _pointerAction.action.Disable();
    }

    private void OnClicked(InputAction.CallbackContext _)
    {
        isDragging = true;
        lastPointer = _pointerAction.action.ReadValue<Vector2>();
    }

    private void OnReleased(InputAction.CallbackContext _)
    {
        isDragging = false;
        
        // Launch event
        OnDragReleased?.Invoke();
    }
    
    private void Update()
    {
        if (!isDragging) return;
        
        Vector2 current = _pointerAction.action.ReadValue<Vector2>();
        Vector2 delta = current - lastPointer;
        lastPointer = current;

        float rotX = delta.y * rotationSpeed * Time.deltaTime;
        float rotY = -delta.x * rotationSpeed * Time.deltaTime;

        switch (_levelManager.actualDifficulty)
        {
            case Difficulty.firstLevel:
                _levelManager.spawnedObject.transform.Rotate(0, rotY, 0, Space.World);
                break;

            case Difficulty.secondLevel:
            case Difficulty.thirdLevel:
                _levelManager.spawnedObject.transform.transform.Rotate(rotX, rotY, 0, Space.World);
                break;
        }
    }
}
