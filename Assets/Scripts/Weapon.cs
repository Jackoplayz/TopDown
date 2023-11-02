using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon 
{
    public static float coolDown, damage;
    public static GameObject projectile;
    public abstract void Fire();
    

}
