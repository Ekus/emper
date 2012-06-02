using System;
using System.Threading;
using System.Threading.Tasks;
using SignalR.Hubs;

namespace EmptyWebsite
{
    public class Chat : Hub, IMediaPlayer
    {
        //public void Join(string myName)
        //{
        //    if (Clients.Where(x => x.Name.Equals(myName)).Count().Equals(0))
        //    {
        //        Clients.Add(new Client() { Name = myName, LastResponse=DateTime.Now });
        //        SendMessageServer(string.Format("{0} entered the chat", myName));
        //        GetClients();
        //        Caller.Naam = myName;
        //    }
        //    else
        //        throw new Exception("This login is allready in use");
        //}

        //public void Send(string message)
        //{
        //    // Call the addMessage method on all clients
        //    Clients
        //    Clients.addMessage(message);
        //}

        public Task MediaPlayerRegister()
        {
            return Groups.Add(Context.ConnectionId, "MediaPlayer");
        }

        //public Task Send(string message)
        //{
        //    return Clients["foo"].addMessage(message);
        //}

        public Task Disconnect()
        {
            return Groups.Remove(Context.ConnectionId, "MediaPlayer");
        }

        public Album[] GetAlbums()
        {
            throw new NotImplementedException();
        }

        public void PlayAlbum(string albumTitle)
        {
            Clients.PlayAlbum(albumTitle); //["MediaPlayer"]
        }

        public void PlaySong(string albumTitle, string songTitle)
        {
            throw new NotImplementedException();
        }

        void IMediaPlayer.Play()
        {
            throw new NotImplementedException();
        }

        public void Pause()
        {
            throw new NotImplementedException();
        }

        public PlayerState GetState()
        {
            throw new NotImplementedException();
        }
    }
}