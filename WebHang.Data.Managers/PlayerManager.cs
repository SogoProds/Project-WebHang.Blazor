using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebHang.Data.Data_Interfaces;
using WebHang.Models;

namespace WebHang.Data.Managers
{
    public class PlayerManager : IPlayerManager<Player>
    {
        readonly DBContext dbContext;

        public PlayerManager(DBContext dBContext)
        {
            this.dbContext = dBContext;
        }

        public IEnumerable<Player> GetAll()
        {
            return dbContext.Players.ToList();
        }
        public Player GetById(int id)
        {
            return dbContext.Players.Find(id);
        }
        public void Add(Player player)
        {
            dbContext.Players.Add(player);
            dbContext.SaveChanges();
        }
        //Do I keep these???
        public void Update(Player playerToUpdate, Player player)
        {
            playerToUpdate.PlayerName = player.PlayerName;
            playerToUpdate.PlayerPassword = player.PlayerPassword;

            dbContext.SaveChanges();
        }
        public void Delete(Player player)
        {
            dbContext.Players.Remove(player);
            dbContext.SaveChanges();
        }
    }
}
