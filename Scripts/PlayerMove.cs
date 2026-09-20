using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float rotationSpeed = 10f; 

    private Rigidbody2D rb;
    private float horizontal;  
    private float vertical;    
    private Vector2 movement;
    private float targetZAngle = 0f; 

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        movement = new Vector2(horizontal, vertical).normalized;

        ManagePlayerRotation();
    }

    private void FixedUpdate()
    {
        Vector2 target = rb.position + movement * moveSpeed * Time.fixedDeltaTime;
        rb.MovePosition(target);
    }

    private void ManagePlayerRotation()
    {
        if (horizontal > 0.1f) targetZAngle = -90f;  
        if (horizontal < -0.1f) targetZAngle = 90f;   
        if (vertical > 0.1f) targetZAngle = 0f;    
        if (vertical < -0.1f) targetZAngle = 180f;  

        if (horizontal > 0.1f && vertical > 0.1f) targetZAngle = -45f;  
        if (horizontal < -0.1f && vertical > 0.1f) targetZAngle = 45f;   
        if (horizontal > 0.1f && vertical < -0.1f) targetZAngle = -135f; 
        if (horizontal < -0.1f && vertical < -0.1f) targetZAngle = 135f;  

       
        if (movement.sqrMagnitude > 0.01f)
        {
            Quaternion targetRotation = Quaternion.Euler(0, 0, targetZAngle);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }
}