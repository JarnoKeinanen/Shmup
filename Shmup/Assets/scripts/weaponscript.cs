using UnityEngine;
using System.Collections;
/// <summary>
/// Launch Projectile
/// </summary>
public class weaponscript : MonoBehaviour
{
    //--------------------------------
    // 1 - Designer variables
    //--------------------------------
    public Transform shotPrefab;

    /// <summary>
    /// Cooldown in seconds between two shots
    /// </summary>
    public float shootingrate = 0.25f;

    //--------------------------------
    // 2 - Cooldown
    //--------------------------------

    private float shotcooldown;

    void Start()
    {
        shotcooldown = 0f;
    }

    void Update()
    {
        if (shotcooldown > 0)
        {
            shotcooldown -= Time.deltaTime;
        }

    }
    //--------------------------------
    // 3 - Shooting from another script
    //--------------------------------

    /// <summary>
    /// Create a new projectile if possible
    /// </summary>
    public void Attack(bool isEnemy)
    {
        if (CanAttack)
        {
            shotcooldown = shootingrate;

            // Create a new shot
            var shotTransform = Instantiate(shotPrefab) as Transform;

            //assign position
            shotTransform.position = transform.position;

            // The is enemy property
            shotscript shot = shotTransform.gameObject.GetComponent<shotscript>();
            if (shot != null)
            {
                shot.isEnemyShot = isEnemy;
            }

            // Make the weapon always shoot towards it
            movescript move = shotTransform.gameObject.GetComponent<movescript>();
            if (move != null)
            {
                move.direction = this.transform.right; // towards in 2D space is the right of the sprite
            }
        }
    }
    /// <summary>
    /// Is the weapon ready to create a new projectile?
    /// </summary>
    public bool CanAttack
    {
        get
        {
            return shotcooldown <= 05;
        }
    }
}
