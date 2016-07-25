USE [job_board_test]
GO
/****** Object:  Table [dbo].[accounts]    Script Date: 7/25/2016 9:02:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[accounts](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[first_name] [varchar](355) NULL,
	[last_name] [varchar](355) NULL,
	[email] [varchar](255) NULL,
	[phone] [varchar](255) NULL,
	[education] [int] NULL,
	[resume] [varchar](5000) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[jobs]    Script Date: 7/25/2016 9:02:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[jobs](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[title] [varchar](255) NULL,
	[description] [varchar](5000) NULL,
	[salary] [int] NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
