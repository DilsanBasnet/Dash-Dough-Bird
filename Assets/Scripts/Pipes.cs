using UnityEngine;

public class Pipes : MonoBehaviour
{
    public float speed = 5f;
    private float left;
    private void Start()
    {
        left = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 1f;
    }

    private void Update()
    {
        if(this == null)
        return;

        transform.position += Vector3.left * speed * Time.deltaTime;
        if(transform.position.x < left){
            Destroy(gameObject);
        }
    }

}
