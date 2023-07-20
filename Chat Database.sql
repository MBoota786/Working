use EvolveMain


CREATE proc spSelectAndCheckLogin(@LoginEmail varchar(100),@LoginPassword varchar(100))
as
select ul.id,ul.leadCompanyId,ul.companyId,ul.officeId,ul.userEmail,ul.loginIp,ul.dbName,ls.leadStatusName,Case when isnull(voc.Expr1+voc.Expr2+voc.Expr3,0)=0 then convert(nvarchar(250),0) else CONVERT(nvarchar(250),voc.Expr1+voc.Expr2+voc.Expr3) end as 
eadOfficeStatus,
case when userEmail like 'admin%' then convert(bit,'true') else convert(bit,'false') end as isAdmin
from tblUserLogin ul
left join tblLeadCompany lc  on lc.id = ul.leadCompanyId
left join tblLeadStatus ls on ls.id = lc.leadStatusId
left join viewOfficeCheck voc on ul.officeId = voc.officeId
where ul.userEmail=@LoginEmail and ul.[userPassword]=@LoginPassword

exec spSelectAndCheckLogin 'admin@Test2.com' , '1234'

select * from tblUserLogin
-- Old Data --
--7	0	0	4	NULL	Evolve	admin@evolve	admin1234	admin@evolve.com	NULL	NULL	0	Approve	1	2022-06-29 04:57:14.077	NULL	NULL	1	2022-06-29 04:57:14.077	1	NULL	NULL	NULL	NULL
--1018	0	6	0	0	admin	admin@Test2	1234	admin@Test2.com	NULL	2022-12-05 17:14:26.550	0	Approved	0	2022-12-05 17:14:27.210	Test2	NULL	1	2022-12-05 17:14:24.313	0	NULL	NULL	NULL	NULL

--update tblUserLogin 
--set dbName = 'EvolveMain' -- Test2
--where id = 1018

--__________ adding RoleColum  UserLogin ___________
select * from tblUserLogin

--_____ role table ____
--select * from tblRole
--select * from tblRoleRights
--select * from tblUserRoleMap
--select * from tblUserRoleRequirement


--________
select * from tblUserLogin

id
leadCompanyId
companyId
officeId
designationId
userName
userCode
userPassword
userEmail
userImage
lastLogin
isLogin
approvalStatus
approvalBy
approvalDate
dbName
loginIp
active
createdOn
createdBy
modifiedOn
modifiedBy
resetOtp
otpTime

select * from tblUserLogin


select * from tblClientMaster



--_________________________ 1 to 1 private Message _____________________________
create table tblPrivateMessage(
	id int primary key identity,
	senderId int,
	receiverId int,
	message nvarchar(1000),
	timeStamp datetime default getDate(),
	isReaded bit,
	isSender bit,
	isRecever bit
)


alter proc spIsertPrivateMessage
@id int output,
@senderId int,
@receverId int,
@message nvarchar(1000)
as
begin
	insert into 
		tblPrivateMessage (senderId,receiverId,message,isReaded,isSender,isRecever)
		values 
		(@senderId,@receverId,@message,0,1,0)
	select @id=@@IDENTITY
end

sp_helptext spInsertAppBusinessPartner

create proc spUpdatePrivateMessage
@senderId int,
@receiverId int
as
begin
	update tblPrivateMessage 
	set isReaded = 1,
	isRecever = 1
	where senderId = @senderId and receiverId = @receiverId
end



--_____________________ spSelectAllPrivateMessage __________________
alter PROCEDURE spSelectAllPrivateMessage
    @senderId INT,
    @receiverId INT
AS
BEGIN
    SELECT *
    FROM tblPrivateMessage
    WHERE (senderId = @senderId AND receiverId = @receiverId)
        OR (senderId = @receiverId AND receiverId = @senderId)
    ORDER BY Timestamp;
END

exec spSelectAllPrivateMessage 2,1


update tblPrivateMessage set isRecever=1 where id = 2
																																														
--_____________________ chatGroup _____________________________
drop table tblGroups
create table tblGroups(
	id int Primary key,
	groupName varchar(50),
	status bit default 1,
	createdBy int,
	createdOn datetime,
	modifiedBy int default null,
	modifiedOn datetime default null
)

create proc spGetGroups
as
begin
	select * from tblgroups
end

create proc spInsertGroup
@id int output,
@groupName varchar(50),
@createdBy int,
@createdOn datetime
as
begin
	insert into tblGroups
	(groupName,createdBy,createdOn)
	values
	(@groupName,@createdBy,@createdOn);

	select @id = @@Identity
end



create proc spUpdateGroup
@groupid int,
@groupName varchar(50),
@modifiedBy int,
@modifiedOn datetime
as
begin
	update tblGroups 
	set 
	groupName=@groupName
	,modifiedBy=@modifiedBy
	,modifiedOn=@modifiedOn
	where id = @groupid
end


create proc spUpdateGroup
@groupid int,
@groupName varchar(50),
@modifiedBy int,
@modifiedOn datetime
as
begin
	update tblGroups 
	set 
	groupName=@groupName
	,modifiedBy=@modifiedBy
	,modifiedOn=@modifiedOn
	where id = @groupid
end


