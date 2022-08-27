using System.Collections;
using UnityEngine;
using UnityEngine.Audio;

public class Gun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 70f;
    public float fireRate = 9f;
    public float impactForce = 100f;

    public int maxAmmo = 30;
    public int currentAmmo;
    public float reloadTime = 1.5f;
    private bool isReloading = false;


    public Camera fpsCam;
    public GameObject soundEffect;
    public GameObject SoundReload;
    public ParticleSystem muzzleFlash;

    private float nextTimeToFire = 0f;

    public Animator animator;

    public Recoil Recoil_Script;

    [SerializeField] private PlayerHUD hud;



    public void Start()
    {

        Recoil Recoil_Script = GetComponent<Recoil>();
        currentAmmo = maxAmmo;
    }


    void Update()
    {

        hud.UpdateAmmo(currentAmmo);

        if (isReloading)
            return;

        if (Input.GetKeyDown(KeyCode.R) && currentAmmo < maxAmmo && !PauseMenu.GameIsPaused || currentAmmo <= 0  && !PauseMenu.GameIsPaused)
        {
            GameObject ReloadGO = Instantiate(SoundReload);
            ReloadGO.GetComponent<AudioSource>().Play();
            Destroy(ReloadGO, 2f);
            StartCoroutine(Reload());
            return;
        }


        if(Input.GetButton("Fire1") && Time.time >= nextTimeToFire && !PauseMenu.GameIsPaused)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }
    }



    IEnumerator Reload ()
    {
        isReloading = true;

        Debug.Log("Reloading...");

        animator.SetBool("Reloading", true);

        yield return new WaitForSeconds(reloadTime - .375f);
        animator.SetBool("Reloading", false);
        yield return new WaitForSeconds(.375f);

        currentAmmo = maxAmmo;

        isReloading = false;
    }




    void Shoot()
    {

        muzzleFlash.Play();

        currentAmmo--;


        GameObject audioGO = Instantiate(soundEffect);
        audioGO.GetComponent<AudioSource>().Play();
        Destroy(audioGO, 1.7f);

        Recoil_Script.RecoilFire();

        RaycastHit hit;

        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                if (target.spawnScript != null)
                {
                    target.spawnScript.scoreScript.resetScore();
                    target.spawnScript.scoreScript.UpdateScore(target.spawnScript.scoreScript.Score);
                    target.spawnScript.spawning = true;
                    return;
                }



                target.takeDamage(damage);

            }

            if (hit.rigidbody != null)
            {

                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }

            
        }
    }
}
