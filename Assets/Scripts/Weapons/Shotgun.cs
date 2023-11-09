
using UnityEngine;


public class Shotgun : Weapon
{
    public float maxSpreadDegrees;
    public int projectileCount;
    public override void FireEffect()
    {
        //Get the direction of the mouse click
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Vector3 lookDirection = ray.origin - transform.position;
        lookDirection.z = 0;
        //Normalize sets vector magnitude (the length) to 1
        lookDirection = lookDirection.normalized;
        Vector3 spawnPostion = transform.position + (bulletSpawnOffset * lookDirection);
        for (int i = 0; i < projectileCount; i++)
        {
            float deflectionDegrees = Random.Range(-maxSpreadDegrees, maxSpreadDegrees);
            Vector3 bulletDirection = Quaternion.Euler(0, 0, deflectionDegrees) * lookDirection;
            var bulletInstance = Instantiate(projectile, spawnPostion, Quaternion.identity);
            bulletInstance.GetComponent<Bullet>().Initialise(damage, projectileSpeed);
            bulletInstance.GetComponent<Bullet>().SetVelocity(bulletDirection);
            float angle = Vector3.SignedAngle(bulletDirection, Vector3.down, Vector3.forward);
            bulletInstance.transform.rotation = Quaternion.Euler(0, 0, -angle);
            
        }
    }
}
       