using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Runemark.DialogueSystem
{

    public class PlayerStats : MonoBehaviour
    {
        public NavMeshAgent agent;
        public int playerPower;
        public int combatPower;

        public int MaxHealth;
        public int health;

        public int money;
        public bool HasEnoughParts;

        private void Start()
        {
            agent = GetComponent<NavMeshAgent>();
        }

        public void Combat()
        {
            if (playerPower <= 10)
            {
                var combat = Random.Range(1, playerPower);

                combatPower = combat;
            }
        }

        public void HealPlayer()
        {
            if (money >= 25)
            {
                HasEnoughParts = true;
                health = MaxHealth;
                money = money - 25;
            }

            else
            {
                HasEnoughParts = false;
            }

        }

        public void UpgradeHealth()
        {
            if (money >= 75)
            {
                HasEnoughParts = true;
                MaxHealth = MaxHealth + 1;
                health = MaxHealth;
                money = money - 75;
            }

            else
            {
                HasEnoughParts = false;
            }

        }

        public void UpgradeSpeed()
        {
            if (money >= 75)
            {
                HasEnoughParts = true;
                agent.speed = agent.speed + 1;
                money = money - 75;
            }

            else
            {
                HasEnoughParts = false;
            }

        }


        public void LoseHealth()
        {
            health = health - 2;
        }

        public void Update()
        {
            DialogueSystem.SetGlobalVariable("PlayerPower", combatPower);
            DialogueSystem.SetGlobalVariable("HasEnoughParts", HasEnoughParts);
        }
    }
}

