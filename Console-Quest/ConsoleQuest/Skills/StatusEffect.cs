namespace ConsoleQuest.Skills
{
    public class StatusEffect
    {
        public StatusEffect(StatusEffects effect, int turns)
        {
            this.Effect = effect;
            this.TurnsRemaining = turns;
        }

        public StatusEffects Effect { get; private set; }

        public int TurnsRemaining { get; private set; }

        public void DecreaseRemainingTurns()
        {
            this.TurnsRemaining--;
        }
    }
}
