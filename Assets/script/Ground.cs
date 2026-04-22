using UnityEngine;

public class GroundMove : MonoBehaviour
{
    public float speed = 5f;
    public float speedIncrease = 1f;

    void Start()
    {
        InvokeRepeating("IncreaseSpeed", 5f, 5f); // 每5秒加速
    }

    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    void IncreaseSpeed()
    {
        speed += speedIncrease;
    }
}