--__________________________ Office Scop _____________________________________
select * from tblOfficeScope


--_______ 1. Select all scope ____________
exec spSelectAllOfficeScope
select * from tblServiceScope

--_______ 2. Select scope by Id____________
exec spSelectOfficeScopeById 1

--_______ 3. Select scope by officeId____________
use EvolveMain
exec spSelectOfficeScopeByOfficeId 1008

CREATE proc spSelectOfficeScopeByOfficeId(@officeId int)
	as
	SELECT [id]
		  ,[officeId]
		  ,[countryId]
		  ,[serviceScopeId]
		  ,isExclusive
		  ,[active]
		  ,[createdOn]
		  ,[createdBy]
		  ,[modifiedOn]
		  ,[modifiedBy]
	  FROM [dbo].[tblOfficeScope]
	  where active = 1 and officeId = @officeId


--_______ 4. Insert ____________
spInsertOfficeScope

--_______ 5. Update ____________