--_____________________ chatGroup _____________________________
create table tblMessageFiles(
 id int primary key identity,
 senderId int ,
 receiverdId int default null,
 fileBytes VARBINARY(MAX),
 fileName nvarchar(250),
 groupId int
)


select * from tblMessageFiles

create proc tblPrivateMessageFiles
@senderId int,
@receiverId int,
@fileBytes Varbinary(Max),
@fileName nvarchar(250)
as
begin
	insert into tblMessageFiles(senderid,receiverdId,fileBytes,fileName)
	values (@senderId,@receiverId,@fileBytes,@fileName)
end

create proc tblGroupMessageFiles
@senderId int,
@groupId int,
@fileBytes Varbinary(Max),
@fileName nvarchar(250)
as
begin
	insert into tblMessageFiles(senderid,groupId,fileBytes,fileName)
	values (@senderId,@groupId,@fileBytes,@fileName)
end









--_________________________ Assign User in Group ______________________________
--drop table tblUsersGroup
--create table tblUsersGroup(
--	id int primary key identity,
--	groupId int,
--	userId int,
--	status bit default 1,
--	createdBy int,
--	createdOn int ,
--	modifiedBy int,
--	modifiedOn int
--)

--create proc spGroupUser
--	@id int out,
--	@groupId int,
--	@userId int,
--	@createdBy int,
--	@createdOn int
--	as
--	begin
--	update tblUsersGroup
--	set 
--	groupId = @groupid,
--	userId = @userId
--	select @id = @@IDENTITY
--end

--select * from tblGroups

--__________________________ Message __________________________
--CREATE TABLE tblMessages (
--  id INT PRIMARY KEY Identity,
--  senderId INT,
--  receiverId INT,
--  message NVARCHAR(MAX),
--  timestamp DATETIME,
--  isReaded BIT,
--  isSender BIT,
--  isReceiver BIT,
--  fileData VARBINARY(MAX),
--  fileName NVARCHAR(255)
--);

----_________ Private Messages ___________
--CREATE PROCEDURE InsertPrivateMessages
--  @senderId INT,
--  @receiverId INT,
--  @message NVARCHAR(MAX),
--  @timestamp DATETIME,
--  @isReaded BIT,
--  @isSender BIT,
--  @isReceiver BIT,
--  @fileData VARBINARY(MAX) = NULL,
--  @fileName NVARCHAR(255) = NULL
--AS
--BEGIN
--  INSERT INTO tblMessages (senderId, receiverId, message, timestamp, isReaded, isSender, isReceiver, fileData, fileName)
--  VALUES (@senderId, @receiverId, @message, @timestamp, @isReaded, @isSender, @isReceiver, @fileData, @fileName);
--END


----_________ Group Messages ___________
--CREATE PROCEDURE InsertGroupMessage
--  @senderId INT,
--  @groupId INT,
--  @message NVARCHAR(MAX),
--  @timestamp DATETIME,
--  @isReaded BIT,
--  @isSender BIT,
--  @isReceiver BIT,
--  @fileData VARBINARY(MAX) = NULL,
--  @fileName NVARCHAR(255) = NULL
--AS
--BEGIN
--  -- Insert group message logic here
--  -- Customize the INSERT statement based on your group message requirements
--  -- Example:
--  -- INSERT INTO GroupMessages (senderId, groupId, message, timestamp, isReaded, isSender, isReceiver, fileData, fileName)
--  -- VALUES (@senderId, @groupId, @message, @timestamp, @isReaded, @isSender, @isReceiver, @fileData, @fileName);
--END



--CREATE PROCEDURE SelectPrivateMessages
--  @senderId INT,
--  @receiverId INT
--AS
--BEGIN
--  SELECT * FROM Messages
--  WHERE senderId = @senderId AND receiverId = @receiverId;
--END



--CREATE PROCEDURE SelectGroupMessages
--  @groupId INT
--AS
--BEGIN
--  -- Select group message logic here
--  -- Customize the SELECT statement based on your group message requirements
--  -- Example:
--  -- SELECT * FROM GroupMessages WHERE groupId = @groupId;
--END


create table channel(
	id int primary key identity,
	name varchar(25),
	status bit ,
	createdBy int,
	createdOn datetime,
	modifiedBy int,
	modifiedOn datetime
)

create table tblUsersChannel(
	id int primary key identity,
	channelId int,
	userId int,
	status bit,
	addedBy int,
	removedBy int,
	addedOn datetime,
	removedOn datetime
)


create table tblChannelMessage(
	id int primary key identity,
	channelId int,
	senderId  int,
	channelId int,
	message nvarchar(Max),
	appId int,
	applicationReviewId int,
	TimeStamp datetime,
	isReaded bit,
	isRecever bit,
	isSender bit,
)

create table tblPrivateMessage(
	Id int primary key identity,
	senderId int,
	receiverId int,
	message nvarchar(Max),
	appId int,
	applicationReviewId int,
	TimeStamp datetime,
	isReaded bit,
	isRecever bit,
	isSender bit
)


create table tblMsgFileRef(
	Id int primary key identity,
	privateMessageId int,
	channelMessageId int,
	fileId int,
)

create table tblMsgFiles(
	Id int primary key identity,
	fileBytes varbinary(Max),
	fileName nvarchar(500),
	fileType  nvarchar(25)
)

