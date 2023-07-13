--__________________________ Office _____________________________________

--__ insert ____
CREATE proc [dbo].[spInsertOffice]
(
 @id int output
,@officeCode nvarchar(30)
,@officeTypeId int
,@officeName nvarchar(250)
,@taxNo nvarchar(200)
,@businessLicenseNumber nvarchar(200)
,@businessTypeId int
,@reportingOfficeId int
,@companyTypeId int
,@officeActiveStsId int
,@officeActivateBy int
,@activeDate datetime
,@baseCurrencyId int
,@officeFolderPath nvarchar(50)
,@isEmailSent bit
,@isExclusive bit
,@categoryRelationId int
,@officeWebsite nvarchar(250)
,@countryId int
,@stateProvinceId int
,@cityId int
,@officeAddressLine1 nvarchar(250)
,@officeAddressLine2 nvarchar(250)
,@officeAddressLine3 nvarchar(250)
,@officePostalCode nvarchar(50)
,@officePoBox nvarchar(50)
,@officeCountryAreaCode nvarchar(50)
,@officeCellNumber nvarchar(50)
,@extention nvarchar(50)
,@officePhoneIsoCode nvarchar(50)
,@officePhoneNumber nvarchar(50)
,@active bit
,@createdOn datetime
,@createdBy int
)
as
INSERT INTO [dbo].[tblOffice]
           ([officeCode]
		   ,[officeTypeId]
           ,[officeName]
           ,taxNo
           ,[businessLicenseNumber]
           ,[businessTypeId]
           ,[reportingOfficeId]
		    ,[companyTypeId]
           ,[officeActiveStsId]
           ,[officeActivateBy]
           ,[activeDate]
           ,[baseCurrencyId]
		   ,[officeFolderPath]
		   ,[isEmailSent]
		   ,isExclusive
		   ,categoryRelationId
		   ,officeWebsite
		      ,[countryId]
           ,[stateProvinceId]
           ,[cityId]
           ,[officeAddressLine1]
           ,[officeAddressLine2]
           ,[officeAddressLine3]
           ,[officePostalCode]
           ,[officePoBox]
           ,[officeCountryAreaCode]
           ,[officeCellNumber]
           ,[extention]
           ,[officePhoneIsoCode]
           ,[officePhoneNumber]
           ,[active]
           ,[createdOn]
           ,[createdBy])
     VALUES
           (@officeCode
		   ,@officeTypeId
           ,@officeName 
           ,@taxNo
           ,@businessLicenseNumber 
           ,@businessTypeId 
           ,@reportingOfficeId 
		   ,@companyTypeId 
           ,@officeActiveStsId 
           ,@officeActivateBy 
           ,@activeDate 
           ,@baseCurrencyId 
		   ,@officeFolderPath
		   ,@isEmailSent
		   ,@isExclusive
		   ,@categoryRelationId
		   ,@officeWebsite
		   ,@countryId
           ,@stateProvinceId
           ,@cityId
           ,@officeAddressLine1
           ,@officeAddressLine2
           ,@officeAddressLine3
           ,@officePostalCode
           ,@officePoBox
           ,@officeCountryAreaCode
           ,@officeCellNumber
           ,@extention
           ,@officePhoneIsoCode
           ,@officePhoneNumber
           ,@active 
           ,@createdOn 
           ,@createdBy 
            )
select @id=@@IDENTITY

--___ Select All office ____
sp_helptext spSelectAllOffice

CREATE proc [dbo].[spSelectAllOffice]
as
select  
O.id
,O.officeCode
,O.[officeTypeId]
,OT.officeTypeName
,O.[officeName]
,O.taxNo
,O.[businessLicenseNumber]
,O.[businessTypeId]
,BT.businessTypeName
,O.[reportingOfficeId]
,RepOff.officeName as reportingOfficeName
,O.baseCurrencyId
,Curr.currencyName
,O.companyTypeId
,CT.companyTypeName
,O.officeActiveStsId
,O.officeActivateBy
,O.officeFolderPath
,O.isEmailSent
,o.isExclusive
,O.activeDate
,O.categoryRelationId
,cr.categoryRelation
,o.officeWebsite
,o.[countryId]
,o.[stateProvinceId]
,o.[cityId]
,o.[officeAddressLine1]
,o.[officeAddressLine2]
,o.[officeAddressLine3]
,o.[officePostalCode]
,o.[officePoBox]
,o.[officeCountryAreaCode]
,o.[officeCellNumber]
,o.[extention]
,o.[officePhoneIsoCode]
,o.[officePhoneNumber]
,O.[active]
,O.[createdOn]
from tblOffice O 
left join tblOfficeType OT on OT.id=O.officeTypeId
left join tblBusinessType BT on BT.id=O.BusinessTypeId
left join tblOffice RepOff on RepOff.id=O.reportingOfficeId 
left join tblCurrency Curr on Curr.id=O.baseCurrencyId
left join tblCompanyType CT on CT.id=O.companyTypeId
left join tblCategoryRelation cr on cr.id = O.categoryRelationId

--___ Select office by type Id ____
select * from tbloffice
sp_helpText spSelectOfficeByOfficeTypeId
exec spSelectOfficeByOfficeTypeId 4

--___ Select office by  ReportingOfficeId ____
sp_helptext spSelectOfficeForListByReportingOfficeId
exec spSelectOfficeForListByReportingOfficeId 7

--___ Select office by  ReportingOfficeId ____
select * from viewOfficeCheck

CREATE proc spSelectOfficeForListByReportingOfficeId(@reportingOfficeId int = null)
as
select distinct o.id,reportingOfficeId,o.officeCode,o.officeName,ot.officeTypeName,c.countryName,sp.stateProvinceName,ct.cityName,o.isExclusive 
,CONVERT(nvarchar,voc.Expr1 + voc.Expr2 + voc.Expr3) as perStatus
from tblOffice o
left join tblOfficeType ot on ot.id = o.officeTypeId
left join tblCountry c on c.id = o.countryId
left join tblStateProvince sp on sp.id = o.stateProvinceId
left join tblCity ct on ct.id = o.cityId
left join viewOfficeCheck voc on voc.officeId = o.id
where ot.id <> 1 and (reportingOfficeId = 0 or reportingOfficeId = @reportingOfficeId)

--___ Select office by ReportingOfficeId ____



