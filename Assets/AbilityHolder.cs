using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityHolder : MonoBehaviour
{
    public Ability ability;
    float cooldownTime; 
    float activeTime;

    enum AbilityState
    {
        ready,
        active,
        cooldown
    }
    AbilityState state =  AbilityState.ready;
    public KeyCode key;
    
    void Update()
    {
        switch (state)
        {
            case AbilityState.ready:
                // Check if Tab is pressed to activate the ability
                if (Input.GetKeyDown(KeyCode.Tab))
                {
                    ability.Activate(gameObject);
                    state = AbilityState.active;
                    activeTime = ability.activeTime;
                }
                break;
		
				
            case AbilityState.active:
                if (activeTime > 0)
                {
                    activeTime -= Time.deltaTime;
                }
                else
                {
                    ability.BeginCooldown(gameObject);
                    state = AbilityState.cooldown;
                    cooldownTime = ability.cooldownTime;
                }
                break;
            case AbilityState.cooldown:
                if (cooldownTime > 0)
                {
                    cooldownTime -= Time.deltaTime;
                }
                else
                {
                    state = AbilityState.ready;
                }
                break;
        }
    }
}
