sp_helptext spSelectOfficeCategoryRelationByOfficeId


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