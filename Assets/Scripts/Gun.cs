using UnityEngine;
using System.Collections;
public class Gun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public float fireRate = 15f;
    public float impactForce = 60f;

    public int maxAmmo = 10;
    private int currentAmmo;
    public float reloadTime = 1f;
    private bool isReloading = false;

    public Camera fpsCam;
    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;

    public Animator animator;
    
    private float nextTimeToFire = 0f;

    void Start()
    {
        currentAmmo = maxAmmo;

        animator = GetComponent<Animator>();
        isReloading = false;
        animator.SetBool("Reload", false);
    }



    void Update()
    {

        if (isReloading)
            return;
        
        if (currentAmmo <= 0)
        {
            print("NO BULLETS");
            StartCoroutine(Reload());
            return; //This makes the code stop here and NOT fire the next bullet
        }
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }
        else
        {
            if (GetComponent<Animator>())
            GetComponent<Animator>().SetBool("Recoil", false);

        }

    }
   
    IEnumerator Reload()
    {
        isReloading = true;
        Debug.Log("Reloading...");
        animator.SetBool("Recoil", false);

        animator.SetBool("Reload", true);
        
        yield return new WaitForSeconds(reloadTime - .25f);
        animator.SetBool("Reload", false);
        yield return new WaitForSeconds(reloadTime - .25f);
        
        currentAmmo = maxAmmo;
        isReloading = false;
    }
    void Shoot()
    {

        muzzleFlash.Play();

        currentAmmo--;
        
        
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {

            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }
                
            if(hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }

               
            GameObject impactGo = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGo, 0.2f);
        }
        GetComponent<Animator>().SetBool("Recoil", true);
        GetComponent<AudioSource>().Play();

    }

}

