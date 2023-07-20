--____________________ officeCategoryRelation  (standardeds , city , state) _______________________

select * from tblOffice

use EvolveMain
select * from tblOfficeCategoryRelation
select * from tblOfficeCategoryRelStateMap 
select * from tblOfficeCategoryRelCityMap
select * from tblOfficeCategoryRelStandardMap

truncate table tblOfficeCategoryRelation
truncate table tblOfficeCategoryRelStateMap 
truncate table tblOfficeCategoryRelCityMap
truncate table tblOfficeCategoryRelStandardMap


select * from tblStateProvince where stateProvinceName  like 'is'


--================ 1. Adding Country Table ================
sp_helpText spSelectOfficeCategoryRelationByOfficeId
select * from tblStateProvince where countryId = 167

alter proc spSelectAllOfficeCategoryRelation
as
SELECT [id]
      ,[officeId]
	  ,[countryId]
      ,[serviceScopeId]
      ,[hoCategoryRelationId]
      ,[relatedOfficeId]
      ,[isRelatedWithCO]
      ,[isRelatedWithRO]
      ,[isOfficeDemographicScope]
	  ,isOfficeExclusive
      ,[active]
      ,[createdOn]
      ,[createdBy]
  FROM [dbo].[tblOfficeCategoryRelation]
  where active = 1


  


  CREATE proc spUpdateOfficeCategoryRelation
(@id int 
,@officeId int
		,@countryId int
        ,@serviceScopeId int
        ,@hoCategoryRelationId int
        ,@relatedOfficeId int
        ,@isRelatedWithCO bit
        ,@isRelatedWithRO bit
        ,@isOfficeDemographicScope bit
		,@isOfficeExclusive bit
        ,@active bit
        ,@modifiedOn datetime
        ,@modifiedBy int
		)
as
update [dbo].[tblOfficeCategoryRelation]
           set
		    [officeId]                   = @officeId
			,[countryId]					 = @countryId
           ,[serviceScopeId]			 = @serviceScopeId 
           ,[hoCategoryRelationId]		 = @hoCategoryRelationId 
           ,[relatedOfficeId]			 = @relatedOfficeId 
           ,[isRelatedWithCO]			 = @isRelatedWithCO 
           ,[isRelatedWithRO]			 = @isRelatedWithRO 
           ,[isOfficeDemographicScope]	 = @isOfficeDemographicScope
		   ,isOfficeExclusive            = @isOfficeExclusive
           ,[active]					 = @active 
           ,[modifiedOn]					 = @modifiedOn 
           ,[modifiedBy]					 = @modifiedBy 
		  where id = @id


alter proc spInsertOfficeCategoryRelation
(@id int output
			,@officeId int
			,@countryId int
           ,@serviceScopeId int
           ,@hoCategoryRelationId int
           ,@relatedOfficeId int
           ,@isRelatedWithCO bit
           ,@isRelatedWithRO bit
           ,@isOfficeDemographicScope bit
		   ,@isOfficeExclusive bit
           ,@active bit
           ,@createdOn datetime
           ,@createdBy int
		   )
as
INSERT INTO [dbo].[tblOfficeCategoryRelation]
           (
		   [officeId]
		   ,[countryId]
           ,[serviceScopeId]
           ,[hoCategoryRelationId]
           ,[relatedOfficeId]
           ,[isRelatedWithCO]
           ,[isRelatedWithRO]
           ,[isOfficeDemographicScope]
		   ,isOfficeExclusive
           ,[active]
           ,[createdOn]
           ,[createdBy]
		   )
     VALUES
           (@officeId 
           ,@serviceScopeId 
		   ,@countryId
           ,@hoCategoryRelationId 
           ,@relatedOfficeId 
           ,@isRelatedWithCO 
           ,@isRelatedWithRO 
           ,@isOfficeDemographicScope
		   ,@isOfficeExclusive 
           ,@active 
           ,@createdOn 
           ,@createdBy 
		   )
select @id = @@IDENTITY


alter proc spSelectAllOfficeCategoryRelation
as
SELECT [id]
      ,[officeId]
	  ,[countryId]
      ,[serviceScopeId]
      ,[hoCategoryRelationId]
      ,[relatedOfficeId]
      ,[isRelatedWithCO]
      ,[isRelatedWithRO]
      ,[isOfficeDemographicScope]
	  ,isOfficeExclusive
      ,[active]
      ,[createdOn]
      ,[createdBy]
  FROM [dbo].[tblOfficeCategoryRelation]
  where active = 1


