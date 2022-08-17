namespace Scripts.Enemy.Sparrow
{
    public class Sparrow : Enemy
    {
        private void Update()
        {
            Movement.MoveX();
            Movement.MoveY();
        }
    }
}