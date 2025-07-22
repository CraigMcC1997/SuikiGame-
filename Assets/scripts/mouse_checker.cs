using UnityEngine;
using UnityEngine.InputSystem;

public class mouse_checker : MonoBehaviour
{
    public GameObject[] circleArray = new GameObject[3];

    public int clickCounter = 0;
    bool circleCreated = false;

    GameObject newObject;

    Mouse mouse;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mouse = Mouse.current;
    }

    GameObject pick_random_circle()
    {
        int randomIndex = Random.Range(0, circleArray.Length);
        return circleArray[randomIndex];
    }

    void add_circle()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(mouse.position.ReadValue());
        mousePosition.z = 0; // Set z to 0 for 2D

        GameObject chosenCirclePrefab = pick_random_circle();

        newObject = (GameObject)Instantiate(chosenCirclePrefab, mousePosition, transform.rotation);
        newObject.name = clickCounter.ToString(); // Set the name of the new circle to the click count
        newObject.GetComponent<Rigidbody2D>().gravityScale = 0; // Disable gravity initially
        newObject.GetComponent<Collider2D>().isTrigger = true; // Set the collider to trigger to avoid immediate collisions

    }

    void drop_circle()
    {
        newObject.GetComponent<Rigidbody2D>().gravityScale = 1; // Enable gravity on the circle
        circleCreated = false; // Reset the flag to allow for new circle creation
        newObject.GetComponent<Collider2D>().isTrigger = false; // Disable trigger to allow for collisions
    }

    // Update is called once per frame
    void Update()
    {
        if (!circleCreated)
        {
            add_circle();
            circleCreated = true;
        }
        else
        {
            if (mouse.leftButton.wasPressedThisFrame)
            {
                clickCounter++;
                drop_circle();
            }
            else
            {
                Vector3 mousePosition = Camera.main.ScreenToWorldPoint(mouse.position.ReadValue());

                mousePosition.y = 4.5f - newObject.transform.localScale.y; // Adjust y position based on circle size

                if (newObject != null)
                    newObject.transform.position = new Vector3(mousePosition.x, mousePosition.y, 0.0f);
            }
        }
    }
}