alter proc spSelectOfficeCategoryRelationById(@id int)
as
SELECT [id]
      ,[officeId]
	  ,[countryId]
      ,[serviceScopeId]
      ,[hoCategoryRelationId]
      ,[relatedOfficeId]
      ,[isRelatedWithCO]
      ,[isRelatedWithRO]
      ,[isOfficeDemographicScope]
	  ,isOfficeExclusive
      ,[active]
      ,[createdOn]
      ,[createdBy]
  FROM [dbo].[tblOfficeCategoryRelation]
  where id = @id


  

alter proc spSelectOfficeCategoryRelationByOfficeId(@officeId int)
as
SELECT [id]
      ,[officeId]
	  ,[countryId]
      ,[serviceScopeId]
      ,[hoCategoryRelationId]
      ,[relatedOfficeId]
      ,[isRelatedWithCO]
      ,[isRelatedWithRO]
      ,[isOfficeDemographicScope]
	  ,isOfficeExclusive								
      ,[active]
      ,[createdOn]
      ,[createdBy]
  FROM [dbo].[tblOfficeCategoryRelation]
  where active = 1 and officeId = @officeId



--truncate table tblOfficeCategoryRelation
--truncate table tblOfficeCategoryRelStateMap 
--truncate table tblOfficeCategoryRelCityMap
--truncate table tblOfficeCategoryRelStandardMap




--================ 2. tblOfficeCategoryRelStandardMap ================
sp_helpText spInsertOfficeScopeStandardMap
sp_helpText spUpdateOfficeScopeStandardMap
sp_helpText spDeleteOfficeScopeStandardMap
sp_helpText spSelectOfficeScopeStandardMap
--spSelectOfficeScopeStandardMap
sp_helpText spSelectOfficeScopeStandardMapByOfficeScopeId

CREATE PROCEDURE [dbo].[spInsertOfficeCategoryRelationStandardMap]
(
@id int output,
@officeCategoryRelationId INT,
@accreditationStandardId INT,
@active BIT,
@createdOn datetime,
@createdBy INT
)
AS
BEGIN
INSERT INTO [dbo].[tblOfficeCategoryRelStandardMap] (officeCategoryRelationId, accreditationStandardId, active, createdOn, createdBy)
VALUES (@officeCategoryRelationId, @accreditationStandardId, @active, @createdOn, @createdBy)
select @id = @@IDENTITY
END


CREATE PROCEDURE [dbo].[spUpdateOfficeCategoryRelationStandardMap]
(
@id INT,
@officeCategoryRelationId INT,
@accreditationStandardId INT,
@active BIT,
@modifiedOn datetime,
@modifiedBy INT
)
AS
BEGIN
UPDATE [dbo].[tblOfficeCategoryRelStandardMap]
SET officeCategoryRelationId = @officeCategoryRelationId,
accreditationStandardId = @accreditationStandardId,
active = @active,
modifiedOn = @modifiedOn,
modifiedBy = @modifiedBy
WHERE id = @id
END


create proc spDeleteOfficeCategoryRelationStandardMap(@officeCategoryRelationId int)
as
delete from [tblOfficeCategoryRelStandardMap] where officeCategoryRelationId = @officeCategoryRelationId


CREATE PROCEDURE [dbo].[spSelectOfficeCategoryRelationStandardMap]
(
@id INT = NULL
)
AS
BEGIN

SELECT [id], officeCategoryRelationId, [accreditationStandardId], [active], [createdOn], [createdBy], [modifiedOn], [modifiedBy]
FROM [dbo].[tblOfficeCategoryRelStandardMap]
WHERE (@id IS NULL OR id = @id) and active = 1

END




CREATE PROCEDURE [dbo].[spSelectOfficeCategoryRelationStandardMapByOfficeCateRelId]
(
@officeCategoryRelationId INT
)
AS
BEGIN
SELECT ssm.[id], [officeCategoryRelationId], [accreditationStandardId],
asd.standardName,
ssm.[active], ssm.[createdOn], ssm.[createdBy], ssm.[modifiedOn], ssm.[modifiedBy]
FROM [dbo].tblOfficeCategoryRelStandardMap ssm
left join tblAccreditationBodyStandard ab on ab.id = ssm.accreditationStandardId
left join tblAuditStandards asd on asd.id = ab.auditStandardsId
WHERE officeCategoryRelationId = @officeCategoryRelationId and ssm.active =1
END




