using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class IAUseAbilities : MonoBehaviour
{
    List<Character> IACharacters;
    private void OnEnable()
    {
        SpawningAI.abilityDelegate_ += WhatCharacterHasLowestManaAbility;

    }
    private void OnDisable()
    {
        SpawningAI.abilityDelegate_ -= WhatCharacterHasLowestManaAbility;
    }
    public void WhatCharacterHasLowestManaAbility(int currentMana)
    {
        print("abailty busvando");

        IACharacters = EntityManager.GetCharacters(Team.TeamAI).ToList();
        UseAbility unitWithAbility = null;

        for (int i = 0; i < IACharacters.Count; i++)
        {
            UseAbility temp = IACharacters[i].GetComponent<UseAbility>();
            print("index de lowest mana: " + i);
            if (temp)
            {
                print("hay abilidad? "+ temp);
                if (!unitWithAbility)
                {
                    unitWithAbility = temp;
                }else if (temp.ability.whiskasCost < currentMana && temp.ability.whiskasCost> unitWithAbility.ability.whiskasCost) //ia choose the ability with the lowest mana cost. (min. 1 man�)
                {

                    unitWithAbility = temp;
                }
                
            }
            
        }
        if (unitWithAbility)
        {
            unitWithAbility.IAUse();
        }
           

        TurnManager.Spawned = true;
    }

    
}
