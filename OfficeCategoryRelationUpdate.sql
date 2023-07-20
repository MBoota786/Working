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


