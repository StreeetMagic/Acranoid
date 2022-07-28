namespace Enemy
{
    public class Sparrow : Enemy
    {
        private void Update()
        {
            Movement.StrafeX();
            Movement.StrafeY();
        }
    }
}

