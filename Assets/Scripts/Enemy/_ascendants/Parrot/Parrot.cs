namespace Scripts.Enemy.Parrot
{
    public class Parrot : Enemy
    {
        private void Update()
        {
            Movement.MoveX();
            Movement.MoveY();
        }
    }
}