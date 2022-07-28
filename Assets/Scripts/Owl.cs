namespace Enemy
{
    public class Owl : Enemy
    {
        private void Update()
        {
            Movement.StrafeY();
            Movement.MoveLeft();
        }
    }
}

