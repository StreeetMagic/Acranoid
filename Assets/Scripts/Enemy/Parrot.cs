namespace Enemy
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

