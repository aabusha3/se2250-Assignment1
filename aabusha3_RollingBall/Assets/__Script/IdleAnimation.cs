using UnityEngine;


public class IdleAnimation : MonoBehaviour
{
    public float yOffset = 0.5f;
    public float floatSpeed = 2f;
    public float offset = 0.02f;
    public float rotationSpeed = 0.1f;

    private Vector3 startPos;
    private float newY;
    private Vector3 endPos;
    private float direction = 1f;
    private float rotationAngle = 1f;
    private SpawnPickUps ground;

    void Start()
    {
        ground = GameObject.FindGameObjectWithTag("Ground").GetComponent<SpawnPickUps>();

        startPos = transform.position;
        newY = startPos.y - yOffset;
        endPos = new Vector3(transform.position.x, newY, transform.position.z);
    }

    void Update()
    {
        if(transform.position.y > 1.6 || transform.position.y < 0 || Mathf.Abs(transform.position.x) > Mathf.Abs(ground.transform.localScale.x / 2f) - 0.5f || Mathf.Abs(transform.position.z) > Mathf.Abs(ground.transform.localScale.z / 2f) - 0.5f)
            Destroy(gameObject);

        transform.position = Vector3.Lerp(transform.position, endPos, floatSpeed * Time.deltaTime);

        if ((transform.position.y * direction) < (newY + (offset * direction)) * direction)
        {
            yOffset *= -1f;
            newY = startPos.y - yOffset;
            endPos = new Vector3(transform.position.x, newY, transform.position.z);
            direction *= -1f;
        }

            
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, rotationAngle, transform.eulerAngles.z);
        rotationAngle++;
        if(rotationAngle == 360f)
            rotationAngle = 1f;
    }
}