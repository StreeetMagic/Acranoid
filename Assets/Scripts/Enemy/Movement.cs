using UnityEngine;

namespace Enemy
{
    //[RequireComponent(typeof(MoveSpeedUpgrader))]
    public class Movement : MonoBehaviour
    {
        [SerializeField] private MoveSpeedUpgrader _moveSpeedUpgrader;
        
        [field: Header("Borders & direction flags:")]
        [field: SerializeField] private int YBorder { get; set; } = 4;
        [field: SerializeField] private int XBorder { get; set; } = 6;
        [field: SerializeField] private bool GoesTop { get; set; } = true;
        [field: SerializeField] private bool GoesLeft { get; set; } = true;

        [field: Header("Move speed values:")]
        [field: SerializeField] private float DefaultXMoveSpeed { get; set; } = 3;
        [field: SerializeField] private float DefaultYMoveSpeed { get; set; } = 2;
        [field: SerializeField] private float CurrentXMoveSpeed { get; set; }
        [field: SerializeField] private float CurrentYMoveSpeed { get; set; }


        private void OnEnable()
        {
            _moveSpeedUpgrader = GetComponent<MoveSpeedUpgrader>(); 
            CurrentXMoveSpeed = DefaultXMoveSpeed * _moveSpeedUpgrader.CurrentMultilier;
            CurrentYMoveSpeed = DefaultYMoveSpeed * _moveSpeedUpgrader.CurrentMultilier;
        }

        public void MoveLeft()
        {
            transform.position -= new Vector3(CurrentXMoveSpeed * Time.deltaTime, 0, 0);
        }

        public void MoveRight()
        {
            transform.position += new Vector3(CurrentXMoveSpeed * Time.deltaTime, 0, 0);
        }

        public void MoveDown()
        {
            transform.position -= new Vector3(0, CurrentYMoveSpeed * Time.deltaTime, 0);
        }

        public void MoveTop()
        {
            transform.position += new Vector3(0, CurrentYMoveSpeed * Time.deltaTime, 0);
        }

        public void MoveY()
        {
            if (GoesTop)
            {
                MoveTop();

                if (transform.position.y >= YBorder)
                    GoesTop = false;
            }
            else
            {
                MoveDown();

                if (transform.position.y <= -YBorder)
                    GoesTop = true;
            }
        }

        public void MoveX()
        {
            if (GoesLeft)
            {
                MoveLeft();

                if (transform.position.x <= -XBorder)
                    GoesLeft = false;
            }
            else
            {
                MoveRight();

                if (transform.position.x >= XBorder)
                    GoesLeft = true;
            }
        }
    }
}

