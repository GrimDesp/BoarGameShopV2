using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BoardGameShop.Web.Pages
{
    public partial class DisplayProducts : ComponentBase
    {
        [Parameter]
        public IEnumerable<ProductDto>? Products { get; set; }
        protected string FormatPlayTime(ProductDto game)
        {
            if (game.MinPlayTime == null)
            {
                return " - ";
            }
            if (game.MaxPlayTime == null)
            {
                return $"{game.MinPlayTime}+";
            }
            return $"{game.MinPlayTime} - {game.MaxPlayTime}";
        }
        protected string FormatPlayers(ProductDto game)
        {
            if (game.MinPlayer == null)
            {
                return " - ";
            }
            if (game.MaxPlayer == null)
            {
                return $"{game.MinPlayer}+";
            }
            return $"{game.MinPlayer} - {game.MaxPlayer}";
        }
        protected string FormatAge(ProductDto game)
        {
            if (game.Age == null)
            {
                return " - ";
            }
            return $"{(byte)game.Age.Value}+";
        }
    }
}
