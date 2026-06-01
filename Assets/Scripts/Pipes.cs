using UnityEngine;

public class Pipes : MonoBehaviour
{
    public static float speed = 5f;
    private float left;
    private void Start()
    {
        left = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 1f;
    }

    private void Update()
    {
        transform.position += Vector3.left * Time.deltaTime;

        transform.position += Vector3.left * speed * Time.deltaTime;
        if(transform.position.x < left){
            Destroy(gameObject);
        }
    }

}
