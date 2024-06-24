﻿namespace Corpa4Sem4.Database.Models
{
    public class AccountTypeOdb
    {
        public string AccountType = @"
-- public.""AccountType"" definition

-- Drop table

-- DROP TABLE public.""AccountType"";

CREATE TABLE public.""AccountType"" (
    ""Id"" int4 NOT NULL GENERATED BY DEFAULT AS IDENTITY ( INCREMENT BY 1 MINVALUE 1 MAXVALUE 2147483647 START 1 CACHE 1 NO CYCLE),
    ""Value"" varchar(50) NOT NULL,
    CONSTRAINT ""PK_AccountType"" PRIMARY KEY (""Id"")
);";
    }
}