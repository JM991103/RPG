using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// menuName : ����Ƽ �޴��� ǥ��Ǵ� �̸�
// order : �޴����� ���� ����
// fileName : ���� ����� �⺻���� �����Ǵ� �̸�
[CreateAssetMenu(fileName = "Item", menuName = "Inventory/Item", order = 1)]
public class Item : ScriptableObject
{
    public string name = "Item";
    public Sprite icon = null;

    public virtual void Use()
    {
        Debug.Log("Using" + name);
    }

    public void RemoveFromInventory()
    {
        Inventory.instance.Remove(this);
    }
}
