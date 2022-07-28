namespace Enemy
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

