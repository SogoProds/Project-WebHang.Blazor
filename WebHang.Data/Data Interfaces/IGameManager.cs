using System;
using System.Collections.Generic;
using System.Text;

namespace WebHang.Data.Data_Interfaces
{
    public interface IGameManager<Game>
    {
        Game Guess(char guess);
        Game Hint();
        void Score();
    }
}
