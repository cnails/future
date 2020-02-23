using Microsoft.AspNetCore.SignalR;
using System;
using System.Linq;
using System.Threading.Tasks;
using SignalR_Vuejs__Demo.Models;

namespace signalrChatApp
{
    public class ChatHub : Hub
    {


        public async Task SendMessage(string user, string leading, string message, string window, int ID ,string Edit)

        {

            SaveToDb(user, message, window, leading, ID);
            using (var context = new AppDbContext())
            {

                var hEdit = context.PredZapBD.Where(b => b.Id == ID).Select(b => b.EDIT);
                Edit = hEdit.ToList().First();
            }
            await Clients.All.SendAsync("ReceiveMessage", user, leading, message, window, ID, Edit);
        }




        [System.Diagnostics.CodeAnalysis.SuppressMessage("Globalization", "CA1305:������� IFormatProvider", Justification = "<��������>")]
        public void SaveToDb(string user, string message, string window, string leading, int ID)
        {
            using (var context = new AppDbContext())
            {
                var g = context.PredZapBD.SingleOrDefault(b => b.Id == ID);
                if (g != null)
                {
                    DateTime aDate = DateTime.Now;
                    string time = aDate.ToString("dd/MM/yyyy HH:mm:ss");

                    g.EDIT = g.EDIT + "\n<p> ��������� � [" + time + " ] � " + g.FIO + " " + g.LEADING + " �� " + user + " " + leading+"</p>" ;
                    g.FIO = user;
                    g.LEADING = leading;
                    context.SaveChanges();
                }


            }
        }
    }
}
