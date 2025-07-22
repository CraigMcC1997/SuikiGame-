using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class circle_controller : MonoBehaviour
{
    public GameObject nextPrefab;
    public GameObject mouseChecker;
    public ScoreTracker scoreTracker;

    public void Start()
    {
        scoreTracker = GameObject.Find("ScoreTracker").GetComponent<ScoreTracker>();
    }

    void create_next_circle()
    {
        int num = mouseChecker.GetComponent<mouse_checker>().clickCounter++;
        Vector3 position = transform.position;
        var newObject = (GameObject)Instantiate(nextPrefab, position, Quaternion.identity);
        newObject.name = num.ToString(); // Set the name of the new bigger circle
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(this.gameObject.tag))
        {
            // to prevent duplicated fruits, we find the smaller name and allow it to Destroy itself
            // and make the bigger fruit before the bigger number is destroyed
            if (int.Parse(collision.gameObject.name) < int.Parse(gameObject.name))
            {
                Destroy(this.gameObject);
                switch (gameObject.tag)
                {
                    case "Cherry":
                        scoreTracker.CherryScored();
                        break;
                    case "Strawberry":
                        scoreTracker.StrawberryScored();
                        break;
                    case "Grape":
                        scoreTracker.GrapeScored();
                        break;
                }
                create_next_circle();
                Destroy(collision.gameObject); // Destroy the smaller circle after collision
            }

        }
        // if the fruits spill over the top then the game ends
        else if (collision.gameObject.name == "Danger Ground")
        {
            Debug.Log("!! GAME OVER !!");
            Destroy(gameObject); // Destroy the circle if it collides with the ground
        }
    }
}
