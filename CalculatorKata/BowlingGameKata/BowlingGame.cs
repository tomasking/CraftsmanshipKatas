namespace CraftsmanKata.BowlingGameKata
{
    public class BowlingGame
    {
        public int Calculate(string input)
        {
            var frames = input.Split('|');
            var totalScore = 0;
            bool hasHitSpare = false;
            int hasHitStrike = 0;

            foreach (var frame in frames)
            {
                if (frame.Length == 2)
                {
                    char secondScore = frame[1];
                    if (IsASpare(secondScore))
                    {
                        totalScore += 10;
                        hasHitSpare = true;
                        continue;
                    }

                    if (IsAHit(secondScore))
                    {
                        totalScore += GetScoreFromHit(secondScore);

                        if (hasHitStrike > 0)
                        {
                            totalScore += GetScoreFromHit(secondScore);
                            hasHitStrike--;
                        }
                    }
                }

                if (frame.Length > 0)
                {
                    char firstScore = frame[0];
                    if (IsAHit(firstScore))
                    {
                        totalScore += GetScoreFromHit(firstScore);

                        if (hasHitSpare)
                        {
                            totalScore += GetScoreFromHit(firstScore);
                        }

                        if (hasHitStrike > 0)
                        {
                            totalScore += GetScoreFromHit(firstScore);
                            hasHitStrike--;
                        }

                        if (IsAStrike(firstScore))
                        {
                            hasHitStrike = 2;
                        }
                    }
                }

                hasHitSpare = false;
            }

            return totalScore;
        }

        private static int GetScoreFromHit(char score)
        {
            if (score == 'X')
            {
                return 10;
            }

            return int.Parse(score.ToString());
        }

        private static bool IsAHit(char score)
        {
            return score != '-';
        }

        private static bool IsASpare(char score)
        {
            return score == '/';
        }

        private static bool IsAStrike(char score)
        {
            return score == 'X';
        }
    }
}