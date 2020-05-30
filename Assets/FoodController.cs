using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodController : MonoBehaviour
{
    // Food Prefab
    public GameObject foodPrefab;

    // Borders
    public Transform borderTop;
    public Transform borderBottom;
    public Transform borderLeft;
    public Transform borderRight;

    // Use this for initialization
    void Start()
    {
        // Spawn food every 4 seconds, starting in 3
        //TODO: use InvokeRepeating() method to run spawn every 4 seconds
    }

    // Spawn one piece of food
    void Spawn()
    {
        // x position between left & right border
        int x = (int)Random.Range(borderLeft.position.x,
                                  borderRight.position.x);

        // y position between top & bottom border
        //TODO: set y to a random value in proper range
        int y = 10;

        // Instantiate the food at (x, y)
        Instantiate(foodPrefab, new Vector2(x, y), Quaternion.identity); // default rotation
    }

}
