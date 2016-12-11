using UnityEngine;

public interface AttackBehavior
{
    void engage(AdventurerAttackController me, GameObject target);
    void update(AdventurerAttackController me);
    float getAttackDistance(AdventurerAttackController me);
}