namespace Enemy
{
    public class Crow : Enemy
    {
        private void Update()
        {
            Movement.StrafeY();

            if (transform.position.x - XPosition > 0.1)
                Movement.MoveLeft();
        }
    }
}

