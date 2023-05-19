CREATE TABLE [dbo].[users] (
    [id]                   INT                IDENTITY (1, 1) NOT NULL,
    [UserName]             NVARCHAR (MAX)     NOT NULL,
    [NormalizedUserName]   NVARCHAR (MAX)     NOT NULL,
    [AccessFailedCount]    INT                NOT NULL,
    [ConcurrencyStamp]     NVARCHAR (MAX)     NOT NULL,
    [Email]                NVARCHAR (MAX)     NOT NULL,
    [EmailConfirmed]       BIT                NOT NULL,
    [LockoutEnabled]       BIT                NOT NULL,
    [LockoutEnd]           DATETIMEOFFSET (7) NOT NULL,
    [NormalizedEmail]      NVARCHAR (MAX)     NOT NULL,
    [PasswordHash]         NVARCHAR (MAX)     NOT NULL,
    [PhoneNumber]          NVARCHAR (MAX)     NOT NULL,
    [PhoneNumberConfirmed] BIT                NOT NULL,
    [SecurityStamp]        NVARCHAR (MAX)     NOT NULL,
    [TwoFactorEnabled]     BIT                NOT NULL,
    CONSTRAINT [PK__users__3213E83F889E0DF5] PRIMARY KEY CLUSTERED ([id] ASC)
);









