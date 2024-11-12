using System;
using UnityEngine;


[CreateAssetMenu(fileName = "Player", menuName = "Player")]
public class PlayerSO : CreatureSO
{
    [SerializeField] private ExperienceData experienceData;
    [SerializeField] private JumpData jumpData;

    public ExperienceData ExperienceData => experienceData;
    public JumpData JumpData => jumpData;
}




[Serializable]
public class ExperienceData
{
    [field: SerializeField] public int Level { get; private set; }
    [field: SerializeField] public float RequiredEXP { get; private set; }
    [field: SerializeField]public float CurEXP { get; private set; }
    [field: SerializeField]public int ExperienceGain  { get; private set; }
}


[Serializable]
public class JumpData
{
    [field: SerializeField] public float JumpForce { get; private set; }
}
