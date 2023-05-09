using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteritanceTest : MonoBehaviour
{
    private void Start()
    {
        InteracterbleObject interacterbleObject = new InteracterbleObject();

        ItemA itemA = new ItemA();
        EnemyA enemyA = new EnemyA();
        EnemyB enemyB = new EnemyB();

        //interacterbleObject.GetName();
        //itemA.GetName();
        //enemyA.GetName();
        //enemyB.GetName();

        InteracterbleObject itemAA = new ItemA();
        InteracterbleObject enemyAA = new EnemyA();
        InteracterbleObject enemyBB = new EnemyB();

        itemAA.GetName();
        enemyAA.GetName();
        enemyBB.GetName();
    }
}

public class InteracterbleObject
{
    public virtual void GetName()
    {
        Debug.Log("InteracterbleObject");
    }
}

public class ItemA : InteracterbleObject
{
    public override void GetName()
    {
        Debug.Log("ItemA");
    }
}

public class EnemyA : InteracterbleObject
{
    public new void GetName()
    {
        Debug.Log("EnemyA");
    }
}

public class EnemyB : InteracterbleObject
{
    public void GetName()
    {
        Debug.Log("EnemyB");
    }
}