--================ 3. tblOfficeCategoryRelStateMap ================

create PROCEDURE [dbo].[spInsertOfficeCategoryRelationStateMap]
(
@id int output,
@officeCategoryRelationId INT,
@stateProvinceId INT,
@active BIT,
@createdBy INT,
@createdOn datetime
)
AS
BEGIN
INSERT INTO [dbo].[tblOfficeCategoryRelStateMap] (officeCategoryRelationId, stateProvinceId, active, createdOn, createdBy)
VALUES (@officeCategoryRelationId, @stateProvinceId, @active, @createdOn, @createdBy)
select @id = @@IDENTITY
END


CREATE PROCEDURE [dbo].[spUpdateOfficeCategoryRelationStateMap]
(
@id INT,
@officeCategoryRelationId INT,
@stateProvinceId INT,
@active BIT,
@modifiedBy INT,
@modifiedOn datetime
)
AS
BEGIN
UPDATE [dbo].[tblOfficeCategoryRelStateMap]
SET officeCategoryRelationId = @officeCategoryRelationId,
stateProvinceId = @stateProvinceId,
active = @active,
modifiedOn = modifiedOn,
modifiedBy = @modifiedBy
WHERE id = @id
END


create proc spDeleteOfficeCategoryRelationStateMap(@officeCategoryRelationId int)
as
delete from tblOfficeCategoryRelStateMap 
where officeCategoryRelationId = @officeCategoryRelationId 



CREATE PROCEDURE [dbo].[spSelectOfficeCategoryRelationStateMap]
(
@id INT = NULL
)
AS
BEGIN
SELECT [id], [officeCategoryRelationId], [stateProvinceId], [active], [createdOn], [createdBy], [modifiedOn], [modifiedBy]
FROM [dbo].[tblOfficeCategoryRelStateMap]
WHERE (@id IS NULL OR id = @id) and active = 1
END




CREATE PROCEDURE [dbo].[spSelectOfficeCategoryRelationStateMapByCategoryRelationId]
(
@officeCategoryRelationId INT 
)
AS
BEGIN
SELECT ssm.[id], [officeCategoryRelationId], [stateProvinceId],sp.stateProvinceName, [active], [createdOn], [createdBy], [modifiedOn], [modifiedBy]
FROM [dbo].[tblOfficeCategoryRelStateMap] ssm
left join tblStateProvince sp on sp.id = ssm.stateProvinceId
WHERE officeCategoryRelationId = @officeCategoryRelationId and active = 1
END





--================ 4. tblOfficeCategoryRelCityMap ================

