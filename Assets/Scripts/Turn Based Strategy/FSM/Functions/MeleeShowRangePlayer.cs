using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeShowRangePlayer : CombatPlayerBehaviour
{
    public delegate void HidePathEnterDelegate();
    public static HidePathEnterDelegate OnHidePathEnter;

    private void OnEnable()
    {
        MeleeShowRangeBehaviour.OnMeleeShowRangeEnter += MeleeShowRangeEnter;
    }
    private void OnDisable()
    {
        MeleeShowRangeBehaviour.OnMeleeShowRangeEnter -= MeleeShowRangeEnter;
    }
    private void MeleeShowRangeEnter()
    {
        var enemyHeroOnRange = false;
        var cellSize = TileManager.CellSize;
        var attackRange = _executorCharacter.Range + 1;
        var counter = 0;

        for (int j = -attackRange; j <= attackRange; j++)
        {
            if (j <= 0) counter++;
            else counter--;

            for (int i = -attackRange; i <= attackRange; i++)
            {
                var position = new Vector3Int(i, j, 0);
                var currentGridPosition = _executorGridPosition + position;
                var currentGridCenterPosition = currentGridPosition + cellSize;

                var IsMovementRange = Mathf.Abs(i) < counter - 1;

                var IsAttackRange = Mathf.Abs(i) <= counter;

                if (IsMovementRange)
                {
                    var ThereIsAnEnemyHero = InTile(currentGridCenterPosition) == (int)EntityType.EnemyHero;
                    if (_floorTilemap.HasTile(currentGridPosition))
                    {
                        var ThereIsAnEnemyCharacter = InTile(currentGridCenterPosition) == (int)EntityType.EnemyCharacter;
                        var ThereIsNothing = CanMove(currentGridPosition) && InTile(currentGridCenterPosition) == (int)EntityType.Nothing;
                        var ThereIsAnAlly = InTile(currentGridCenterPosition) == (int)EntityType.AllyCharacter;
                        var ThereIsACollider = _collisionTilemap.HasTile(currentGridPosition);

                        if (ThereIsAnEnemyCharacter)
                            _uITilemap.SetTile(currentGridPosition, _targetTile);

                        else if (_executorGridPosition == currentGridPosition)
                            _uITilemap.SetTile(currentGridPosition, _pointingTile);

                        else if (ThereIsNothing)
                            _uITilemap.SetTile(currentGridPosition, _allyTile);

                        else if (ThereIsACollider || ThereIsAnAlly)
                        {
                            _uITilemap.SetTile(currentGridPosition, _collisionAllyTile);
                        }
                    }
                    else if (ThereIsAnEnemyHero)
                        enemyHeroOnRange = true;
                }

                else if (IsAttackRange)
                {
                    var ThereIsAnEnemyCharacter = InTile(currentGridCenterPosition) == (int)EntityType.EnemyCharacter;
                    var ThereIsAnEnemyHero = InTile(currentGridCenterPosition) == (int)EntityType.EnemyHero;

                    if (ThereIsAnEnemyCharacter)
                        _uITilemap.SetTile(currentGridPosition, _targetTile);
                    else if (ThereIsAnEnemyHero)
                        enemyHeroOnRange = true;
                }
            }
        }
        if (enemyHeroOnRange)
        {
            ShowHeroTiles();
        }
    }

}
