using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class PlayerController : MonoBehaviour
{
    // Current Movement Direction
    // (by default it moves to the right)
    Vector2 dir = Vector2.right;

    // Did the snake eat something?
    bool ate = false;

    // Tail Prefab
    public GameObject tailPrefab;

    // Keep Track of Tail
    List<Transform> tails = new List<Transform>();

    // Use this for initialization
    void Start()
    {
        // Move the Snake every 300ms
        InvokeRepeating("Move", 0.3f, 0.3f);
    }

    // Update is called once per frame
    void Update()
    {
        // Move in a new Direction?
        if (Input.GetKey(KeyCode.RightArrow))
            dir = Vector2.right;
        //TODO: set dir to proper direction for other arrow keys, left, up, down
    }

    void Move()
    {
        // Save current position (gap will be here)
        Vector2 v = transform.position;

        // Move head into new direction (now there is a gap)
        transform.Translate(dir);

        // Ate something? Then insert new Element into gap
        if (ate)
        {
            // Load Prefab into the world
            GameObject g = (GameObject)Instantiate(tailPrefab, v, Quaternion.identity);

            // Keep track of it in our tail list
            //TODO: add new object's transform to the beginning of the tails list

            // Reset the flag
            ate = false;
        }
        // Do we have a Tail?
        else if (tails.Count > 0)
        {
            // Move last Tail Element to where the Head was
            tails.Last().position = v;

            // Add to front of list, remove from the back
            tails.Insert(0, tails.Last());

            //TODO: remove last item from last place in list
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        // Did the player collide with food?
        if (coll.name.StartsWith("FoodPrefab"))
        {
            // Get longer in next Move call
            ate = true;

            // Remove the Food
            Destroy(coll.gameObject);
        }
        // Collided with Tail or Border
        else
        {
            //TODO: game over message
            //TODO: restart game
        }
    }
}
