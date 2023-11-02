using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public float coolDown, damage, projectileSpeed, bulletSpawnOffset, coolDownTimer;
    public GameObject projectile;
    public bool readyToFire;
    public void Fire() {
        if (!readyToFire) return;

        readyToFire = false;
        coolDownTimer = 0;

        FireEffect();
    }

    public abstract void FireEffect();
   
    private void Start()
    {
        coolDownTimer = 0;
        readyToFire = true;
    }

    private void Update()
    {
        if (!readyToFire)
        {
            coolDownTimer += Time.deltaTime;
            if(coolDownTimer > coolDown)
            {
                readyToFire = true;
            }
        }
    }

}
