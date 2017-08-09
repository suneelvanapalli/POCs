
Drop table #TempTable

----Get the history of the relief application
SELECT ROW_NUMBER() OVER(order by SysEndTime) as RID, SysStartTime, SysEndTime,*   INTO #TempTable
FROM ReliefApplication 
for system_time all where ApplicationNumber = 'R10000001' order by DateUpdated desc

--get a version
DECLARE @applicationId INT , @sysStart DateTime2 , @sysEnd DateTime2,  @rid int ; SET @rid = 2
Select @applicationid =  id , @sysStart =  [sysStartTime], @sysEnd =  [sysEndTime]   from #TempTable where RID = @rid
Select  * from #TempTable --where RID = @rid
--Documents
Select SysStartTime , SysEndTime, d.[FileName],  * from ReliefApplicationDocument  for system_time all  ad
inner join Document d on ad.DocumentId = d.Id 
where ApplicationId  = @applicationId 
and ((ad.SysStartTime >= @sysStart and SysStartTime < @sysEnd) OR (ad.SysStartTime < @sysStart and SysEndTime = '9999-12-31 23:59:59.9999999' ))
--Members
select sysStartTime,[sysEndTime], m.GivenName, m.Surname,  * from ApplicationMember for system_time all am
inner join Member m on am.MemberId = m.Id
where ReliefApplicationId = @applicationId 
and ((SysStartTime >= @sysStart and SysStartTime < @sysEnd) OR  (SysStartTime < @sysStart and SysEndTime = '9999-12-31 23:59:59.9999999' ))
--Affected Address
select aa.SysStartTime, aa.SysEndTime, a.*, aa.* from AffectedAddress  for system_time all aa
inner join Address for system_time all a on aa.AddressId = a.id
where aa.id = @applicationId  and aa.sysStartTime  = @sysStart and aa.SysEndTime = @sysEnd




