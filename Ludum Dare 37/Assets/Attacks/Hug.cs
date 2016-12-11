using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "Hug", menuName = "Attack/Hug", order = 1)]
public class Hug : ScriptableObject, AttackBehavior
{
    private GameObject target;
    public void engage(GameObject me, GameObject target)
    {
        this.target = target;
    }

    public void update(GameObject me)
    {
        if (me.GetComponent<AdventurerStateController>().state == AdventurerStateController.STATE.ATTACKING)
        {
            me.GetComponent<AdventurerMovementController>().advanceTowards(target.transform.position);
        }
    }

    public int getAttackDistance(GameObject me)
    {
        return 2;
    }
}
public class MakeScriptableObject
{
    [MenuItem("Assets/Create/My Scriptable Object")]
    public static void CreateMyAsset()
    {
        Hug asset = ScriptableObject.CreateInstance<Hug>();

        AssetDatabase.CreateAsset(asset, "Assets/Hug.asset");
        AssetDatabase.SaveAssets();

        EditorUtility.FocusProjectWindow();

        Selection.activeObject = asset;
    }
}