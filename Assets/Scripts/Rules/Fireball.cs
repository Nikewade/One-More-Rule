using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    RuleController rules;
    CollectiblesTotal total;
    CharacterController controller;
    bool isCrouching;
    bool canShoot = true;
    Transform bulletPosition;
    Vector2 crouchingSize;
    [SerializeField] AudioClip shootSound;
    [SerializeField] AudioSource shootSource;
    [SerializeField] Rigidbody2D bullet;
    [SerializeField] GameObject particles;
    public bool onFire = false;
    GameObject sceneController;
    int burning = 0;
    public int burnSeconds;
    // Start is called before the first frame update
    void Start()
    {
        rules = GetComponentInParent<RuleController>();
        total = GameObject.Find("SceneController").GetComponent<CollectiblesTotal>();
        controller = GetComponentInParent<CharacterController>();
        sceneController = GameObject.Find("SceneController");
        controller.canShoot = false;
        bulletPosition = controller.bulletPosition;
        crouchingSize = controller.crouchingSize;
    }

    // Update is called once per frame
    void Update()
    {
        isCrouching = controller.isCrouching;
        Shoot();

        if(onFire)
            particles.SetActive(true);
        else
            particles.SetActive(false);
    }

    private void FixedUpdate()
    {
        if (burning >= burnSeconds * 50)
        {
            sceneController.GetComponent<InitializeRules>().Death();
        }
        if (onFire)
        {
            burning++;
        }
        else
        {
            burning = 0;
        }
    }

    public void setOnFire()
    {
        onFire = true;
    }

    void Shoot()
    {
        if (Input.GetKey(KeyCode.LeftShift) && canShoot || Input.GetKey(KeyCode.RightShift) && canShoot)
        {
            Vector3 newBulletPosition = bulletPosition.position;
            if (isCrouching)
            {
                newBulletPosition.y -= 0.7f;
            }
            canShoot = false;
            var firedBullet = Instantiate(bullet, newBulletPosition, bulletPosition.rotation);
            firedBullet.AddForce(bulletPosition.right * (controller.bulletSpeed - 500));
            shootSource.PlayOneShot(shootSound);
            StartCoroutine("ShootRate");

            setOnFire();
        }
    }

    IEnumerator ShootRate()
    {
        yield return new WaitForSeconds(controller.shootRate);
        canShoot = true;
    }
}
