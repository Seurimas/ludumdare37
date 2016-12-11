using UnityEngine;

public interface AttackBehavior
{
    void engage(GameObject me, GameObject target);
    void update(GameObject me);
    int getAttackDistance(GameObject me);
}