using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float force;
    public float smoothTime;


    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }


    void FixedUpdate()
    {
        Vector3 velocity = rb.velocity;
        float targetX = 0f, targetZ = 0f;

        if (Input.GetKey("w") || Input.GetKey(KeyCode.UpArrow))
            targetZ = force;

        if (Input.GetKey("a") || Input.GetKey(KeyCode.LeftArrow))
            targetX = -force;

        if (Input.GetKey("s") || Input.GetKey(KeyCode.DownArrow))
            targetZ = -force;

        if (Input.GetKey("d") || Input.GetKey(KeyCode.RightArrow))
            targetX = force;


        velocity.x = Mathf.MoveTowards(velocity.x, targetX, Time.fixedDeltaTime / smoothTime);
        velocity.z = Mathf.MoveTowards(velocity.z, targetZ, Time.fixedDeltaTime / smoothTime);
        
        velocity += Physics.gravity * Time.fixedDeltaTime;
        rb.velocity = velocity;
    }
}
