using UnityEngine;
using UnityEngine.InputSystem;

public class TrackerController : MonoBehaviour
{
    Mouse mouse;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mouse = Mouse.current;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(mouse.position.ReadValue());
        transform.position = new Vector3(mousePosition.x, transform.position.y, transform.position.z);
    }
}
