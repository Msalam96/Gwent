namespace GwentSharedLibrary.Models
{
    public class BoardCardState
    {
        public int PileCardId { get; set; }
        public string ImageUrl { get; set; }

        public void SetScore (int score)
        {
            Score = score;
        }

        public int getScore()
        {
            return Score;
        }
        //public void ScoreSum(int score) {
        //    Score += score;
        //}

        private int Score { get; set; }
    }
}