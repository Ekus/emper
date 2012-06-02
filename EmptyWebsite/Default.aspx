<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="EmptyWebsite.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">

    <script src="Scripts/jquery-1.6.4.min.js" type="text/javascript"></script>
    <script src="Scripts/jquery.signalR-0.5.0.min.js" type="text/javascript"></script>
    <script src="signalr/hubs" type="text/javascript"></script> <!-- this is dynamically generated resource with proxy definitions for server-defined hubs -->
    <%--<script src="Scripts/hubs.js" type="text/javascript"></script>--%> a snapshot of the generated 
   <script type="text/javascript">
       $(function () {
           var connection = $.connection("chat");
           var myHub = $.connection.chat;
           $.connection.hub.start();

//           myHub.received(function (data) {
//               $('#messages').append('<li>myHub: ' + data + '</li>');
//           });

           connection.received(function (data) {
               $('#messages').append('<li>' + data + '</li>');
           });

           connection.start();

           $("#broadcast").click(function () {
               connection.send($('#msg').val());
               myHub.playAlbum($('#msg').val());
           });
       });
    </script>

    <input id="msg" />
    <input id="broadcast" type="button" />
    <ul id="messages"></ul>

    </form>
</body>
</html>
