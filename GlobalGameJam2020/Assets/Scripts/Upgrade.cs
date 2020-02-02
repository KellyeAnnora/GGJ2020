using UnityEngine;

[CreateAssetMenu(fileName = "New Upgrade", menuName = "Upgrade")]
public class Upgrade : ScriptableObject
{
    new public string name = "New Upgrade";
    new public string description = "Description";
    public int cost;

    public int HPModifier;
    public int speedModifier;
    public int powerModifier;
}

