using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasDamage : MonoBehaviour
{
    private Team team;
    public int turns;
    public int damage;
    private int currentTurns = 0;
    private bool executed = false;
    public Vector2 tileSize = new Vector2(2,2);
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, tileSize);
    }
    private void Awake()
    {
        team = TurnManager.TeamTurn;
        Execute();
    }
    private void Update()
    {
        if (turns <= currentTurns)
            Destroy(gameObject);

        if (TurnManager.TeamTurn == team && !executed)
        {
            Execute();
        }
        else if(executed && TurnManager.TeamTurn != team)
        {
            executed = false;
        }
        
    }
    private void Execute()
    {
        currentTurns++;
        Collider2D[] inTrigger = Physics2D.OverlapBoxAll(transform.position, tileSize, 360);
        print(inTrigger.Length);
        Damage(inTrigger);
        executed = true;
    }
    private void Damage(Collider2D[] inTrigger )
    {
        List<Collider2D> damaged = new List<Collider2D>();
        for (int i = 0; i < inTrigger.Length; i++)
        {
            if (inTrigger[i].CompareTag("Character") && !damaged.Contains(inTrigger[i]))
            {
                HealthSystem.TakeDamage(damage, inTrigger[i].GetComponent<Character>());
            }
        }
    }
}
