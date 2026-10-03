using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 move =
            transform.right * horizontal +
            transform.forward * vertical;

        transform.position += move * speed * Time.deltaTime;
    }
}