public class BombSpawner : GenericSpawner<Bomb>
{
    public void Spawn(Unit unit)
    {
        unit.Died -= Spawn;
        Spawn(unit.transform.position);
    }

    protected override void Subscribe(Bomb bomb)
    {
        bomb.Died += Release;
    }

    private void Release(Unit unit)
    {
        if (unit is Bomb bomb)
        {
            bomb.Died -= Release;
            Pool.Release(bomb);
        }
    }
}
