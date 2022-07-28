namespace Enemy
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