/*#region City */

	select * from tblOfficeCategoryRelCityMap

	-- officeCategoryRelationId
	sp_helpText spDeleteOfficeScopeCityMap

	CREATE PROCEDURE [dbo].[spInsertOfficeCategoryRelationCityMap]
	(
	@id int output,
	@officeCategoryRelationId INT,
	@cityId INT,
	@active BIT,
	@createdBy INT,
	@createdOn datetime
	)
	as
	INSERT INTO [dbo].[tblOfficeCategoryRelCityMap] (officeCategoryRelationId, cityId, active, createdOn, createdBy)
	VALUES (@officeCategoryRelationId, @cityId, @active, @createdOn, @createdBy)
	select @id = @@IDENTITY



	CREATE PROCEDURE [dbo].[spUpdateOfficeCategoryRelationCityMap]
	(
	@id INT,
	@officeCategoryRelationId INT,
	@cityId INT,
	@active BIT,
	@modifiedBy INT,
	@modifiedOn datetime
	)
	AS
	UPDATE [dbo].[tblOfficeCategoryRelCityMap]
	SET officeCategoryRelationId = @officeCategoryRelationId,
		cityId = @cityId,
		active = @active,
		modifiedOn = modifiedOn,
		modifiedBy = @modifiedBy
	WHERE id = @id



	create proc spDeleteOfficeCategoryRelationCityMap(@officeCategoryRelationId int)
	as
	delete from tblOfficeCategoryRelCityMap where officeCategoryRelationId = @officeCategoryRelationId


	sp_helptext spSelectOfficeScopeCityMapById



	create proc spSelectAllOfficeCategoryRelationCityMap
	as
	SELECT [id]
			,[officeCategoryRelationId]
			,[cityId]
			,[active]
			,[createdOn]
			,[createdBy]
			,[modifiedOn]
			,[modifiedBy]
		FROM [dbo].[tblOfficeCategoryRelCityMap]
		where active = 1


  
	create proc spSelectOfficeCategoryRelationCityMapById(@id int)
	as
	SELECT [id]
			,[officeCategoryRelationId]
			,[cityId]
			,[active]
			,[createdOn]
			,[createdBy]
			,[modifiedOn]
			,[modifiedBy]
		FROM [dbo].[tblOfficeCategoryRelCityMap]
		where id = @id


	sp_helpText spSelectOfficeScopeCityMapByOfficeScopeId

  
	CREATE proc spSelectOfficeCategoryRelationCityMapByOfficeCategoryRelationId(@officeCategoryRelationId int)
	as
	SELECT csm.[id]
			,[officeCategoryRelationId]
			,[cityId]
			,[active]
			,[createdOn]
			,[createdBy]
			,[modifiedOn]
			,[modifiedBy]
			,c.cityName
		FROM [dbo].[tblOfficeCategoryRelCityMap] csm
		left join tblCity c on c.id = csm.cityId
		where officeCategoryRelationId = @officeCategoryRelationId and active = 1

/* #endregion */


select * from tblOfficeCategoryRelation
sp_helptext spInsertOfficeCategoryRelation

alter proc spInsertOfficeCategoryRelation
(@id int output
			,@officeId int
			,@countryId int
           ,@serviceScopeId int
           ,@hoCategoryRelationId int
           ,@relatedOfficeId int
           ,@isRelatedWithCO bit
           ,@isRelatedWithRO bit
           ,@isOfficeDemographicScope bit
		   ,@isOfficeExclusive bit
           ,@active bit
           ,@createdOn datetime
           ,@createdBy int
		   )
as
INSERT INTO [dbo].[tblOfficeCategoryRelation]
           (
		   [officeId]
		   ,[countryId]
           ,[serviceScopeId]
           ,[hoCategoryRelationId]
           ,[relatedOfficeId]
           ,[isRelatedWithCO]
           ,[isRelatedWithRO]
           ,[isOfficeDemographicScope]
		   ,isOfficeExclusive
           ,[active]
           ,[createdOn]
           ,[createdBy]
		   )
     VALUES
           (@officeId 
           ,@serviceScopeId 
		   ,@countryId
           ,@hoCategoryRelationId 
           ,@relatedOfficeId 
           ,@isRelatedWithCO 
           ,@isRelatedWithRO 
           ,@isOfficeDemographicScope
		   ,@isOfficeExclusive 
           ,@active 
           ,@createdOn 
           ,@createdBy 
		   )
select @id = @@IDENTITY


alter proc spUpdateOfficeCategoryRelation
(@id int 
,@officeId int
			,@countryId int
           ,@serviceScopeId int
           ,@hoCategoryRelationId int
           ,@relatedOfficeId int
           ,@isRelatedWithCO bit
           ,@isRelatedWithRO bit
           ,@isOfficeDemographicScope bit
		   ,@isOfficeExclusive bit
           ,@active bit
           ,@modifiedOn datetime
           ,@modifiedBy int
		   )
as
update [dbo].[tblOfficeCategoryRelation]
           set
		    [officeId]                   = @officeId
			,[countryId]					 = @countryId
           ,[serviceScopeId]			 = @serviceScopeId 
           ,[hoCategoryRelationId]		 = @hoCategoryRelationId 
           ,[relatedOfficeId]			 = @relatedOfficeId 
           ,[isRelatedWithCO]			 = @isRelatedWithCO 
           ,[isRelatedWithRO]			 = @isRelatedWithRO 
           ,[isOfficeDemographicScope]	 = @isOfficeDemographicScope
		   ,isOfficeExclusive            = @isOfficeExclusive
           ,[active]					 = @active 
           ,[modifiedOn]					 = @modifiedOn 
           ,[modifiedBy]					 = @modifiedBy 
		  where id = @id