using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rifle : Weapon
{
    public override void FireEffect()
    {
        //Get the direction of the mouse click
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Vector3 lookDirection = ray.origin - transform.position;
        lookDirection.z = 0;
        //Normalize sets vector magnitude (the length) to 1
        lookDirection = lookDirection.normalized;

        Vector3 spawnPostion = transform.position + (bulletSpawnOffset * lookDirection);

        var bulletInstance = Instantiate(projectile, spawnPostion, Quaternion.identity);

        bulletInstance.GetComponent<Bullet>().Initialise(damage, projectileSpeed);
        bulletInstance.GetComponent<Bullet>().SetVelocity(lookDirection);

        float angle = Vector3.SignedAngle(lookDirection, Vector3.down, Vector3.forward);
        bulletInstance.transform.rotation = Quaternion.Euler(0, 0, -angle);
    }
}
