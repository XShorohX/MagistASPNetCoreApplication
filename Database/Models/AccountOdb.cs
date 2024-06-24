namespace Corpa4Sem4.Database.Models
{
    public class AccountOdb
    {
        public string Account = @"
-- public.""Account"" definition

-- Drop table

-- DROP TABLE public.""Account"";

CREATE TABLE public.""Account"" (
    ""Id"" varchar(7) NOT NULL,
    ""OpeningDate"" timestamp NOT NULL,
    ""OwnerId"" int NOT NULL,
    ""CurrentBalance"" decimal(15, 2) NOT NULL DEFAULT 0.00,
    ""AccountTypeId"" int NOT NULL,
    CONSTRAINT ""PK_Account"" PRIMARY KEY (""Id""),
    CONSTRAINT ""FK_Account_Owner"" FOREIGN KEY (""OwnerId"") REFERENCES public.""NaturalPerson"" (""Id""),
    CONSTRAINT ""FK_Account_Type"" FOREIGN KEY (""AccountTypeId"") REFERENCES public.""AccountType"" (""Id"")
);";
    }
}