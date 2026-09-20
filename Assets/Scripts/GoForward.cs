using UnityEngine;

public class GoForward : MonoBehaviour
{
    public float speed = 12f;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);

        }
        else if (collision.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
        
    }
}
