CREATE database job_board_test
GO
USE [job_board]
GO
/****** Object:  Table [dbo].[accounts]    Script Date: 7/25/2016 4:49:14 PM ******/
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
/****** Object:  Table [dbo].[jobs]    Script Date: 7/25/2016 4:49:14 PM ******/
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
/****** Object:  Table [dbo].[jobs_keywords]    Script Date: 7/25/2016 4:49:15 PM ******/
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
/****** Object:  Table [dbo].[keywords]    Script Date: 7/25/2016 4:49:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[keywords](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[word] [varchar](255) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[jobs] ON 

INSERT [dbo].[jobs] ([id], [title], [description], [salary]) VALUES (1, N'cat burglar', N'Steal cats. Make money. Steal money. Cats!', 23)
INSERT [dbo].[jobs] ([id], [title], [description], [salary]) VALUES (2, N'cat burglar', N'Steal cats. Make money. Steal money. Cats!', 23)
INSERT [dbo].[jobs] ([id], [title], [description], [salary]) VALUES (3, N'cat burglar', N'Steal cats. Make money. Steal money. Cats!', 23)
INSERT [dbo].[jobs] ([id], [title], [description], [salary]) VALUES (4, N'worker', N'Warehouse Associate - Sign on Bonus! 
Staff Management - Portland, OR 
$16.50 an hour - Part-time
With Staff Management | SMX, you''ll get a weekly paycheck, learn new skills, meet new people, and work with a great management team in a clean and safe environment.
Warehouse/Distribution Positions Available

Join our team and start out by earning $16.50/HR working part-time. We are seeking Enthusiastic, Energetic and Customer Centric individuals for our Warehouse Associate positions. The ideal candidates for these roles have a commitment to customer satisfaction. As customers make on-line purchases, a member of our team will get the product and package for delivery.

Located in Portland, OR near Vancouver, WA.

Job Responsibilities: The Warehouse Associate Job Duties consist, but are not limited to the following: Receiving, stowing, picking, packing and shipping customer purchased product or goods using an RF (Radio Frequency) Scanner. These roles will continuously have you on the move and directly impacting the Amazon customer experience.We have several part-time shift options available at the local delivery station.

Part Time
3rd Shift
Associate Requirements:

HS Diploma or GED
Must be at least 18 years old
Associate Benefits:

Paid Training
Weekly paychecks
Direct Deposit or Cash Card pay options
Medical / Dental Insurance
Sign on Bonus (Restrictions Apply)
Casual Dress Code
Earn up to $16.50/HR
$500 Sign-on Bonus
', 23)
INSERT [dbo].[jobs] ([id], [title], [description], [salary]) VALUES (5, N'worker', N'Warehouse Associate - Sign on Bonus! 
Staff Management - Portland, OR 
$16.50 an hour - Part-time
With Staff Management | SMX, you''ll get a weekly paycheck, learn new skills, meet new people, and work with a great management team in a clean and safe environment.
Warehouse/Distribution Positions Available

Join our team and start out by earning $16.50/HR working part-time. We are seeking Enthusiastic, Energetic and Customer Centric individuals for our Warehouse Associate positions. The ideal candidates for these roles have a commitment to customer satisfaction. As customers make on-line purchases, a member of our team will get the product and package for delivery.

Located in Portland, OR near Vancouver, WA.

Job Responsibilities: The Warehouse Associate Job Duties consist, but are not limited to the following: Receiving, stowing, picking, packing and shipping customer purchased product or goods using an RF (Radio Frequency) Scanner. These roles will continuously have you on the move and directly impacting the Amazon customer experience.We have several part-time shift options available at the local delivery station.

Part Time
3rd Shift
Associate Requirements:

HS Diploma or GED
Must be at least 18 years old
Associate Benefits:

Paid Training
Weekly paychecks
Direct Deposit or Cash Card pay options
Medical / Dental Insurance
Sign on Bonus (Restrictions Apply)
Casual Dress Code
Earn up to $16.50/HR
$500 Sign-on Bonus
', 23)
INSERT [dbo].[jobs] ([id], [title], [description], [salary]) VALUES (6, N'worker', N'Warehouse Associate - Sign on Bonus! 
Staff Management - Portland, OR 
$16.50 an hour - Part-time
With Staff Management | SMX, you''ll get a weekly paycheck, learn new skills, meet new people, and work with a great management team in a clean and safe environment.
Warehouse/Distribution Positions Available

Join our team and start out by earning $16.50/HR working part-time. We are seeking Enthusiastic, Energetic and Customer Centric individuals for our Warehouse Associate positions. The ideal candidates for these roles have a commitment to customer satisfaction. As customers make on-line purchases, a member of our team will get the product and package for delivery.

Located in Portland, OR near Vancouver, WA.

Job Responsibilities: The Warehouse Associate Job Duties consist, but are not limited to the following: Receiving, stowing, picking, packing and shipping customer purchased product or goods using an RF (Radio Frequency) Scanner. These roles will continuously have you on the move and directly impacting the Amazon customer experience.We have several part-time shift options available at the local delivery station.

Part Time
3rd Shift
Associate Requirements:

HS Diploma or GED
Must be at least 18 years old
Associate Benefits:

Paid Training
Weekly paychecks
Direct Deposit or Cash Card pay options
Medical / Dental Insurance
Sign on Bonus (Restrictions Apply)
Casual Dress Code
Earn up to $16.50/HR
$500 Sign-on Bonus
', 23)
INSERT [dbo].[jobs] ([id], [title], [description], [salary]) VALUES (7, N'worker', N'Womply Front End Developers are passionate about designing quality code through a collaborative process to build a suite of compelling small business tools. We enjoy the challenges of building the next generation of web applications and approach these problems with creativity and various technologies. We are looking for a Junior Front End Developer to join our growing team in Portland. Outstanding candidates have experience with JavaScript, HTML5, CSS3, and have some exposure to JavaScript frameworks, such as Angular.JS.

You will be responsible for working on a team that is building web applications for small merchants across the U.S. You will collaborate with Product Management, Design, and Test Automation to develop user interfaces that can be tested easily and continue to scale as our team grows. Also, you will work as part of the engineering team in a Scrum environment throughout the complete design and implementation process. To ensure success, teamwork will be critical as you can expect to interact with many different parts of our organization.

You Have:

1+ years of experience as a Front End/UI Developer building web applications using JavaScript, HTML5, and CSS3
Previous exposure to JavaScript frameworks, such as Angular.JS
Some previous experience with Ruby on Rails or Java is desired but not required
Previous start-up (or small company) experience strongly preferred
Drive to work hard and learn as much as possible about Front End development and the relevant Front End technologies
Previous experience working in an Agile/Scrum environment is preferred
About Womply

Womply is one of the fastest growing merchant-focused companies in America. Our mission is to use technology and data to grow, protect, and simplify small business. Every day we serve tens of thousands of merchants, across 400+ business verticals, in every corner of America. We''re hiring in both San Francisco and Portland for engineering, devops, design, sales, marketing, business development, account management, and more.', 23)
INSERT [dbo].[jobs] ([id], [title], [description], [salary]) VALUES (8, N'worker', N'Software Engineer
Job Description
Job Description: If you are a seasoned developer looking for a position on a development team engaged in problem solving, enhancing existing products and taking care of customers, Intel Security has an opportunity for you. 

This position reports in to the Endpoint Sustaining team. This person will be working on the VirusScan Enterprise (VSE) and Host Intrusion Prevention (HIP) Enterprise products. In this position, you will apply your extensive experience to influence the technical direction and design of the sustaining efforts for these products. You will influence the direction of these products in reaction to business needs and industry trends. You will ensure technical and process excellence; act as a key resource to Intel Security on technical matters and partner with internal stakeholders, customers and industry contacts to champion McAfee products. You will lead the Sustaining Engineering effort by ensuring effective completion of process tasks such as design reviews, code review, coding standards, unit testing, and etc. In addition to the technical leadership responsibilities you will also need to serve as a working member of the team solving customer issues and completing project development tasks. The ideal candidate will have a strong combination software development and problem solving skills as well as customer focus, quality mindset, and communication. 

What you will do: 
Mentor development engineers and advance best-practices such as modular design, documentation, unit-testing, code-reuse, code review, and etc. 
Lead design, implementation, and unit test tasks as part of sustaining releases for service packs, patches and hot fixes. 
Analyze, debug and determine root cause of application and driver level issues with the VSE and HIP products and implement solutions. 
Work closely with our support organization as well as external customers to address issues escalated from the field as part of the bug reproduction and resolution process 
Provide the mainline team key knowledge from the field on systemic issues as part of continuous improvement. 
Work with the Sustaining Development Manager to define / improve development methodology and processes. 
Work with Sustaining QA to develop comprehensive test plans. 
Mentor junior engineers, and advance best-practices such as modular design, documentation, unit-testing, code-reuse, code review, etc. 

Qualifications
5-10+ years of Development Experience on Windows. 
A solid understanding of Windows internals and experience with kernel development is highly desired. 
Strong knowledge of Windows operating system architecture, memory management mechanism, synchronization and file systems. 
Proven experience in C/C++ programming on Windows 
Networking knowledge and ability to analyze network traffic using sniffers (e.g. Ethereal, Windows LANAnalyzer) is a plus 
Strong problem solving and analytical skills such as Windows Crash Dumps is required 
Experience with using kernel debugger to debug and fix complex low level problems. 
Experience with Continuous Integration build environments including automated Unit Test execution frameworks highly desired. 
Excellent communication skills, both oral and written, and the ability to collaborate with internal and external parties including QA, Support, Development Engineers and Customers 
Experience and understanding of the product development life cycle process 
Team player 
Security knowledge and experience is a plus 
Experience in cross-platform development desirable 
BS in Computer Science or related discipline (Masters Degree in Computer Science preferred) 

Other Locations

Posting Statement
Intel prohibits discrimination based on race, color, religion, gender, national origin, age, disability, veteran status, marital status, pregnancy, gender expression or identity, sexual orientation or any other legally protected status.', 23)
INSERT [dbo].[jobs] ([id], [title], [description], [salary]) VALUES (9, N'jon', N'	
This position is within Viewpoint?s Vista Online development team. The successful candidate will have a solid understanding of .NET, SQL Server, and web technologies, as well as, a solid history of delivering web-enabled solutions utilizing Microsoft technologies. This division provides a software solution with capabilities such as integrated accounting, project management, and operations modules for mid-range to large-scale contractors throughout the United States and aboard.

Essential Duties & Responsibilities: 

Works with software development architect, development and QA teams to perform product design, implementation, defect verification and remedy on application software projects for Viewpoint?s mid-market suite of products.
Liaises directly with Product Management team to implement against product requirements, and solicit more information as required to deliver on time and with quality.
Identifies opportunities for improving software development methods and procedures and communicates recommendations appropriately.
Requirements	
Competencies
 
Delivers working software regularly, in coordination with architect?s design direction and models.
Studies business domain and actively seeks clarity when specifics of domain will be important in dictating software design approach.
Effectively applies broad, in-depth, and up-to-date knowledge of pertinent software development; project management; and technical, business, and professional issues.
Visualizes complex processes to identify and analyze key issues and recommend quality solutions.  Able to participate in development of project estimates, decision analysis, and project schedules.
Demonstrates excellent written and verbal communication skills.  Listens effectively, transmits information accurately and understandably, and actively seeks feedback.  Effectively presents and explains information to others with various levels of knowledge.
Well-organized, self-directed team player.  Remains open to others? ideas, and exhibits willingness to try new things.
Acts as a mentor to junior team members and regularly brings new approaches and ideas to the table.
Adapts to changes in the work environment, manages competing demands and is able to deal with frequent change, delays or unexpected events.
Required:
 
BS degree in a field directly related to software development plus a minimum of five years of relevant technical experience in application design and programming and/or an equivalent combination of education and experience.
Ability to write clear, concise code in C# using a variety of standard .NET libraries and utilizing Object Oriented techniques.
Experience implementing (not just utilizing) formal software design patterns in solutions.
Solid understanding of REST principles.
Experience with multi-tiered architectures in a SOA environment.
Ability to write and debug complex stored procedures/triggers in Transact SQL.
Experience with .NET 4.0/4.5 framework and Visual Studio 2010/2012/2013.
Experience with ASP.NET MVC, Web API and/or WCF services.
Experience utilizing Single Page Application toolsets such as Angular or Durandal.
Experience implementing solutions using Object Relational Mapping tools such as EF or NHibernate.
Experience utilizing unit testing and mocking frameworks such as MSTest, NUnit, Moq, Rhino Mocks, and similar tools.
 
Preferred:
 
?         Experience with Agile and Kanban development methodologies.
?         Experience with Unit Testing and Test Driven Development.
?         Experience with Performance Profiling.
?         Knowledge of construction industry accounting or project management principles and practices.
About Viewpoint, Inc.	
With over 35 years of experience in the construction industry, our comprehensive software products and unparalleled customer support ensure you experience smoother, easier, and more profitable job results. Viewpoint offers integrated ERP and estimating solutions for construction companies of any size, an industry leading content management solution and a mobile application suite designed to track and record time, equipment, and production hours from remote locations.  Viewpoint For Project Collaboration, a multi-tenant cloud offering that enables multiple project stakeholders to collaborate on project documents, rounds out Viewpoint?s comprehensive product suite.', 45000)
INSERT [dbo].[jobs] ([id], [title], [description], [salary]) VALUES (10, N'job', N'Womply Front End Developers are passionate about designing quality code through a collaborative process to build a suite of compelling small business tools. We enjoy the challenges of building the next generation of web applications and approach these problems with creativity and various technologies. We are looking for a Junior Front End Developer to join our growing team in Portland. Outstanding candidates have experience with JavaScript, HTML5, CSS3, and have some exposure to JavaScript frameworks, such as Angular.JS.

You will be responsible for working on a team that is building web applications for small merchants across the U.S. You will collaborate with Product Management, Design, and Test Automation to develop user interfaces that can be tested easily and continue to scale as our team grows. Also, you will work as part of the engineering team in a Scrum environment throughout the complete design and implementation process. To ensure success, teamwork will be critical as you can expect to interact with many different parts of our organization.

You Have:

1+ years of experience as a Front End/UI Developer building web applications using JavaScript, HTML5, and CSS3
Previous exposure to JavaScript frameworks, such as Angular.JS
Some previous experience with Ruby on Rails or Java is desired but not required
Previous start-up (or small company) experience strongly preferred
Drive to work hard and learn as much as possible about Front End development and the relevant Front End technologies
Previous experience working in an Agile/Scrum environment is preferred
About Womply

Womply is one of the fastest growing merchant-focused companies in America. Our mission is to use technology and data to grow, protect, and simplify small business. Every day we serve tens of thousands of merchants, across 400+ business verticals, in every corner of America. We''re hiring in both San Francisco and Portland for engineering, devops, design, sales, marketing, business development, account management, and more.', 23)
INSERT [dbo].[jobs] ([id], [title], [description], [salary]) VALUES (11, N'job', N'Womply Front End Developers are passionate about designing quality code through a collaborative process to build a suite of compelling small business tools. We enjoy the challenges of building the next generation of web applications and approach these problems with creativity and various technologies. We are looking for a Junior Front End Developer to join our growing team in Portland. Outstanding candidates have experience with JavaScript, HTML5, CSS3, and have some exposure to JavaScript frameworks, such as Angular.JS.

You will be responsible for working on a team that is building web applications for small merchants across the U.S. You will collaborate with Product Management, Design, and Test Automation to develop user interfaces that can be tested easily and continue to scale as our team grows. Also, you will work as part of the engineering team in a Scrum environment throughout the complete design and implementation process. To ensure success, teamwork will be critical as you can expect to interact with many different parts of our organization.

You Have:

1+ years of experience as a Front End/UI Developer building web applications using JavaScript, HTML5, and CSS3
Previous exposure to JavaScript frameworks, such as Angular.JS
Some previous experience with Ruby on Rails or Java is desired but not required
Previous start-up (or small company) experience strongly preferred
Drive to work hard and learn as much as possible about Front End development and the relevant Front End technologies
Previous experience working in an Agile/Scrum environment is preferred
About Womply

Womply is one of the fastest growing merchant-focused companies in America. Our mission is to use technology and data to grow, protect, and simplify small business. Every day we serve tens of thousands of merchants, across 400+ business verticals, in every corner of America. We''re hiring in both San Francisco and Portland for engineering, devops, design, sales, marketing, business development, account management, and more.', 23)
INSERT [dbo].[jobs] ([id], [title], [description], [salary]) VALUES (12, N'job', N'Womply Front End Developers are passionate about designing quality code through a collaborative process to build a suite of compelling small business tools. We enjoy the challenges of building the next generation of web applications and approach these problems with creativity and various technologies. We are looking for a Junior Front End Developer to join our growing team in Portland. Outstanding candidates have experience with JavaScript, HTML5, CSS3, and have some exposure to JavaScript frameworks, such as Angular.JS.

You will be responsible for working on a team that is building web applications for small merchants across the U.S. You will collaborate with Product Management, Design, and Test Automation to develop user interfaces that can be tested easily and continue to scale as our team grows. Also, you will work as part of the engineering team in a Scrum environment throughout the complete design and implementation process. To ensure success, teamwork will be critical as you can expect to interact with many different parts of our organization.

You Have:

1+ years of experience as a Front End/UI Developer building web applications using JavaScript, HTML5, and CSS3
Previous exposure to JavaScript frameworks, such as Angular.JS
Some previous experience with Ruby on Rails or Java is desired but not required
Previous start-up (or small company) experience strongly preferred
Drive to work hard and learn as much as possible about Front End development and the relevant Front End technologies
Previous experience working in an Agile/Scrum environment is preferred
About Womply

Womply is one of the fastest growing merchant-focused companies in America. Our mission is to use technology and data to grow, protect, and simplify small business. Every day we serve tens of thousands of merchants, across 400+ business verticals, in every corner of America. We''re hiring in both San Francisco and Portland for engineering, devops, design, sales, marketing, business development, account management, and more.', 23)
SET IDENTITY_INSERT [dbo].[jobs] OFF
