using UnityEngine;

namespace GameScripts.PlayerScripts
{
    public class PlayerStatus : MonoBehaviour
    {
        [SerializeField] private float playerHealth = 100f;
    
        private Animator animator;
        private bool isDead = false;
        private Rigidbody2D rb;

        private GameObject manager;
        private bool invulnerable = false;

        private static readonly int HitTrig = Animator.StringToHash("hit_trig");
        private static readonly int DeathTrig = Animator.StringToHash("death_trig");

        // Start is called before the first frame update
        void Start()
        {
            animator = gameObject.GetComponent<Animator>();
            rb = gameObject.GetComponent<Rigidbody2D>();
            manager = GameObject.FindGameObjectWithTag("GameController");
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            if (gameObject.transform.position.y < -5)
            {
                KillPlayer();
            }
        }

        public void KillPlayer()
        {
            if(isDead) return; 
            animator.SetTrigger(DeathTrig);
        
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            isDead = true;
            manager.GetComponent<GameManager>().GameOver();

            //Invoke("DestroyPlayerObject", 0.2f);
        }
    
        public void DestroyPlayerObject()
        {
            Destroy(gameObject);
        }

        public void TakeDamage(float damage)
        {
            if (invulnerable) return;

            invulnerable = true;
            playerHealth -= damage;
            if (playerHealth <= 0)
            {
                KillPlayer();
                return;
            }
            animator.SetTrigger(HitTrig);
            
            Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("Enemy"), true);
            Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("EnemyAttack"), true);

        }
    
        public bool IsDead()
        {
            return isDead;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
                TakeDamage(other.gameObject.GetComponent<EnemyStatus>().GetDamage());
            }
        }
    
        public void SetVulnerable()
        {
            invulnerable = false;
            Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("Enemy"), false);
            Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("EnemyAttack"), false);
        }
    }
}
