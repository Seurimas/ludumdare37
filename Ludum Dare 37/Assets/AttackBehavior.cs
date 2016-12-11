using UnityEngine;

public abstract class AttackBehavior : MonoBehaviour
{
    public abstract void engage(AdventurerAttackController me, GameObject target);
    public abstract void update(AdventurerAttackController me);
    public abstract float getAttackDistance(AdventurerAttackController me);
}