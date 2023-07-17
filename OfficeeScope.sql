--____________________ office Scope  (standardeds , city , state) _______________________
sp_helptext spInsertOfficeScopeStandardMap

CREATE PROCEDURE [dbo].[spInsertOfficeScopeStandardMap]
(
@id int output,
@officeScopeId INT,
@accreditationStandardId INT,
@active BIT,
@createdOn datetime,
@createdBy INT
)
AS
BEGIN
INSERT INTO [dbo].[tblOfficeScopeStandardMap] (officeScopeId, accreditationStandardId, active, createdOn, createdBy)
VALUES (@officeScopeId, @accreditationStandardId, @active, @createdOn, @createdBy)
select @id = @@IDENTITY
END

spInsertOfficeStandards


CREATE proc spSelectOfficeCategoryRelationByOfficeId(@officeId int)
as
SELECT [id]
      ,[officeId]
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


select * from tblOfficeCategoryRelation

select * from tblOffice
select * from tblOfficeStandards
 

sp_helpText spSelectAllOfficeCategoryRelation


select * from tblOfficeScopeCityMap
select * from tblOfficeScopeStateMap
select * from tblOfficeScopeStandardMap
select * from tblOfficeScope

