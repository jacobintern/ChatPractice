﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace BegoniaChat.Hubs
{
    public class ChatHub : Hub
    {
        public static class UserHandler
        {
            public static Dictionary<string, string> ConnectedIds = new Dictionary<string, string>();
        }

        public void UserConnected(string name)
        {
            string message = " 歡迎使用者 " + name + " 加入聊天室 ";
            // 發送訊息給除了自己的其他使用者
            Clients.Others.addList(Context.ConnectionId, name);
            Clients.Others.hello(message);
            // 發送訊息至自己，並且取得上線清單
            Clients.Caller.getList(UserHandler.ConnectedIds.Select(p => new { id = p.Key, name = p.Value }));
            // 新增目前使用者至上線清單
            UserHandler.ConnectedIds.Add(Context.ConnectionId, name);
        }

        // 發送訊息給所有人
        public void SendAllMessage(string message)
        {
            //Clients.All.addNewMessageToPage(name, message);
            message = HttpUtility.HtmlEncode(message);
            var name = UserHandler.ConnectedIds.Where(p => p.Key == Context.ConnectionId).FirstOrDefault().Value;
            string msg = name + " Say:" + message;
            Clients.All.sendAllMessage(msg);
        }

        public void SendMessage(string toId, string message)
        {
            var fromName = UserHandler.ConnectedIds.Where(p => p.Key == Context.ConnectionId).FirstOrDefault().Value;
            var toName = UserHandler.ConnectedIds.Where(p => p.Key == toId).FirstOrDefault().Value;
            var fromId = UserHandler.ConnectedIds.Where(p => p.Key == Context.ConnectionId).FirstOrDefault().Key;
            string toMsg = " <span style='color:red'> This is secret message from " + fromName + " </span> ： " + message;
            string fromMsg = " <span style='color:red'> You says to " + toName + " </span> ：" + message;
            Clients.Client(toId).sendMessage(toMsg);
            Clients.Client(fromId).sendMessage(fromMsg);
        }

        public override System.Threading.Tasks.Task OnDisconnected(bool stopCalled)
        {
            // 當使用者離開時，移除在清單內的 ConnectionId
            Clients.All.removeList(Context.ConnectionId);
            UserHandler.ConnectedIds.Remove(Context.ConnectionId);
            return base.OnDisconnected(stopCalled);
        }
    }
}