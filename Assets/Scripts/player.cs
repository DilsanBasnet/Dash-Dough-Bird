using UnityEngine;
using UnityEngine.InputSystem;

public class player : MonoBehaviour
{
    public float gravity = -9.8f;
    private Vector3 direction;
    public float strength = 5f;
    private void Update() {
        bool jumpkey = false;
if(Keyboard.current != null)
        {
           jumpkey = Keyboard.current.spaceKey.wasPressedThisFrame|| 
           Keyboard.current.wKey.wasPressedThisFrame|| 
           Keyboard.current.upArrowKey.wasPressedThisFrame;
        }
        if(jumpkey)
        {
            direction = Vector3.up * strength;
        }

        direction.y += gravity * Time.deltaTime;
        transform.position += direction * Time.deltaTime;
    }
}
