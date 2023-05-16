using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Potion", menuName = "Inventory/Potion", order = 2)]
public class Potion : Item
{
    public int heal;

    public override void Use()
    {
        //base.Use();
        Player.instance.Stat.Heal(heal);
        RemoveFromInventory();
    }
}
