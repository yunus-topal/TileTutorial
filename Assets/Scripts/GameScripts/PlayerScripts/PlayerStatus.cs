using UnityEngine;

namespace GameScripts.PlayerScripts
{
    public class PlayerStatus : MonoBehaviour
    {
        [SerializeField] private float playerHealth = 100f;
        [SerializeField] private float pushbackForce = 10f;
        
        private Animator animator;
        private bool isDead = false;
        private Rigidbody2D rb;

        private GameObject manager; 
        //private bool invulnerable = false;

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
            //if (invulnerable) return;

            //invulnerable = true;
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
                // clear other forces and velocity before pushback
                gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                gameObject.GetComponent<Rigidbody2D>().angularVelocity = 0f;
                
                Vector2 pushbackDirection = (transform.position - other.transform.position).normalized;
                gameObject.GetComponent<Rigidbody2D>().AddForce(pushbackDirection * pushbackForce, ForceMode2D.Impulse);

                TakeDamage(other.gameObject.GetComponent<EnemyStatus>().GetDamage());
            }
        }
    
        public void SetVulnerable()
        {
            //invulnerable = false;
            // if player still in an enemies collider, do not revert ignore collision
            if (Physics2D.OverlapCircle(transform.position, 0.1f, LayerMask.GetMask("Enemy")))
            {
                TakeDamage(40f);
                return;
            }
            Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("Enemy"), false);
            Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("EnemyAttack"), false);
        }
    }
}
