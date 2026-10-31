using TMPro;
using UnityEngine;

public class LandingPadText : MonoBehaviour
{
    [SerializeField] private TextMeshPro landingPadText;

    private void Awake()
    {
        LandingPad landingPad = GetComponent<LandingPad>();
        landingPadText.text = "x" + landingPad.getScoreMutifier().ToString();
    }
}
