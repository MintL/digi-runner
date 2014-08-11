using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Netrunner.Subsystems;

namespace Netrunner.Core
{
    public class GameModel
    {
        private static GameModel instance;

        public IServer Server;

        private static int CORPORATION = 1;
        private static int RUNNER = 2;

        private static int LOCAL = 1;
        private static int REMOTE = 2;

        public static GameModel Instance 
        {
            get 
            {
                if (instance == null)
                    throw new NullReferenceException("GameModel is not instantiated");
                return instance; 
            }
        }

        #region Properties

        public int Round { get; private set; }
        public Corporation Corporation { get; private set; }
        public Runner Runner { get; private set; }


        public int StartingPlayer;

        #endregion

        public static void NewInstance(IServer server) {
            instance = new GameModel(server);
        }

        private GameModel(IServer server)
        {
            Round = 1;
            Corporation = new Corporation();
            Runner = new Runner();

            StartingPlayer = CORPORATION;

            this.Server = server;
        }

        public Player CurrentPlayer
        {
            get
            {
                if (StartingPlayer + (Round % 2) == CORPORATION) {
                    return Corporation;
                }
                else {
                    return Runner;
                }
            }
        }

        public Player LocalPlayer
        {
            get { return Corporation; }
        }

        public Player RemotePlayer
        {
            get { return Runner; }
        }



    }
}
