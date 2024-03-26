﻿namespace BoardGameShop.Api.Entities
{
    public class Artist : Creator
    {
        [InverseProperty(nameof(BoardGame.Artists))]
        public List<BoardGame> BoardGames { get; set; } = new List<BoardGame>();
    }
}