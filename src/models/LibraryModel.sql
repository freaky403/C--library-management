
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 04/06/2023 13:49:48
-- Generated from EDMX file: E:\laragon\www\Winform\Nhom8-QLTV\src\models\LibraryModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [library_management];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_book_borrow_book_id_foreign]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[book_borrow] DROP CONSTRAINT [FK_book_borrow_book_id_foreign];
GO
IF OBJECT_ID(N'[dbo].[FK_book_borrow_borrow_id_foreign]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[book_borrow] DROP CONSTRAINT [FK_book_borrow_borrow_id_foreign];
GO
IF OBJECT_ID(N'[dbo].[FK_book_borrow_reader_id_foreign]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[book_borrow] DROP CONSTRAINT [FK_book_borrow_reader_id_foreign];
GO
IF OBJECT_ID(N'[dbo].[FK_borrows_user_id_foreign]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[borrows] DROP CONSTRAINT [FK_borrows_user_id_foreign];
GO
IF OBJECT_ID(N'[dbo].[FK_category_book_book_id_foreign]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[category_book] DROP CONSTRAINT [FK_category_book_book_id_foreign];
GO
IF OBJECT_ID(N'[dbo].[FK_category_book_category_id_foreign]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[category_book] DROP CONSTRAINT [FK_category_book_category_id_foreign];
GO
IF OBJECT_ID(N'[dbo].[FK_permission_role_permission_id_foreign]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[permission_role] DROP CONSTRAINT [FK_permission_role_permission_id_foreign];
GO
IF OBJECT_ID(N'[dbo].[FK_permission_role_role_id_foreign]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[permission_role] DROP CONSTRAINT [FK_permission_role_role_id_foreign];
GO
IF OBJECT_ID(N'[dbo].[FK_role_user_role_id_foreign]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[role_user] DROP CONSTRAINT [FK_role_user_role_id_foreign];
GO
IF OBJECT_ID(N'[dbo].[FK_role_user_user_id_foreign]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[role_user] DROP CONSTRAINT [FK_role_user_user_id_foreign];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[book_borrow]', 'U') IS NOT NULL
    DROP TABLE [dbo].[book_borrow];
GO
IF OBJECT_ID(N'[dbo].[books]', 'U') IS NOT NULL
    DROP TABLE [dbo].[books];
GO
IF OBJECT_ID(N'[dbo].[borrows]', 'U') IS NOT NULL
    DROP TABLE [dbo].[borrows];
GO
IF OBJECT_ID(N'[dbo].[categories]', 'U') IS NOT NULL
    DROP TABLE [dbo].[categories];
GO
IF OBJECT_ID(N'[dbo].[category_book]', 'U') IS NOT NULL
    DROP TABLE [dbo].[category_book];
GO
IF OBJECT_ID(N'[dbo].[permission_role]', 'U') IS NOT NULL
    DROP TABLE [dbo].[permission_role];
GO
IF OBJECT_ID(N'[dbo].[permissions]', 'U') IS NOT NULL
    DROP TABLE [dbo].[permissions];
GO
IF OBJECT_ID(N'[dbo].[readers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[readers];
GO
IF OBJECT_ID(N'[dbo].[role_user]', 'U') IS NOT NULL
    DROP TABLE [dbo].[role_user];
GO
IF OBJECT_ID(N'[dbo].[roles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[roles];
GO
IF OBJECT_ID(N'[dbo].[users]', 'U') IS NOT NULL
    DROP TABLE [dbo].[users];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'book_borrow'
CREATE TABLE [dbo].[book_borrow] (
    [id] bigint IDENTITY(1,1) NOT NULL,
    [book_id] bigint  NOT NULL,
    [borrow_id] bigint  NOT NULL,
    [reader_id] bigint  NOT NULL,
    [quantity] int  NULL,
    [created_at] datetime  NULL,
    [updated_at] datetime  NULL
);
GO

-- Creating table 'books'
CREATE TABLE [dbo].[books] (
    [id] bigint IDENTITY(1,1) NOT NULL,
    [name] nvarchar(255)  NOT NULL,
    [author] nvarchar(255)  NULL,
    [publisher] nvarchar(255)  NULL,
    [published] int  NULL,
    [quantity] int  NULL,
    [created_at] datetime  NULL,
    [updated_at] datetime  NULL
);
GO

-- Creating table 'borrows'
CREATE TABLE [dbo].[borrows] (
    [id] bigint IDENTITY(1,1) NOT NULL,
    [user_id] bigint  NOT NULL,
    [borrowed_date] datetime  NOT NULL,
    [expires_at] datetime  NULL,
    [return_at] datetime  NULL,
    [created_at] datetime  NULL,
    [updated_at] datetime  NULL
);
GO

-- Creating table 'categories'
CREATE TABLE [dbo].[categories] (
    [id] bigint IDENTITY(1,1) NOT NULL,
    [name] nvarchar(255)  NOT NULL,
    [created_at] datetime  NULL,
    [updated_at] datetime  NULL
);
GO

-- Creating table 'category_book'
CREATE TABLE [dbo].[category_book] (
    [id] bigint IDENTITY(1,1) NOT NULL,
    [category_id] bigint  NOT NULL,
    [book_id] bigint  NOT NULL,
    [created_at] datetime  NULL,
    [updated_at] datetime  NULL
);
GO

-- Creating table 'permission_role'
CREATE TABLE [dbo].[permission_role] (
    [id] bigint IDENTITY(1,1) NOT NULL,
    [permission_id] bigint  NOT NULL,
    [role_id] bigint  NOT NULL,
    [created_at] datetime  NULL,
    [updated_at] datetime  NULL
);
GO

-- Creating table 'permissions'
CREATE TABLE [dbo].[permissions] (
    [id] bigint IDENTITY(1,1) NOT NULL,
    [permission1] int  NOT NULL,
    [key] varchar(191)  NOT NULL,
    [created_at] datetime  NULL,
    [updated_at] datetime  NULL
);
GO

-- Creating table 'readers'
CREATE TABLE [dbo].[readers] (
    [id] bigint IDENTITY(1,1) NOT NULL,
    [name] nvarchar(255)  NOT NULL,
    [date_of_birth] datetime  NULL,
    [gender] smallint  NULL,
    [phone_number] varchar(10)  NOT NULL,
    [expires_at] datetime  NULL,
    [created_at] datetime  NULL,
    [updated_at] datetime  NULL
);
GO

-- Creating table 'role_user'
CREATE TABLE [dbo].[role_user] (
    [id] bigint IDENTITY(1,1) NOT NULL,
    [role_id] bigint  NOT NULL,
    [user_id] bigint  NOT NULL,
    [created_at] datetime  NULL,
    [updated_at] datetime  NULL
);
GO

-- Creating table 'roles'
CREATE TABLE [dbo].[roles] (
    [id] bigint IDENTITY(1,1) NOT NULL,
    [role1] int  NOT NULL,
    [key] varchar(191)  NOT NULL,
    [created_at] datetime  NULL,
    [updated_at] datetime  NULL
);
GO

-- Creating table 'users'
CREATE TABLE [dbo].[users] (
    [id] bigint IDENTITY(1,1) NOT NULL,
    [username] varchar(20)  NOT NULL,
    [email] varchar(191)  NOT NULL,
    [password] varchar(300)  NOT NULL,
    [created_at] datetime  NULL,
    [updated_at] datetime  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [id] in table 'book_borrow'
ALTER TABLE [dbo].[book_borrow]
ADD CONSTRAINT [PK_book_borrow]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'books'
ALTER TABLE [dbo].[books]
ADD CONSTRAINT [PK_books]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'borrows'
ALTER TABLE [dbo].[borrows]
ADD CONSTRAINT [PK_borrows]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'categories'
ALTER TABLE [dbo].[categories]
ADD CONSTRAINT [PK_categories]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'category_book'
ALTER TABLE [dbo].[category_book]
ADD CONSTRAINT [PK_category_book]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'permission_role'
ALTER TABLE [dbo].[permission_role]
ADD CONSTRAINT [PK_permission_role]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'permissions'
ALTER TABLE [dbo].[permissions]
ADD CONSTRAINT [PK_permissions]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'readers'
ALTER TABLE [dbo].[readers]
ADD CONSTRAINT [PK_readers]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'role_user'
ALTER TABLE [dbo].[role_user]
ADD CONSTRAINT [PK_role_user]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'roles'
ALTER TABLE [dbo].[roles]
ADD CONSTRAINT [PK_roles]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'users'
ALTER TABLE [dbo].[users]
ADD CONSTRAINT [PK_users]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [book_id] in table 'book_borrow'
ALTER TABLE [dbo].[book_borrow]
ADD CONSTRAINT [FK_book_borrow_book_id_foreign]
    FOREIGN KEY ([book_id])
    REFERENCES [dbo].[books]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_book_borrow_book_id_foreign'
CREATE INDEX [IX_FK_book_borrow_book_id_foreign]
ON [dbo].[book_borrow]
    ([book_id]);
GO

-- Creating foreign key on [borrow_id] in table 'book_borrow'
ALTER TABLE [dbo].[book_borrow]
ADD CONSTRAINT [FK_book_borrow_borrow_id_foreign]
    FOREIGN KEY ([borrow_id])
    REFERENCES [dbo].[borrows]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_book_borrow_borrow_id_foreign'
CREATE INDEX [IX_FK_book_borrow_borrow_id_foreign]
ON [dbo].[book_borrow]
    ([borrow_id]);
GO

-- Creating foreign key on [reader_id] in table 'book_borrow'
ALTER TABLE [dbo].[book_borrow]
ADD CONSTRAINT [FK_book_borrow_reader_id_foreign]
    FOREIGN KEY ([reader_id])
    REFERENCES [dbo].[readers]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_book_borrow_reader_id_foreign'
CREATE INDEX [IX_FK_book_borrow_reader_id_foreign]
ON [dbo].[book_borrow]
    ([reader_id]);
GO

-- Creating foreign key on [book_id] in table 'category_book'
ALTER TABLE [dbo].[category_book]
ADD CONSTRAINT [FK_category_book_book_id_foreign]
    FOREIGN KEY ([book_id])
    REFERENCES [dbo].[books]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_category_book_book_id_foreign'
CREATE INDEX [IX_FK_category_book_book_id_foreign]
ON [dbo].[category_book]
    ([book_id]);
GO

-- Creating foreign key on [user_id] in table 'borrows'
ALTER TABLE [dbo].[borrows]
ADD CONSTRAINT [FK_borrows_user_id_foreign]
    FOREIGN KEY ([user_id])
    REFERENCES [dbo].[users]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_borrows_user_id_foreign'
CREATE INDEX [IX_FK_borrows_user_id_foreign]
ON [dbo].[borrows]
    ([user_id]);
GO

-- Creating foreign key on [category_id] in table 'category_book'
ALTER TABLE [dbo].[category_book]
ADD CONSTRAINT [FK_category_book_category_id_foreign]
    FOREIGN KEY ([category_id])
    REFERENCES [dbo].[categories]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_category_book_category_id_foreign'
CREATE INDEX [IX_FK_category_book_category_id_foreign]
ON [dbo].[category_book]
    ([category_id]);
GO

-- Creating foreign key on [permission_id] in table 'permission_role'
ALTER TABLE [dbo].[permission_role]
ADD CONSTRAINT [FK_permission_role_permission_id_foreign]
    FOREIGN KEY ([permission_id])
    REFERENCES [dbo].[permissions]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_permission_role_permission_id_foreign'
CREATE INDEX [IX_FK_permission_role_permission_id_foreign]
ON [dbo].[permission_role]
    ([permission_id]);
GO

-- Creating foreign key on [role_id] in table 'permission_role'
ALTER TABLE [dbo].[permission_role]
ADD CONSTRAINT [FK_permission_role_role_id_foreign]
    FOREIGN KEY ([role_id])
    REFERENCES [dbo].[roles]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_permission_role_role_id_foreign'
CREATE INDEX [IX_FK_permission_role_role_id_foreign]
ON [dbo].[permission_role]
    ([role_id]);
GO

-- Creating foreign key on [role_id] in table 'role_user'
ALTER TABLE [dbo].[role_user]
ADD CONSTRAINT [FK_role_user_role_id_foreign]
    FOREIGN KEY ([role_id])
    REFERENCES [dbo].[roles]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_role_user_role_id_foreign'
CREATE INDEX [IX_FK_role_user_role_id_foreign]
ON [dbo].[role_user]
    ([role_id]);
GO

-- Creating foreign key on [user_id] in table 'role_user'
ALTER TABLE [dbo].[role_user]
ADD CONSTRAINT [FK_role_user_user_id_foreign]
    FOREIGN KEY ([user_id])
    REFERENCES [dbo].[users]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_role_user_user_id_foreign'
CREATE INDEX [IX_FK_role_user_user_id_foreign]
ON [dbo].[role_user]
    ([user_id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------