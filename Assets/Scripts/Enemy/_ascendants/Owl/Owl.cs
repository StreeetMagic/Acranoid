namespace Scripts.Enemy.Owl
{
    public class Owl : Enemy
    {
        private void Update()
        {
            Movement.MoveY();
            Movement.MoveLeft();
        }
    }
}