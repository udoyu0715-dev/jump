using UnityEngine;

public class GroundMove : MonoBehaviour
{
    public float speed = 5f;
    public float speedIncrease = 1f;

    public float groundWidth = 20f;

    void Start()
    {
        InvokeRepeating(nameof(IncreaseSpeed), 5f, 5f);
    }

    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        if (transform.position.x <= -groundWidth)
        {
            transform.position += new Vector3(groundWidth * 2f, 0f, 0f);
        }
    }

    void IncreaseSpeed()
    {
        speed += speedIncrease;
    }
}