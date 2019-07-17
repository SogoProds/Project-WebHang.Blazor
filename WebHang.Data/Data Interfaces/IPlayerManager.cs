using System;
using System.Collections.Generic;
using System.Text;

namespace WebHang.Data.Data_Interfaces
{
    public interface IPlayerManager<Player>
    {
        IEnumerable<Player> GetAll();
        Player GetById(int id);
        void Add(Player player);
        void Update(Player playerToUpdate, Player player);
        void Delete(Player player);
    }
}
