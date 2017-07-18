IF OBJECT_ID (N'fnGetVendorHistory', N'FN') IS NOT NULL  
    DROP FUNCTION dbo.fnGetVendorHistory;  
GO  

CREATE FUNCTION  dbo.fnGetVendorHistory(@ID int)  
RETURNS Table   
AS     
RETURN
(  
Select  v.SysStartTime, v.SysEndTime, v.ABN,v.Account,v.AddressId,v.BankName,
        v.BSB,v.ContactPerson,v.CreatedBy,v.DateCreated,v.DateUpdated
		,v.Email,v.Fax,v.id as vendorid,v.[Name],v.PHAPVendorNumber,v.Phone,v.SiteName,
		a.id as aid,a.Postcode,a.StreetName,a.StreetNo,a.Suburb,a.UnitNo
        from Vendor for system_time all v inner join [Address]  for system_time all a 
        on v.AddressId = a.Id  and v.SysStartTime = a.SysStartTime and v.SysEndTime = a.SysEndTime		
        where v.Id = @ID
)  
GO

select * from fnGetVendorHistory(1)  