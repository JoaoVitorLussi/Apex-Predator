using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 3f;
    public Vector3 moveDirection = Vector3.left;
    public float destroyDistance = 20f;

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        transform.position += moveDirection * speed * Time.deltaTime;

        if (Vector3.Distance(transform.position, startPosition) > destroyDistance)
        {
            Destroy(gameObject);
        }
    }
}
