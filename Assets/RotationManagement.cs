using UnityEngine;

public class RotationManagement : MonoBehaviour
{
    [SerializeField] private GameObject actualObject;

    private enum Difficulty : byte
    {
        firstLevel = 0,
        secondLevel = 1,
        thirdLevel = 2
    }
    private Difficulty actualDifficulty = Difficulty.secondLevel;

    private bool isDragging = false;
    private Vector3 lastMousePosition;
    private float rotationSpeed = 20f;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isDragging = true;
            lastMousePosition = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
        }

        if (isDragging)
        {
            Vector3 mouseDelta = Input.mousePosition - lastMousePosition;
            lastMousePosition = Input.mousePosition;

            float rotX = mouseDelta.y * rotationSpeed * Time.deltaTime;
            float rotY = -mouseDelta.x * rotationSpeed * Time.deltaTime;

            switch (actualDifficulty)
            {
                case Difficulty.firstLevel:
                    actualObject.transform.Rotate(0, rotY, 0, Space.World);
                    break ;
                case Difficulty.secondLevel:
                case Difficulty.thirdLevel:
                    actualObject.transform.Rotate(rotX, rotY, 0, Space.World);
                    break ;
            }
        }
    }
}
