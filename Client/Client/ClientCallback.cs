using Client.GameServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    [CallbackBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class ClientCallback : IServiceCallback
    {
        
        internal Action<bool> startGame;
        internal Action InvitationDenied;
        internal Action<string> ReceivedInvitation;
        internal Action<string,bool> AddMove;
        internal Action<bool> OnOffCan;
        internal Action EndLostGame;
        internal Action EndDrawGame;
        internal Action callbackEndGameOtherPlayerQuit;
        

        public void AddMoveToYourBoard(string col)
        {
            AddMove(col, false);
        }

        public void Draw()
        {
            EndDrawGame();
        }

        public void PlayerQuit()
        {
            callbackEndGameOtherPlayerQuit();
        }

        public void ReceivedNewInvitation(string from)
        {
            ReceivedInvitation(from);
        }

       

        

        public void Turn(bool flag)
        {
            OnOffCan(flag);
        }

        public void YouLost()
        {
            EndLostGame();
        }

        public void YourInvitationReturn(bool YN)
        {
            if (YN)
                startGame(true);
            else
                InvitationDenied();
        }
    }
}
