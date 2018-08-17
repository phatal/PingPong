using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    [SerializeField] float speed;

    float radius;
    Vector2 direction;
    // Use this for initialization
    void Start()
    {
        direction = Vector2.one.normalized; //direction is (-1, 1) normalized
        radius = GetComponent<SpriteRenderer>().bounds.extents.x; //gловину 
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);

        if (transform.position.x < GameManager.BottomLeft.x + radius && direction.x < 0)
        {
            direction.x = -direction.x;
        }

        if (transform.position.x > GameManager.TopRight.x - radius && direction.x > 0)
        {
            direction.x = -direction.x;
        }

        if (transform.position.y < GameManager.BottomLeft.y + radius && direction.x < 0)
        {
            Debug.Log("bottom player wins");
            Time.timeScale = 0;
            enabled = false;
        }
        if (transform.position.y > GameManager.TopRight.y - radius && direction.y > 0)
        {
            Debug.Log("topPlayerWins");
            Time.timeScale = 0;
            enabled = false;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("pad"))
        {
            bool isTop = other.GetComponent<Pad>().GetPadPosition() == PadPosition.Top;

            if (isTop && direction.y > 0)
            {
                direction.y = -direction.y;
            }

            if (!isTop && direction.y < 0)
            {
                direction.y = -direction.y;
            }
        }
    }

}