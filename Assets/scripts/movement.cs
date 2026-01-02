using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class movement : MonoBehaviour
{
    public float speed = 5f;      
    public float topY = 1f;      
    public float bottomY = -1.5f;  

    void Update()
    {
        float move = 0f;


        if (Input.GetMouseButton(0))
        {
            float tapX = Input.mousePosition.x;

            if (tapX > Screen.width / 2f)
                move = 1f;  
            else
                move = -1f;  
        }

        if (move != 0f)
        {
            Vector3 pos = transform.position;
            pos.y += move * speed * Time.deltaTime;


            pos.y = Mathf.Clamp(pos.y, bottomY, topY);

            transform.position = pos;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "sn")
        {
            SceneManager.LoadScene(3);
        }
    }
}
