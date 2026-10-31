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
            Debug.Log("down");
        }
    }
    private void OnCollisionEnter2D(Collision2D collision2D)
    {
        float softHandlling = 4f;
        if (collision2D.relativeVelocity.magnitude > softHandlling)
        {
            Debug.Log("You Crashed");
            return;
        }

        float dotVecter2D = Vector2.Dot(Vector2.up, transform.up);
        float minDotVector = 0.95f;
        if (dotVecter2D < minDotVector)
        {
            Debug.Log("You Crashed");
            Debug.Log(dotVecter2D);
            return;
        }
        Debug.Log("You Landed");
        Debug.Log(dotVecter2D);
    }
}
