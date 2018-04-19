using UnityEngine;
using UnityEngine.Experimental.Rendering;

/// <summary>
/// Controls Firing
/// Ruben Sanchez
/// 
/// </summary>

public class Gun : MonoBehaviour
{
    [SerializeField]
    private int fireRate; //shots per sec

    [SerializeField]
    private int damage;

    [SerializeField]
    private Transform firePoint;

    [SerializeField]
    private Transform aimPoint;

    [SerializeField]
    private AudioSource audioSource;

    [SerializeField]
    private ParticleSystem muzzleParticle;

    private float timer;
	
	void Update ()
	{
	    timer += Time.deltaTime;

	    if (timer >= (1f / fireRate))
	    {
	        if (Input.GetButton("Fire1"))
	        {
	            timer = 0;
	            Fire();
	        }
	    }
	}

    private void Fire()
    {
        Debug.DrawRay(firePoint.position, aimPoint.forward * 100, Color.red, 1);

        audioSource.PlayOneShot(audioSource.clip);
        muzzleParticle.Play();

        Ray ray = new Ray(firePoint.position, aimPoint.forward);

        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo, 100))
        {
            var health = hitInfo.collider.GetComponent<Health>();

            if(health)
                health.TakeDamage(damage);
        }
    }
}
