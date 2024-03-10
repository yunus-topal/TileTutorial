namespace GameScripts.EnemyScripts.RabbitScripts
{
    public class RabbitStatus: EnemyStatus
    {
        private new void Start()
        {
            base.Start();
            enemyHealth = 20f;
        }
    }
}