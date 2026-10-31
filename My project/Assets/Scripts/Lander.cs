using UnityEngine;
using UnityEngine.InputSystem;

public class Lander : MonoBehaviour
{

    private Rigidbody2D landerRigidbody2D;
    protected float upwordforce = 1000f;
    protected float rotation = 100;
    private LandingPad landPad;
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
        landPad = collision2D.gameObject.GetComponent<LandingPad>();
        if (collision2D.gameObject.tag != "LandingPad")
        {
            Debug.Log("Crashed");
            return;
        }
        float softHandling = 4f;
        float relativeVelocity = collision2D.relativeVelocity.magnitude;
        if (relativeVelocity > softHandling)
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

        float MaxScoreLandingAmount = 100f;
        float scoreDotVectorMultiplier = 10f;
        float LandingAnglescore = MaxScoreLandingAmount - Mathf.Abs(dotVecter2D - 1f) * scoreDotVectorMultiplier * MaxScoreLandingAmount;

        float MaxScoreLandingSpeed = 100f;
        float LandingSpeedScore = (softHandling - relativeVelocity) * MaxScoreLandingSpeed;

        int score = Mathf.RoundToInt((LandingAnglescore + LandingSpeedScore) * landPad.getScoreMutifier());
        Debug.Log("You Landed Successfully with a score of: " + score);
    }
}
