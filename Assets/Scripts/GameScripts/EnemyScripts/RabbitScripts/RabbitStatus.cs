namespace GameScripts.EnemyScripts.RabbitScripts
{
    public class RabbitStatus: EnemyStatus
    {
        private void Start()
        {
            base.Start();
            enemyHealth = 20f;
        }
    }
}