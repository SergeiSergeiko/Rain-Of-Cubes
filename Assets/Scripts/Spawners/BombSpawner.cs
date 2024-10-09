public class BombSpawner : Spawner<Bomb>
{
    public void OwnerDiedHandler(Unit unit)
    {
        unit.Dies -= OwnerDiedHandler;
        Spawn(unit.transform.position);
    }

    protected override void Subscribe(Bomb bomb)
    {
        bomb.Dies += BombDiedHandler;
    }

    private void BombDiedHandler(Unit unit)
    {
        if (unit is Bomb bomb)
            Pool.Release(bomb);
    }
}
