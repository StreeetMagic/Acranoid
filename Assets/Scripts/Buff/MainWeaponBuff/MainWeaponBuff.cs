namespace Scripts.Buff.MainWeaponBuff
{
    public class MainWeaponBuff : Buff
    {
        protected override void Upgrade(Player.Player player)
        {
            player.UpgradeMainWeapon();
        }
    }
}