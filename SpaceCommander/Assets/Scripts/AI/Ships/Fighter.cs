using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter : Ship
{
    private void Start()
    {
        AddWeapons();
        AddModules();
    }

    public override void AddWeapons()
    {
        int index = 0;
        foreach (IWeapons i in gameObject.GetComponentsInChildren<IWeapons>())
        {
            index++;
            equipedWeapons.Add(i);
            if(index > weaponSlots)
            {
                return;
            }
        }
    }

    public override void AddModules()
    {
        int index = 0;
        foreach (IModules i in gameObject.GetComponentsInChildren<IModules>())
        {
            index++;
            equipedModules.Add(i);
            if (index > moduleCapacity)
            {
                return;
            }
        }
    }
}
