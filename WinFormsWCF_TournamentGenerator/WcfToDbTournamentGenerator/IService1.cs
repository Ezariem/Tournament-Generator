using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfToDbTournamentGenerator
{
    [ServiceContract]
    public interface IService1
    {
        
        // service operations 

        [OperationContract]
        int CreatePlayer(Player player);

        [OperationContract]
        int UpdatePlayer(Player player);

        [OperationContract]
        int DeletePlayer(Player player);

        [OperationContract]
        Player GetPlayer(Player player);

        [OperationContract]
        List<Player> GetAllPlayers();
    }

   
}
