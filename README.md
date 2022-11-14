Hi,

There is a WebAPI for CRUD testing as you asked me to implement.
It uses the DB-first aproach, so please create a CRUDTEST database and add a table with the following script
(Unfortunately, I did not have enough time to make package)
please set yor connectionstring for both ReadModel and WriteModel in appsetting.json
It is API and you can use postman or swagger to test it
unit test is implemented in the test folder

CREATE TABLE [dbo].[Customer](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Firstname] [nvarchar](50) NULL,
	[Lastname] [nvarchar](50) NULL,
	[DateOfBirth] [datetime] NULL,
	[PhoneNumber] [nvarchar](20) NULL,
	[Email] [nvarchar](50) NULL,
	[BankAccountNumber] [nvarchar](50) NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


