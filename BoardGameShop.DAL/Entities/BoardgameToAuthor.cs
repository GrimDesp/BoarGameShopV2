using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameShop.DAL.Entities
{
    public class BoardgameToAuthor
    {
        public int BoardgameId { get; set; }
        [ForeignKey(nameof(BoardgameId))]
        public Boardgame BoardgameNavigation { get; set; } = new();
        public int AuthorId { get; set; }
        [ForeignKey(nameof(AuthorId))]
        public Author AuthorNavigation { get; set; } = new();
    }
}
