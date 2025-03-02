namespace SampleGame
{
    public class Trap : DamageMaker
    {
        private void OnEnable() => OnMakeDamage += OnMakeDamageHandler;

        private void OnDisable() => OnMakeDamage -= OnMakeDamageHandler;

        private void OnMakeDamageHandler() => Destroy(gameObject);
    }
}