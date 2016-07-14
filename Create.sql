CREATE DATABASE DBShop;
USE DBShop;

CREATE TABLE [dbo].[tPeople](
[ID_Human] INT IDENTITY (1,1) NOT NULL,
[First_name] NVARCHAR (50) NOT NULL,
[Second_name] NVARCHAR (50) NOT NULL,
[Middle_name] NVARCHAR (50) NOT NULL,
[Date_of_birthday] DATE NOT NULL,
[Serias_passport] NVARCHAR (50) NOT NULL,
[ID_number] INT NOT NULL,
[Index_city] SMALLINT NOT NULL,
[City] NVARCHAR (50),
[Street] NVARCHAR (50),
[Home] NVARCHAR (50),
[Phone_number] INT NOT NULL,
[Email] NVARCHAR (50) NOT NULL,
CONSTRAINT [PK_tPeople] PRIMARY KEY CLUSTERED ([ID_Human] ASC)
);

CREATE TABLE [dbo].[tSuppliers](
[ID_Supplier] INT IDENTITY (1,1) NOT NULL,
[ID_Human] INT NOT NULL,
[Company] NVARCHAR (50) NOT NULL,
CONSTRAINT [PK_tSuppliers] PRIMARY KEY CLUSTERED ([ID_Supplier] ASC),
CONSTRAINT [FK_tPeople] FOREIGN KEY ([ID_Human]) REFERENCES [tPeople] ([ID_Human]) ON DELETE CASCADE,
);

CREATE TABLE [dbo].[tBuyers](
[ID_Buyer] INT IDENTITY (1,1) NOT NULL,
[ID_Human] INT NOT NULL,
CONSTRAINT [PK_tBuyers] PRIMARY KEY CLUSTERED ([ID_Buyer] ASC),
CONSTRAINT [FK_tPeople2] FOREIGN KEY ([ID_Human]) REFERENCES [tPeople] ([ID_Human]) ON DELETE CASCADE,
);

CREATE TABLE [dbo].[tCo-workers](
[ID_Co-worker] INT IDENTITY (1,1) NOT NULL,
[ID_Human] INT NOT NULL,
[Position] NVARCHAR (50) NOT NULL,
[Employment_date] DATE NOT NULL,
CONSTRAINT [PK_tCo-Workers] PRIMARY KEY CLUSTERED ([ID_Co-worker] ASC),
CONSTRAINT [FK_tPeople3] FOREIGN KEY ([ID_Human]) REFERENCES [tPeople] ([ID_Human]) ON DELETE CASCADE,
);

CREATE TABLE [dbo].[tProducts](
[ID_Product] INT IDENTITY (1,1) NOT NULL,
[ID_Supplier] INT NOT NULL,
[Group_of_product] NVARCHAR (50) NOT NULL,
[Name_of_product] NVARCHAR (50) NOT NULL,
[Material_of_product] NVARCHAR (50) NOT NULL,
[Manufacturer_of_product] NVARCHAR (50) NOT NULL,
[Price_of_product] FLOAT NOT NULL,
CONSTRAINT [PK_tProducts] PRIMARY KEY CLUSTERED ([ID_Product] ASC),
CONSTRAINT [FK_tSuppliers1] FOREIGN KEY ([ID_Supplier]) REFERENCES [dbo].[tSuppliers] ([ID_Supplier]) ON DELETE CASCADE,
);

CREATE TABLE [dbo].[tSold_prod](
[ID_Sold_prod] INT IDENTITY (1,1) NOT NULL,
[ID_Product] INT NOT NULL,
[ID_Co-worker] INT NOT NULL,
[ID_Buyer] INT NOT NULL,
[Count_of_prod] INT NOT NULL,
[Total_price] FLOAT NOT NULL,
[Sold_date] DATE NOT NULL,
CONSTRAINT [PK_tSold_prod] PRIMARY KEY CLUSTERED ([ID_Sold_prod] ASC),
CONSTRAINT [FK_tProducts2] FOREIGN KEY ([ID_Product]) REFERENCES [dbo].[tProducts] ([ID_Product]) ON DELETE CASCADE,
CONSTRAINT [FK_tCo-workers] FOREIGN KEY ([ID_Co-worker]) REFERENCES [dbo].[tCo-workers] ([ID_Co-worker]) ON DELETE NO ACTION,
CONSTRAINT [FK_tBuyers] FOREIGN KEY ([ID_Buyer]) REFERENCES [dbo].[tBuyers] ([ID_Buyer]) ON DELETE NO ACTION,
);

CREATE TABLE [dbo].[tPre_orders](
[ID_Pre_order] INT IDENTITY (1,1) NOT NULL,
[ID_Product] INT NOT NULL,
[ID_Buyer] INT NOT NULL,
[Count_of_pre_order] INT NOT NULL,
[Total_price] FLOAT NOT NULL,
[Paid] FLOAT NOT NULL,
[Pre_date] DATE NOT NULL,
[State] NVARCHAR (50) NOT NULL,
[Note] NVARCHAR (150) NULL,
CONSTRAINT [PK_tPre_orders] PRIMARY KEY CLUSTERED ([ID_Pre_order] ASC),
CONSTRAINT [FK_tProducts3] FOREIGN KEY ([ID_Product]) REFERENCES [dbo].[tProducts] ([ID_Product]) ON DELETE CASCADE,
CONSTRAINT [FK_tBuyers2] FOREIGN KEY ([ID_Buyer]) REFERENCES [dbo].[tBuyers] ([ID_Buyer]) ON DELETE NO ACTION,
);
