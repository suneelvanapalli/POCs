select * from vendor FOR SYSTEM_TIME ALL order by DateUpdated
select  * from [address] FOR SYSTEM_TIME ALL where id = 40 order by DateUpdated

Drop view vw_selectvendordetails
GO
Create View vw_selectvendordetails 
AS
Select 
v.SysStartTime, v.SysEndTime, v.ABN,v.Account,v.AddressId,v.BankName,v.BSB,v.ContactPerson,v.CreatedBy,v.DateCreated,v.DateUpdated
,v.Email,v.Fax,v.id as vendorid,v.[Name],v.PHAPVendorNumber,v.Phone,v.SiteName,
a.id as aid,a.Postcode,a.StreetName,a.StreetNo,a.Suburb,a.UnitNo
 from Vendor v inner join [Address] a
on v.AddressId = a.Id  and v.SysStartTime = a.SysStartTime and v.SysEndTime = a.SysEndTime
GO

select * from vw_selectvendordetails for system_time all
order by DateUpdated desc

