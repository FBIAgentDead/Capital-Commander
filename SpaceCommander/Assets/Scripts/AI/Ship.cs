using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ship : MonoBehaviour
{
    protected List<IWeapons> equipedWeapons = new List<IWeapons>();
    public int weaponSlots = 1;
    protected List<IModules> equipedModules = new List<IModules>();
    public int moduleCapacity = 1;
    protected List<IWeapons> activatedWeapons = new List<IWeapons>();
    protected float heatEfficiency = 10;
    public float heatSignature = 0;

    private void Start()
    {
        foreach(IModules a in equipedModules)
        {
            a.ActivateBuff(this);
        }
    }

    public virtual void Shoot()
    {
        foreach (IWeapons i in activatedWeapons)
        {
            i.Shoot();
            heatSignature += 10 - (heatEfficiency * Time.deltaTime);
        }
    }

    private void Update()
    {
        if(heatSignature > 0)
        {
            heatSignature -= heatEfficiency * Time.deltaTime;
        }
    }

    public abstract void AddWeapons();
    public abstract void AddModules();

}
