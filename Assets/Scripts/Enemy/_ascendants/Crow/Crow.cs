namespace Scripts.Enemy.Crow
{
    public class Crow : Enemy
    {
        private void Update()
        {
            Movement.MoveY();

            if (transform.position.x - XPosition > 0.1)
                Movement.MoveLeft();
        }
    }
}