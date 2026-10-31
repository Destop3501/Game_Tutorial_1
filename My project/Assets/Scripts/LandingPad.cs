using UnityEngine;

public class LandingPad : MonoBehaviour
{
    [SerializeField] private float landingPadMutifier = 1f;

    public float getScoreMutifier()
    {
        return landingPadMutifier;
    }
}
