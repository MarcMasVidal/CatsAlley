using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassTurn : MonoBehaviour
{
    private MenuPanel p;
    private HandManager h;
    public MenuPanel checkSteal;
    private bool hided = false;

    private void Awake()
    {
        TurnManager.manaLimit = 9;
        TurnManager.maxMana = 1;
        TurnManager.currentTurn = 0;
        TurnManager.currentMana = 0;
        TurnManager.CardDrawn = false;
        TurnManager.ExtraCards = false;
        TurnManager.Spawned = false;
    }
    private void Start()
    {
        h = FindObjectOfType<HandManager>();
        p = GetComponent<MenuPanel>();
    }
    private void Update()
    {
        if (TurnManager.TeamTurn != Team.TeamPlayer && !p.isHided)
        {
            p.Hide();
        }
        if (TurnManager.TeamTurn == Team.TeamPlayer && HandManager.HandPlayer.Count <= HandManager.HandLimit && p.isHided && checkSteal.isHided)
        {
            StartCoroutine(ReCheck());
        }
    }
    private IEnumerator ReCheck()
    {
        yield return new WaitForSeconds(0.5f);
        if (checkSteal.isHided)
            p.Show();
    }
}
