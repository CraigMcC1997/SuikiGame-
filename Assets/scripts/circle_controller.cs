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
        var newObject = (GameObject)Instantiate(nextPrefab, transform.position, Quaternion.identity);
        newObject.name = num.ToString(); // Set the name of the newly created bigger circle
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(this.gameObject.tag))
        {
            // To prevent duplicate creation, first the smaller fruit is destroyed
            // and then the bigger fruit is created.
            // Finally the bigger of the two smaller fruits is destroyed.
            if (int.Parse(collision.gameObject.name) < int.Parse(gameObject.name))
            {
                Destroy(this.gameObject);
                scoreTracker.Scored(gameObject.tag);
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
