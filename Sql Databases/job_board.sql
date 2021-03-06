CREATE DATABASE job_board;
GO
USE [job_board]
GO
/****** Object:  Table [dbo].[accounts]    Script Date: 7/28/2016 2:32:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[accounts](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[first_name] [varchar](355) NULL,
	[last_name] [varchar](355) NULL,
	[email] [varchar](255) NULL,
	[phone] [varchar](255) NULL,
	[education] [int] NULL,
	[resume] [varchar](5000) NULL,
	[username] [varchar](255) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[categories]    Script Date: 7/28/2016 2:32:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[categories](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](255) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[companies]    Script Date: 7/28/2016 2:32:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[companies](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](500) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[jobs]    Script Date: 7/28/2016 2:32:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[jobs](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[title] [varchar](255) NULL,
	[description] [varchar](5000) NULL,
	[salary] [int] NULL,
	[company_id] [int] NULL,
	[category_id] [int] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[jobs_keywords]    Script Date: 7/28/2016 2:32:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[jobs_keywords](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[job_id] [int] NULL,
	[keyword_id] [int] NULL,
	[number_of_repeats] [int] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[keywords]    Script Date: 7/28/2016 2:32:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[keywords](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[word] [varchar](255) NULL
) ON [PRIMARY]

GO
