namespace Enemy
{
    public class Parrot : Enemy
    {
        private void Update()
        {
            Movement.StrafeX();
            Movement.StrafeY();
        }
    }
}

