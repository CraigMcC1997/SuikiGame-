using UnityEngine;

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

    void small_collision()
    {
        scoreTracker.Small_Scored();
        create_next_circle();
    }

    void big_collision()
    {
        scoreTracker.Big_Scored();
        create_next_circle();
    }

    void giant_collision()
    {
        scoreTracker.GetComponent<ScoreTracker>().Giant_Scored();
        create_next_circle();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("small-circle") && gameObject.CompareTag("small-circle"))
        {
            if (int.Parse(collision.gameObject.name) < int.Parse(gameObject.name))
            {
                small_collision();
            }

            Destroy(collision.gameObject); // Destroy the small circle after collision
        }

        else if (collision.gameObject.CompareTag("big-circle") && gameObject.CompareTag("big-circle"))
        {
            if (int.Parse(collision.gameObject.name) < int.Parse(gameObject.name))
            {
                big_collision();
            }

            Destroy(collision.gameObject); // Destroy the small circle after collision
        }

        else if (collision.gameObject.CompareTag("giant-circle") && gameObject.CompareTag("giant-circle"))
        {
            if (int.Parse(collision.gameObject.name) < int.Parse(gameObject.name))
            {
                giant_collision();
            }

            Destroy(collision.gameObject); // Destroy the small circle after collision
        }
    }
}
