namespace GamePlay
{
    public class Score
    {
        public Score(int inPosition, int inCode)
        {
            this.inPosition = inPosition;
            this.inCode = inCode;
        }

        private int inCode;
        public int inPosition { get; set; }

        public override bool Equals(object o)
        {
            if (typeof(Score).IsInstanceOfType(o)) {
                Score score = (Score)o;
                return score.inPosition == inPosition && score.inCode == inCode;
            }

            return false;
        }
    }
}