using UnityEngine;
using UnityEngine.Serialization;

namespace GameScripts.PlayerScripts
{
    public class ShurikenLogic : MonoBehaviour
    {
    
        [FormerlySerializedAs("speed")] [SerializeField] private float rotateSpeed = 45f;
        // Update is called once per frame
        void FixedUpdate()
        {
            // Rotate the shuriken
            transform.Rotate(new Vector3(0, 0, rotateSpeed) * Time.deltaTime);
        }
    
    

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Enemy")) other.gameObject.GetComponent<EnemyStatus>().TakeDamage(4f);
            Destroy(gameObject);
        }
    }
}
