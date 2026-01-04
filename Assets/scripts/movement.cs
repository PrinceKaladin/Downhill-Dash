using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class movement : MonoBehaviour
{
    public float speed = 5f;      
    public float topY = 1f;      
    public float bottomY = -1.5f;
    float currentSpeed = 0f;
    float speedVelocity = 0f;
    void Update()
    {
        float targetSpeed = 0f;

        if (Input.GetMouseButton(0))
        {
            if (Input.mousePosition.x > Screen.width / 2f)
                targetSpeed = 1f;
            else
                targetSpeed = -1f;
        }

        currentSpeed = Mathf.SmoothDamp(
            currentSpeed,
            targetSpeed,
            ref speedVelocity,
            0.15f // чем меньше Ч тем резче
        );

        Vector3 pos = transform.position;
        pos.y += currentSpeed * speed * Time.deltaTime;
        pos.y = Mathf.Clamp(pos.y, bottomY, topY);
        transform.position = pos;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "sn")
        {
            SceneManager.LoadScene(3);
        }
    }
}
