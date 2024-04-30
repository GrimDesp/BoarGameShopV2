namespace BoardGameShop.Web
{
    public static class CompareUtil
    {
        public static bool IsCollectionsEqual(this BoardgameActionDto game, BoardgameActionDto other)
            => game.Id == other.Id
            && game.TimeStamp == other.TimeStamp
            && game.Authors.SequenceEqual(other.Authors)
            && game.Artists.SequenceEqual(other.Artists)
            && game.Mechanics.SequenceEqual(other.Mechanics)
            && game.Categories.SequenceEqual(other.Categories);
    }
}
