namespace Scripts.Buff.HealthBuff
{
    public class HealthBuff : Buff
    {
        protected override void Upgrade(Player.Player player)
        {
            player.GainHealth();
        }
    }
}