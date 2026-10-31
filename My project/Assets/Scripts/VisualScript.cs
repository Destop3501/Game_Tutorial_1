using UnityEngine;

public class VisualScript : MonoBehaviour
{
    [SerializeField] private ParticleSystem leftThrustPartical;
    [SerializeField] private ParticleSystem MiddleThrustPartical;
    [SerializeField] private ParticleSystem rightThrustPartical;

    private Lander lander;

    private void Awake()
    {
        lander = GetComponent<Lander>();

        lander.OnUpForce += Lander_OnUpForce;
        lander.OnLeftForce += Lander_OnLeftForce;
        lander.OnRightForce += Lander_OnRightForce;
        lander.OnBeforeForce += Lander_OnBeforeForce;
    }

    private void Lander_OnBeforeForce(object sender, System.EventArgs e)
    {
        ThrustParticleControl();
    }

    private void Lander_OnRightForce(object sender, System.EventArgs e)
    {
        ThrustParticleControl(leftThrust: true, middleThrust: false, rightThrust: false);
    }
    private void Lander_OnLeftForce(object sender, System.EventArgs e)
    {
        ThrustParticleControl(leftThrust: false, middleThrust: false, rightThrust: true);
    }
    private void Lander_OnUpForce(object sender, System.EventArgs e)
    {
        ThrustParticleControl(leftThrust: true, middleThrust: true, rightThrust: true);
    }
    private void Start()
    {
        ThrustParticleControl();
    }
    public void ThrustParticleControl(bool leftThrust = false, bool middleThrust = false, bool rightThrust = false)
    {
        ParticleSystem.EmissionModule leftThrustEmission = leftThrustPartical.emission;
        ParticleSystem.EmissionModule middleThrustEmission = MiddleThrustPartical.emission;
        ParticleSystem.EmissionModule rightThrustEmission = rightThrustPartical.emission;
        leftThrustEmission.enabled = leftThrust;
        middleThrustEmission.enabled = middleThrust;
        rightThrustEmission.enabled = rightThrust;
    }
}
