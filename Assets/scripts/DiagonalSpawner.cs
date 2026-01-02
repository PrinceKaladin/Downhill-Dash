using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DiagonalSpawner : MonoBehaviour
{
    public GameObject prefabA;
    public GameObject prefabB;
    int scoree;
    public Vector2 spread = new Vector2(1.5f, 1.5f);
    public Vector2 moveDirection = new Vector2(-1f, -1f);
    public float speed = 2f;
    public Text scores;
    public float spawnInterval = 0.5f;
    public float lifeTime = 20f;

    void Start()
    {
        scoree = 0; 
        StartCoroutine(SpawnLoop());
        StartCoroutine(timer());
    }

    IEnumerator SpawnLoop()
    {
        while (true)
        {
            GameObject prefab = Random.value > 0.5f ? prefabA : prefabB;

            Vector2 offset = new Vector2(
                Random.Range(-spread.x, spread.x),
                Random.Range(-spread.y, spread.y)
            );

            GameObject obj = Instantiate(
                prefab,
                (Vector2)transform.position + offset,
                Quaternion.identity
            );

            obj.AddComponent<DiagonalMove>().Init(moveDirection.normalized, speed);
            Destroy(obj, lifeTime);

            yield return new WaitForSeconds(spawnInterval);
        }
    }
    IEnumerator timer() {
        while (true)
        {
            PlayerPrefs.SetInt("score", scoree);
            scoree += 1;

            yield return new WaitForSeconds(1);
            scores.text = "Distance: " + scoree.ToString();
            if (PlayerPrefs.GetInt("best", 0) < scoree)
            {
                PlayerPrefs.SetInt("best", scoree);
            }
        }
    }
}

public class DiagonalMove : MonoBehaviour
{
    Vector2 dir;
    float speed;

    public void Init(Vector2 direction, float moveSpeed)
    {
        dir = direction;
        speed = moveSpeed;
    }

    void Update()
    {
        transform.Translate(dir * speed * Time.deltaTime);
    }
}
