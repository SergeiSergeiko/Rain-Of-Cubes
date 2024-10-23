public class BombSpawner : GenericSpawner<Bomb>
{
    public void OnEventCubeDied(Unit unit)
    {
        unit.Died -= OnEventCubeDied;
        Spawn(unit.transform.position);
    }

    protected override void Subscribe(Bomb bomb)
    {
        bomb.Died += OnEventBombDied;
    }

    private void OnEventBombDied(Unit unit)
    {
        if (unit is Bomb bomb)
        {
            bomb.Died -= OnEventBombDied;
            Pool.Release(bomb);
        }
    }
}
