using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class UpgradeSystem : MonoBehaviour
{
    public int HP = 20;
    public int power = 10;
    public int speed = 20;
    public int parts = 0;

    NavMeshAgent agent;

    public void UpdateHP(int newHP)
    {
        HP += newHP;
    }

    public void UpdatePower(int newPower)
    {
        power += newPower;
    }

    public void UpdateSpeed(int newSpeed)
    {
        speed += newSpeed;
        agent.speed = speed;
    }

    public void UpdatePartsCount(int newParts)
    {
        parts += newParts;
    }

}
