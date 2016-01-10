<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="dodajanje_novic.aspx.cs" Inherits="Projekt.dodajanje_novic" %>

<!DOCTYPE html>
<!-- Website template by freewebsitetemplates.com -->
<html>
<head>
	<meta charset="UTF-8">
	<title>Dive Sites - Bhaccasyoniztas Beach Resort Website Template</title>
	<link rel="stylesheet" href="css/style.css" type="text/css">
    <style type="text/css">
        #form1 {
            height: 172px;
            width: 766px;
        }
    </style>
</head>
<body>
	<div id="background">
		<div id="page">
			<div id="header">
				<div id="logo">
					<a href="index.aspx"><img src="images/logo.png" alt="LOGO" height="112" width="118"></a>
				</div>
				<div id="navigation">
					<ul>
						<li>
							<a href="prijavljen.aspx">Home</a>
						</li>
						<li  >
							
                            <a href="about.aspx">About</a>
						</li>
						<li>
							<a href="settings.aspx">Nastavitve</a>
						</li>
						<li>
                            <a href="user_info.aspx">User info</a>
						</li>
						<li>
							<a href="upload.aspx">Galerija</a>
						</li>
						<li  class="selected">
							<a href="dodajanje_novic.aspx">News</a>
						</li>
						<li>
							<a href="kontakti.aspx">Contact</a>
						</li>
					</ul>
				</div>
			</div>
			<div id="contents">
				<div class="box">
					<div>
						<div class="body">
                            	<h1>NASTAVITVE</h1>


                            <form runat="server">
                                <asp:Button ID="Button1" runat="server" Text="Prikaži moje datoteke!" OnClick="Button1_Click" BackColor="#FFFF99" BorderStyle="Groove" />
                                
                                <asp:ListView ID="ListView1" runat="server">
                                <itemTemplate>
                                    <div class="list">
                                        <table>
                                            <tr><td><h3><%#Eval ("ime") %></h3></td><td><img src="<%#Eval ("komentar") %>" height="100" width="150"/></td></tr>
                                        </table>
                                    </div>
                                </itemTemplate>
                                    </asp:ListView>
                            </form>

						</div>
					</div>
				</div>
			</div>
		</div>
		<div id="footer">
			<div>
				<ul class="navigation">
					<li>
						<a href="index.aspx">Home	</a></li>
					<li>
						<a href="about.aspx">About</a>
					</li>
					<li>
						<a href="rooms.aspx">Rooms</a>
					</li>
					<li class="active">
						<a href="dives.aspx">Dive Site</a>
					</li>
					<li>
						<a href="foods.aspx">Food</a>
					</li>
					<li>
						<a href="news.aspx">News</a>
					</li>
					<li>
						<a href="contact.aspx">Contact</a>
					</li>
				</ul>
				<div id="connect">
					<a href="http://pinterest.com/fwtemplates/" target="_blank" class="pinterest"></a> <a href="http://freewebsitetemplates.com/go/facebook/" target="_blank" class="facebook"></a> <a href="http://freewebsitetemplates.com/go/twitter/" target="_blank" class="twitter"></a> <a href="http://freewebsitetemplates.com/go/googleplus/" target="_blank" class="googleplus"></a>
				</div>
			</div>
			<p>
				© 2023 by BHACCASYONIZTAS BEACH RESORT. All Rights Reserved
			</p>
		</div>
	</div>
</body>
</html>