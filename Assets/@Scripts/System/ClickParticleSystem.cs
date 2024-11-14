using UnityEngine;
using UnityEngine.UI;

public class ClickParticleSystem
{

    private ParticleSystem particleSystem;

    public ClickParticleSystem(Button button)
    {
        particleSystem = button.GetComponentInChildren<ParticleSystem>();
        button.onClick.AddListener(StartParticleSystem);
    }

    public void StartParticleSystem()
    {
        particleSystem.Play();
    }

}