using System;
using UnityEngine;

public abstract class Buff : MonoBehaviour
{
   
    private Transform _activeContainer;

    [field: SerializeField] public float MoveSpeed { get; protected set; } = -.5f;
    public float Score => 5;

    private void Update()
    {
        transform.Translate(new Vector3(MoveSpeed * Time.deltaTime, 0, 0));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player.Player>(out Player.Player player))
        {
            Upgrade(player);
            player.GainScore(Score);
            gameObject.SetActive(false);
        }
    }

    protected abstract void Upgrade(Player.Player player);

    public void SetActiveContainer(Transform container)
    {
        _activeContainer = container;
        transform.SetParent(_activeContainer);
    }
}
