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

    private float timer;



	void Start () 
	{
		
	}
	
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
        Debug.DrawRay(firePoint.position, firePoint.forward * 100, Color.red, 1);

        Ray ray = new Ray(firePoint.position, firePoint.forward);

        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo, 100))
        {
            var health = hitInfo.collider.GetComponent<Health>();

            if(health)
                health.TakeDamage(damage);
        }
    }
}
