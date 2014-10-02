using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public ItemContainer powerupContainer;

    public int damagePerShot = 20;
    public float timeBetweenBullets = 0.15f;
    public float range = 100f;

    public Material normalgunLine;
    public Material fireGunLine;
    public Material iceGunLine;

    float timer;
    Ray shootRay;
    RaycastHit shootHit;
    int shootableMask;
    ParticleSystem gunParticles;
    LineRenderer gunLine;
    AudioSource gunAudio;
    Light gunLight;
    float effectsDisplayTime = 0.2f;

    void Awake ()
    {
        shootableMask = LayerMask.GetMask ("Shootable");
        gunParticles = GetComponent<ParticleSystem> ();
        gunLine = GetComponent <LineRenderer> ();
        gunAudio = GetComponent<AudioSource> ();
        gunLight = GetComponent<Light> ();
    }

    void Update ()
    {
        timer += Time.deltaTime;

        if(Input.GetButton ("Fire1") && timer >= timeBetweenBullets)
        {
            Shoot ();
        }

        if(timer >= timeBetweenBullets * effectsDisplayTime)
        {
            DisableEffects ();
        }
    }


    public void DisableEffects ()
    {
        gunLine.enabled = false;
        gunLight.enabled = false;
    }


    void Shoot ()
    {
        timer = 0f;

        gunAudio.Play ();

        gunLight.enabled = true;

        gunParticles.Stop ();
        gunParticles.Play ();

        if (!string.IsNullOrEmpty(GetItemPowerUp()))
        {
            SetWeaponLine(GetItemPowerUp(), gunLine);
        }
        else
        {
            gunLine.material = normalgunLine;
            gunLight.color = Color.yellow;
        }

        gunLine.enabled = true;
        gunLine.SetPosition (0, transform.position);

        shootRay.origin = transform.position;
        shootRay.direction = transform.forward;

        if(Physics.Raycast (shootRay, out shootHit, range, shootableMask))
        {
            EnemyHealth enemyHealth = shootHit.collider.GetComponent <EnemyHealth> ();
            if(enemyHealth != null)
            {
                enemyHealth.TakeDamage (damagePerShot, shootHit.point);
            }
            
            gunLine.SetPosition (1, shootHit.point);
        }
        else
        {
            gunLine.SetPosition (1, shootRay.origin + shootRay.direction * range);
        }
    }

    string GetItemPowerUp()
    {
        if (powerupContainer != null)
        {
            if (powerupContainer.containerItems.Count > 0)
            {
                return powerupContainer.containerItems[0].itemName;
            }
        }

        return "";
    }

    void SetWeaponLine(string powerUpName, LineRenderer gunLine)
    {
        if (powerUpName == "Fire Shot")
        {
            gunLine.material = fireGunLine;
            gunLight.color = Color.red;
        }
        else if (powerUpName == "Ice Shot")
        {
            gunLine.material = iceGunLine;
            gunLight.color = Color.blue;
        }
    }
}
