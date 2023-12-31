USE [master]
GO
/****** Object:  Database [GamesData]    Script Date: 29/12/2023 6:06:00 PM ******/
CREATE DATABASE [GamesData]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'GamesData', FILENAME = N'D:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\GamesData.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'GamesData_log', FILENAME = N'D:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\GamesData_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [GamesData] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [GamesData].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [GamesData] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [GamesData] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [GamesData] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [GamesData] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [GamesData] SET ARITHABORT OFF 
GO
ALTER DATABASE [GamesData] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [GamesData] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [GamesData] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [GamesData] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [GamesData] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [GamesData] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [GamesData] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [GamesData] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [GamesData] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [GamesData] SET  DISABLE_BROKER 
GO
ALTER DATABASE [GamesData] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [GamesData] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [GamesData] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [GamesData] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [GamesData] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [GamesData] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [GamesData] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [GamesData] SET RECOVERY FULL 
GO
ALTER DATABASE [GamesData] SET  MULTI_USER 
GO
ALTER DATABASE [GamesData] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [GamesData] SET DB_CHAINING OFF 
GO
ALTER DATABASE [GamesData] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [GamesData] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [GamesData] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [GamesData] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'GamesData', N'ON'
GO
ALTER DATABASE [GamesData] SET QUERY_STORE = ON
GO
ALTER DATABASE [GamesData] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [GamesData]
GO
/****** Object:  Table [dbo].[Admins]    Script Date: 29/12/2023 6:06:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Admins](
	[admin_key] [int] IDENTITY(1,1) NOT NULL,
	[user_id] [int] NULL,
 CONSTRAINT [PK_Admins] PRIMARY KEY CLUSTERED 
(
	[admin_key] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Game_engines]    Script Date: 29/12/2023 6:06:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Game_engines](
	[game_engine_id] [int] IDENTITY(1,1) NOT NULL,
	[game_id] [int] NULL,
	[game_engine_name] [nvarchar](50) NULL,
	[game_engine_description] [nvarchar](2000) NULL,
 CONSTRAINT [PK_Game_engines] PRIMARY KEY CLUSTERED 
(
	[game_engine_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Game_stores]    Script Date: 29/12/2023 6:06:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Game_stores](
	[store_id] [int] IDENTITY(1,1) NOT NULL,
	[store_name] [nvarchar](50) NULL,
	[store_game_id] [int] NULL,
	[store_description] [nvarchar](1000) NULL,
 CONSTRAINT [PK_Game_stores] PRIMARY KEY CLUSTERED 
(
	[store_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Game_titles]    Script Date: 29/12/2023 6:06:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Game_titles](
	[game_id] [int] IDENTITY(1,1) NOT NULL,
	[game_name] [nvarchar](50) NULL,
	[description] [nvarchar](2000) NULL,
	[genre] [nchar](20) NULL,
	[platform] [nchar](10) NULL,
	[developer] [nchar](20) NULL,
	[release_date] [date] NULL,
	[ign_rate] [float] NULL,
 CONSTRAINT [PK_Game_titles] PRIMARY KEY CLUSTERED 
(
	[game_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[gaming_organization]    Script Date: 29/12/2023 6:06:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[gaming_organization](
	[org_id] [int] IDENTITY(1,1) NOT NULL,
	[org_name] [nvarchar](50) NULL,
	[org_establishment_date] [date] NULL,
	[org_team_name] [nvarchar](1000) NULL,
	[org_achievements] [nvarchar](1000) NULL,
 CONSTRAINT [PK_competitive_gaming_orgs] PRIMARY KEY CLUSTERED 
(
	[org_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Guest]    Script Date: 29/12/2023 6:06:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Guest](
	[guest_id] [int] IDENTITY(1,1) NOT NULL,
	[user_id] [int] NULL,
 CONSTRAINT [PK_Guest] PRIMARY KEY CLUSTERED 
(
	[guest_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Proplayers]    Script Date: 29/12/2023 6:06:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Proplayers](
	[player_id] [int] IDENTITY(1,1) NOT NULL,
	[player_name] [nvarchar](50) NULL,
	[player_nationality] [nvarchar](50) NULL,
	[player_team] [nvarchar](50) NULL,
	[player_achievements] [nvarchar](200) NULL,
	[player_team_id] [int] NULL,
 CONSTRAINT [PK_Proplayers] PRIMARY KEY CLUSTERED 
(
	[player_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Streamer_details]    Script Date: 29/12/2023 6:06:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Streamer_details](
	[streamer_id] [int] IDENTITY(1,1) NOT NULL,
	[streamer_name] [nvarchar](50) NULL,
	[twitch_rank] [int] NULL,
	[description] [nchar](2000) NULL,
	[most_streamed_game] [nchar](100) NULL,
	[number_of_followers] [int] NULL,
	[game_id] [int] NULL,
 CONSTRAINT [PK_Streamer_details] PRIMARY KEY CLUSTERED 
(
	[streamer_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Team]    Script Date: 29/12/2023 6:06:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Team](
	[team_id] [int] IDENTITY(1,1) NOT NULL,
	[team_name] [nvarchar](50) NULL,
 CONSTRAINT [PK_Team] PRIMARY KEY CLUSTERED 
(
	[team_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tournament_details]    Script Date: 29/12/2023 6:06:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tournament_details](
	[tournament_id] [int] IDENTITY(1,1) NOT NULL,
	[tournament_name] [nvarchar](50) NULL,
	[description] [nvarchar](2000) NULL,
	[tournament_game_id] [int] NULL,
	[tournament_game_name] [nvarchar](100) NULL,
 CONSTRAINT [PK_Tournament_details] PRIMARY KEY CLUSTERED 
(
	[tournament_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 29/12/2023 6:06:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[user_id] [int] IDENTITY(1,1) NOT NULL,
	[user_name] [nvarchar](50) NULL,
	[user_password] [nvarchar](50) NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[user_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Admins] ON 

INSERT [dbo].[Admins] ([admin_key], [user_id]) VALUES (1, 1)
INSERT [dbo].[Admins] ([admin_key], [user_id]) VALUES (2, 2)
SET IDENTITY_INSERT [dbo].[Admins] OFF
GO
SET IDENTITY_INSERT [dbo].[Game_engines] ON 

INSERT [dbo].[Game_engines] ([game_engine_id], [game_id], [game_engine_name], [game_engine_description]) VALUES (1, NULL, N'Unity', N'Unity is a versatile and widely-used game development engine that caters to both beginners and experienced developers. It supports the creation of 2D and 3D games, virtual reality (VR), and augmented reality (AR) applications. Unity offers a user-friendly interface, a vast asset store, and a strong community, making it a preferred choice for indie developers and large studios alike.')
INSERT [dbo].[Game_engines] ([game_engine_id], [game_id], [game_engine_name], [game_engine_description]) VALUES (2, NULL, N'Unreal Engine', N'Developed by Epic Games, Unreal Engine is known for its cutting-edge graphics and high-end capabilities. It is widely used for creating visually stunning and immersive 3D games. Unreal Engine provides a robust set of tools for artists, designers, and programmers. It''s popular in the gaming industry and extends its reach to other fields like film and simulation.')
SET IDENTITY_INSERT [dbo].[Game_engines] OFF
GO
SET IDENTITY_INSERT [dbo].[Game_stores] ON 

INSERT [dbo].[Game_stores] ([store_id], [store_name], [store_game_id], [store_description]) VALUES (1, N'Steam', 1, N'"Steam serves as a premier digital storefront for purchasing, downloading, and playing a vast array of online video games.Users can build and expand their digital game libraries, gaining instant access to purchased titles at any time.
"')
INSERT [dbo].[Game_stores] ([store_id], [store_name], [store_game_id], [store_description]) VALUES (2, N'Epic', 2, N'Epic Games Store is a digital marketplace where users can purchase, download, and play a variety of video games.The platform is known for securing exclusivity deals with certain game developers, offering exclusive titles that are only available on Epic Games Store.')
SET IDENTITY_INSERT [dbo].[Game_stores] OFF
GO
SET IDENTITY_INSERT [dbo].[Game_titles] ON 

INSERT [dbo].[Game_titles] ([game_id], [game_name], [description], [genre], [platform], [developer], [release_date], [ign_rate]) VALUES (1, N'Assasins Creed Mirage', N'Experience the story of Basim, a cunning street thief seeking answers and justice as he navigates the bustling streets of ninth-century Baghdad. Through a mysterious, ancient organization known as the Hidden Ones, he will become a deadly Master Assassin and change his fate in ways he never could have imagined.

    Experience a modern take on the iconic features and gameplay that have defined a franchise for 15 years.
    Parkour seamlessly through the city and stealthily take down targets with more visceral assassinations than ever before.
    Explore an incredibly dense and vibrant city whose inhabitants react to your every move, and uncover the secrets of four unique districts as you venture through the Golden Age of Baghdad.
    Uncover the Golden Age of Islam, marked by the flourishing of arts, sciences, and philosophy during the Abbasid Caliphate in Baghdad.
    Highlight the House of Wisdom, a renowned intellectual center that translated and preserved classical works from various cultures.', N'Action              ', N'All       ', N'Ubisoft             ', CAST(N'2023-10-05' AS Date), 8)
INSERT [dbo].[Game_titles] ([game_id], [game_name], [description], [genre], [platform], [developer], [release_date], [ign_rate]) VALUES (2, N'Death Stranding', N'From legendary game creator Hideo Kojima comes an all-new, genre-defying experience for PlayStation®4.

    Brave a world utterly transformed by the Death Stranding. Carry the disconnected remnants of our future and embark on a journey to reconnect the shattered world one step at a time.
    Sam Bridges must brave a world utterly transformed by the Death Stranding. Carrying the disconnected remnants of our future in his hands, he embarks on a journey to reconnect the shattered world one step at a time.
    Starring Norman Reedus, Mads Mikkelsen, Léa Seydoux and Lindsay Wagner.', N'Adventure           ', N'All       ', N'Kojima Productions  ', CAST(N'2019-11-07' AS Date), 9)
SET IDENTITY_INSERT [dbo].[Game_titles] OFF
GO
SET IDENTITY_INSERT [dbo].[gaming_organization] ON 

INSERT [dbo].[gaming_organization] ([org_id], [org_name], [org_establishment_date], [org_team_name], [org_achievements]) VALUES (1, N'Fnatic', CAST(N'2004-01-01' AS Date), N'League of Legends, Counter-Strike: Global Offensive (CS:GO), Dota 2', N'Fnatic has achieved success in various esports titles, including Counter-Strike: Global Offensive (CS:GO), League of Legends, and Dota 2. They have won multiple championships and are known for their consistent presence in competitive gaming.')
INSERT [dbo].[gaming_organization] ([org_id], [org_name], [org_establishment_date], [org_team_name], [org_achievements]) VALUES (2, N'Team Liquid', CAST(N'2000-05-10' AS Date), N'League of Legends, Counter-Strike: Global Offensive (CS:GO), Dota 2', N'Team Liquid is a multi-regional professional esports organization with successful teams in games like Dota 2, CS:GO, League of Legends, and more. They have won numerous championships and are recognized for their competitive achievements.')
SET IDENTITY_INSERT [dbo].[gaming_organization] OFF
GO
SET IDENTITY_INSERT [dbo].[Guest] ON 

INSERT [dbo].[Guest] ([guest_id], [user_id]) VALUES (1, 3)
INSERT [dbo].[Guest] ([guest_id], [user_id]) VALUES (2, 4)
SET IDENTITY_INSERT [dbo].[Guest] OFF
GO
SET IDENTITY_INSERT [dbo].[Proplayers] ON 

INSERT [dbo].[Proplayers] ([player_id], [player_name], [player_nationality], [player_team], [player_achievements], [player_team_id]) VALUES (1, N'Faker', N'Korean', N'T1', N'10 League of Legends Champions Korea (LCK) titles, two Mid-Season Invitational (MSI) titles, and a record four World Championship titles.', 1)
INSERT [dbo].[Proplayers] ([player_id], [player_name], [player_nationality], [player_team], [player_achievements], [player_team_id]) VALUES (2, N'S1mple', N'Ukranian', N'Natus Vincere', N'won a record 21 HLTV MVP medals, a Major and an Intel Grand Slam trophy, among other numerous S-Tier trophies, and has been crowned as the best player of 2018, 2021, and 2022', 2)
SET IDENTITY_INSERT [dbo].[Proplayers] OFF
GO
SET IDENTITY_INSERT [dbo].[Streamer_details] ON 

INSERT [dbo].[Streamer_details] ([streamer_id], [streamer_name], [twitch_rank], [description], [most_streamed_game], [number_of_followers], [game_id]) VALUES (1, N'Ninja', 44, N'Richard Tyler Blevins, better known as "Ninja", is an American online streamer, YouTuber and professional gamer. Blevins began streaming through participating in several esports teams in competitive play for Halo 3, and gradually picked up fame when he first started playing Fortnite Battle Royale in late 2017. Blevins'' rise among mainstream media began in March 2018 when he played Fortnite together with Drake, Travis Scott and JuJu Smith-Schuster on stream, breaking a peak viewer count record on Twitch. Blevins has over 18 million followers on his Twitch channel, making it the most-followed Twitch channel as of March 2023.                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                          ', N'Fortnite                                                                                            ', 18984053, NULL)
INSERT [dbo].[Streamer_details] ([streamer_id], [streamer_name], [twitch_rank], [description], [most_streamed_game], [number_of_followers], [game_id]) VALUES (2, N'Tfue', 631, N'Turner, better known as Tfue, is an American online streamer, esports player, and YouTuber best known for playing Fortnite.
Tenney previously streamed games such as Call of Duty, Destiny and H1Z1, but he transitioned to Fortnite Battle Royale as it was quickly gaining popularity. Tfue later joined FaZe Clan, a professional esports organization.                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                     ', N'Fortnite                                                                                            ', 11413099, NULL)
SET IDENTITY_INSERT [dbo].[Streamer_details] OFF
GO
SET IDENTITY_INSERT [dbo].[Team] ON 

INSERT [dbo].[Team] ([team_id], [team_name]) VALUES (1, N'team-liquid league of legends')
INSERT [dbo].[Team] ([team_id], [team_name]) VALUES (2, N'team-OG DOTA2')
SET IDENTITY_INSERT [dbo].[Team] OFF
GO
SET IDENTITY_INSERT [dbo].[Tournament_details] ON 

INSERT [dbo].[Tournament_details] ([tournament_id], [tournament_name], [description], [tournament_game_id], [tournament_game_name]) VALUES (1, N'League of Legends World Championship', N'Gear up and drop into the ultimate Fortnite Battle Royale Showdown! It''s time for players to showcase their building and shooting skills in an epic tournament that will leave the last one standing as the undisputed champion. The Fortnite Battle Royale Showdown promises intense action, incredible moments, and a battle royale experience like never before.', NULL, N'League of Legends')
INSERT [dbo].[Tournament_details] ([tournament_id], [tournament_name], [description], [tournament_game_id], [tournament_game_name]) VALUES (2, N'Fortnite World Cup', N'Gear up and drop into the ultimate Fortnite Battle Royale Showdown! It''s time for players to showcase their building and shooting skills in an epic tournament that will leave the last one standing as the undisputed champion. The Fortnite Battle Royale Showdown promises intense action, incredible moments, and a battle royale experience like never before.', NULL, N'Fortnite')
SET IDENTITY_INSERT [dbo].[Tournament_details] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([user_id], [user_name], [user_password]) VALUES (1, N'Omar', N'Deeb123')
INSERT [dbo].[Users] ([user_id], [user_name], [user_password]) VALUES (2, N'Ismail', N'seddik321')
INSERT [dbo].[Users] ([user_id], [user_name], [user_password]) VALUES (3, N'Ishowspeed', N'lol123')
INSERT [dbo].[Users] ([user_id], [user_name], [user_password]) VALUES (4, N'Johan', N'4xgpyt&jBgDPDVY&')
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
ALTER TABLE [dbo].[Admins]  WITH CHECK ADD  CONSTRAINT [FK_Admins_Users] FOREIGN KEY([user_id])
REFERENCES [dbo].[Users] ([user_id])
GO
ALTER TABLE [dbo].[Admins] CHECK CONSTRAINT [FK_Admins_Users]
GO
ALTER TABLE [dbo].[Game_engines]  WITH CHECK ADD  CONSTRAINT [FK_Game_engines_Game_titles] FOREIGN KEY([game_id])
REFERENCES [dbo].[Game_titles] ([game_id])
GO
ALTER TABLE [dbo].[Game_engines] CHECK CONSTRAINT [FK_Game_engines_Game_titles]
GO
ALTER TABLE [dbo].[Game_stores]  WITH CHECK ADD  CONSTRAINT [FK_Game_stores_Game_titles] FOREIGN KEY([store_game_id])
REFERENCES [dbo].[Game_titles] ([game_id])
GO
ALTER TABLE [dbo].[Game_stores] CHECK CONSTRAINT [FK_Game_stores_Game_titles]
GO
ALTER TABLE [dbo].[Guest]  WITH CHECK ADD  CONSTRAINT [FK_Guest_Users] FOREIGN KEY([user_id])
REFERENCES [dbo].[Users] ([user_id])
GO
ALTER TABLE [dbo].[Guest] CHECK CONSTRAINT [FK_Guest_Users]
GO
ALTER TABLE [dbo].[Proplayers]  WITH CHECK ADD  CONSTRAINT [FK_Proplayers_Team] FOREIGN KEY([player_team_id])
REFERENCES [dbo].[Team] ([team_id])
GO
ALTER TABLE [dbo].[Proplayers] CHECK CONSTRAINT [FK_Proplayers_Team]
GO
ALTER TABLE [dbo].[Streamer_details]  WITH CHECK ADD  CONSTRAINT [FK_Streamer_details_Game_titles] FOREIGN KEY([game_id])
REFERENCES [dbo].[Game_titles] ([game_id])
GO
ALTER TABLE [dbo].[Streamer_details] CHECK CONSTRAINT [FK_Streamer_details_Game_titles]
GO
ALTER TABLE [dbo].[Tournament_details]  WITH CHECK ADD  CONSTRAINT [FK_Tournament_details_Game_titles] FOREIGN KEY([tournament_game_id])
REFERENCES [dbo].[Game_titles] ([game_id])
GO
ALTER TABLE [dbo].[Tournament_details] CHECK CONSTRAINT [FK_Tournament_details_Game_titles]
GO
USE [master]
GO
ALTER DATABASE [GamesData] SET  READ_WRITE 
GO
