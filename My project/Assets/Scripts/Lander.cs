using UnityEngine;
using UnityEngine.InputSystem;

public class Lander : MonoBehaviour
{

    private Rigidbody2D landerRigidbody2D;
    protected float upwordforce = 1000f;
    protected float rotation = 100;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        landerRigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (Keyboard.current.upArrowKey.isPressed || Keyboard.current.wKey.isPressed){
            landerRigidbody2D.AddForce(upwordforce * transform.up * Time.deltaTime);
        }
        if (Keyboard.current.leftArrowKey.isPressed || Keyboard.current.aKey.isPressed){
            landerRigidbody2D.AddTorque(+rotation * Time.deltaTime);
        }
        if (Keyboard.current.rightArrowKey.isPressed || Keyboard.current.dKey.isPressed){
            landerRigidbody2D.AddTorque(-rotation * Time.deltaTime);
        }
        if (Keyboard.current.downArrowKey.isPressed || Keyboard.current.sKey.isPressed){
            Debug.Log("up");
        }
    }
}
