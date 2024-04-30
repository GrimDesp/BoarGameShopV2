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
        [ForeignKey(nameof(BoardgameId)), Required]
        public Boardgame? BoardgameNavigation { get; set; }
        public int AuthorId { get; set; }
        [ForeignKey(nameof(AuthorId)), Required]
        public Author? AuthorNavigation { get; set; }
    }
}
