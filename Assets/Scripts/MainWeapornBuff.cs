public class MainWeapornBuff : Buff
{
    protected override void Upgrade(Player.Player player)
    {
        player.UpgradeMainWeapon();
    }
}
