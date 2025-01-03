using UnityEngine;

public class HideMouse : MonoBehaviour
{
    [SerializeField] private bool _isVisible = false;

    private void Start()
    {
        Cursor.visible = _isVisible;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleCursor();
        }
    }

    private void ToggleCursor()
    {
        _isVisible = !_isVisible;
        Cursor.visible = _isVisible;

        if (_isVisible)
            Cursor.lockState = CursorLockMode.None;
        else
            Cursor.lockState = CursorLockMode.Locked;
    }
}
