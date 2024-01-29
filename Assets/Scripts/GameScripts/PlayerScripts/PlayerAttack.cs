using UnityEngine;

namespace GameScripts.PlayerScripts
{
    public class PlayerAttack : MonoBehaviour
    {
        private float attackCooldown = 0.5f;
        [SerializeField] private GameObject shurikenPrefab;
        [SerializeField] private Transform shurikenSpawnPoint;
        [SerializeField] private float shurikenSpeed = 1000f;
        // Update is called once per frame
        void Update()
        {
            if(attackCooldown > 0)
            {
                attackCooldown -= Time.fixedDeltaTime;
            }
            else if (Input.GetButtonDown("Fire1"))
            {
                attackCooldown = 0.5f;
                Attack();
            }
        }
    
        private void Attack()
        {
            GameObject shuriken = Instantiate(shurikenPrefab, shurikenSpawnPoint.position, Quaternion.identity);
            // add speed to the shuriken in the direction the player is facing
            shuriken.GetComponent<Rigidbody2D>().AddForce(new Vector2(transform.localScale.x * shurikenSpeed, 0));
        }
    }
}
