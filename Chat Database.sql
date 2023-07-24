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



--_________________________________ private and Channel Tabels ____________________________________
use EvolveMain

select * from tblPrivateMessage

create table tblPrivateMessage
(
	id int primary key identity,
	senderId int,
	receiverId int,
	messageText nvarchar(max),
	appId int,
	applicationReviewId int,
	isReceiver bit,
	isSender bit,
	IsDeleted int default 0,
	reminder datetime,
	timeStamp datetime default getDate(),
)


create table tblMessageReadStatus
(
	id int primary key identity,
	isChannelMessages bit,
	messageId int, -- private,Message -- chanelmessage
	userId int,
	channelId int,
)


create table  tblMsgFiles(
	id int primary key identity,
	fileBytes varBinary(Max),
	fileName varchar(25),
	fileType varchar(25),
	[datetime] datetime
)



create table tblMsgFileRef(
	id int primary key identity,
	privateMessageId int,
	channelMessageId int,
	fileId int
)


create table tblChannel(
	id int primary key identity,
	--fileBytes VARBINARY(Max),
	name varchar(25),
	status bit,
	createdBy int,
	createdOn datetime,
	modifiedBy int,
	modifiedOn datetime
)

create table tblChannelsUsers
(
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
	senderId int,
	messageText nvarchar(max),
	appId int,
	applicationReviewId int,
	IsDeletedForSender int default 0,
	reminder datetime,
	timeStamp datetime default getDate(),
)

create table tblSendNotification(
	id int primary key identity,
	userId int ,
	isChannelMessage bit,
	notificationText nvarchar(max),
	notificationTime datetime
)

---- Example: Send a notification to users who haven't seen a message after the deadline
--DECLARE @deadline DATETIME = '2023-07-31 23:59:59'; -- Replace with the specific deadline date and time

--INSERT INTO tblNotifications (userId, messageId, isChannelMessage, notificationText, notificationTime)
--SELECT
--    r.userId,
--    r.messageId,
--    r.isChannelMessage,
--    'You have an unread message. Please check it out.',
--    GETDATE() AS notificationTime
--FROM
--    tblMessageReadStatus r
--WHERE
--    r.hasSeen = 0 -- Users who haven't seen the message
--    AND r.notificationSent = 0 -- Avoid sending multiple notifications for the same message
--    AND r.reminder <= @deadline; -- Messages with the deadline on or before the specified date

---- After sending notifications, update the `notificationSent` flag to avoid sending duplicate notifications.
--UPDATE tblMessageReadStatus
--SET notificationSent = 1
--WHERE
--    hasSeen = 0
--    AND reminder <= @deadline;



--_________________________________ Procedures ____________________________________
use EvolveMain

select * from tblPrivateMessage

--_____________ insert _____________ 
alter proc spInsertPrivateMessage
@id int out,
@senderId int,
@receiverId int,
@messageText nvarchar(max),
@appId int,
@applicationReviewId int,
@isReceiver bit,
@isSender bit,
@reminder datetime
as
begin
	insert into tblPrivateMessage(
	senderId
	,receiverId
	,messageText
	,appId
	,applicationReviewId
	,isReceiver
	,isSender 
	,reminder
	)
	values (
		@senderId,
		@receiverId,
		@messageText,
		@appId,
		@applicationReviewId,
		@isReceiver,
		@isSender,
		@reminder
	)

   SELECT @id = SCOPE_IDENTITY();

	-- Calculate and insert the matching tags into matchingTagsOfMessage table
	DECLARE @tags NVARCHAR(MAX) = 'missing,Not found,Wrong,mistake,Grammar mistake';
	INSERT INTO matchingTagsOfMessage (matchingTag, count, userId, messageId, appId)
	SELECT
		s.Tag,
		0,
		@receiverId,
		@id,
		@appId
	FROM dbo.SplitTags(@tags) s
	WHERE CHARINDEX(s.Tag, @messageText) > 0;
end

create table matchingTagsOfMessage(
	id int primary key identity,
	matchingTag varchar(25),
	count int,
	userId int,
	messageId int,
	appId int
)

select * from matchingTagsOfMessage


CREATE FUNCTION dbo.SplitTags
(
    @tags NVARCHAR(MAX)
)
RETURNS TABLE
AS
RETURN (
    WITH Split AS
    (
        SELECT
            LTRIM(RTRIM(Split.a.value('.', 'VARCHAR(100)'))) AS Tag
        FROM (
            SELECT CAST('<X>' + REPLACE(@tags, ',', '</X><X>') + '</X>' AS XML) AS TagXml
        ) AS A
        CROSS APPLY TagXml.nodes('/X') AS Split(a)
    )
    SELECT Tag FROM Split
);

select * from matchingTagsOfMessage

CREATE TABLE tblTags (
    id INT PRIMARY KEY IDENTITY,
    name VARCHAR(100),
);


--_____________ Select All private messge _____________ 
create proc spSelectAllPrivateMessage
as
begin
	SELECT pm.Id,
			pm.SenderId,
			pm.ReceiverId,
			pm.MessageText,
			pm.AppId,
			pm.ApplicationReviewId,
			pm.IsReceiver,
			pm.IsSender,
			pm.IsDeleted,
			pm.Reminder,
			pm.Timestamp
			--s.Username AS SenderUsername,
			--r.Username AS ReceiverUsername
	FROM tblPrivateMessage pm
end



--_____________ Select private messge _____________ 
alter PROCEDURE spSelectPrivateMessage
    @currentUserId INT,
    @receiverId INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT pm.Id,
           pm.SenderId,
           pm.ReceiverId,
           pm.MessageText,
           pm.AppId,
           pm.ApplicationReviewId,
           pm.IsReceiver,
           pm.IsSender,
		   pm.IsDeleted,
           pm.Reminder,
           pm.Timestamp
           --s.Username AS SenderUsername,
           --r.Username AS ReceiverUsername
    FROM tblPrivateMessage pm
    --LEFT JOIN tblUsers s ON pm.SenderId = s.Id  
    --LEFT JOIN tblUsers r ON pm.ReceiverId = r.Id
    WHERE (pm.SenderId = @currentUserId AND pm.ReceiverId = @receiverId)
          OR (pm.SenderId = @receiverId AND pm.ReceiverId = @currentUserId)
          AND (
              pm.IsDeleted = 0 --show to every one
              OR (pm.IsDeleted = 1 AND pm.SenderId != @currentUserId) -- don't show sender but show to everyone
              OR pm.IsDeleted = 2 -- delete for every one
          )
    ORDER BY pm.Timestamp;
END



--_____________ Select Single Message ___________________
alter PROCEDURE spSelectPrivateMessageById
    @messageId INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        Id,
        SenderId,
        ReceiverId,
        MessageText,
        AppId,
        ApplicationReviewId,
        IsReceiver,
		IsDeleted,
        IsSender,
        Reminder,
        TimeStamp
    FROM tblPrivateMessage
    WHERE Id = @messageId;
END



--_____________ delete Message every one ___________________
create proc spDeleteMessageForEveryOne
@messageId int
as
begin

	update tblPrivateMessage
	set IsDeleted = 2
	where id = @messageId
end


--_____________ delete Message for sender ___________________s
create proc spDeleteMessageForSender
@messageId int
as
begin
	update tblPrivateMessage
	set IsDeleted = 1
	where id = @messageId
end




























--_________________________ 1 to 1 private Message _____________________________

--create table tblPrivateMessage(
--	id int primary key identity,
--	senderId int,
--	receiverId int,
--	message nvarchar(1000),
--	timeStamp datetime default getDate(),
--	isReaded bit,
--	isSender bit,
--	isRecever bit
--)


--alter proc spIsertPrivateMessage
--@id int output,
--@senderId int,
--@receverId int,
--@message nvarchar(1000)
--as
--begin
--	insert into 
--		tblPrivateMessage (senderId,receiverId,message,isReaded,isSender,isRecever)
--		values 
--		(@senderId,@receverId,@message,0,1,0)
--	select @id=@@IDENTITY
--end

--sp_helptext spInsertAppBusinessPartner

--create proc spUpdatePrivateMessage
--@senderId int,
--@receiverId int
--as
--begin
--	update tblPrivateMessage 
--	set isReaded = 1,
--	isRecever = 1
--	where senderId = @senderId and receiverId = @receiverId
--end



--_____________________ spSelectAllPrivateMessage __________________
--alter PROCEDURE spSelectAllPrivateMessage
--    @senderId INT,
--    @receiverId INT
--AS
--BEGIN
--    SELECT *
--    FROM tblPrivateMessage
--    WHERE (senderId = @senderId AND receiverId = @receiverId)
--        OR (senderId = @receiverId AND receiverId = @senderId)
--    ORDER BY Timestamp;
--END

--exec spSelectAllPrivateMessage 2,1


--update tblPrivateMessage set isRecever=1 where id = 2
																																														
----_____________________ chatGroup _____________________________

--drop table tblGroups
--create table tblGroups(
--	id int Primary key,
--	groupName varchar(50),
--	status bit default 1,
--	createdBy int,
--	createdOn datetime,
--	modifiedBy int default null,
--	modifiedOn datetime default null
--)

--create proc spGetGroups
--as
--begin
--	select * from tblgroups
--end


--create proc spInsertGroup
--@id int output,
--@groupName varchar(50),
--@createdBy int,
--@createdOn datetime
--as
--begin
--	insert into tblGroups
--	(groupName,createdBy,createdOn)
--	values
--	(@groupName,@createdBy,@createdOn);

--	select @id = @@Identity
--end




--create proc spUpdateGroup
--@groupid int,
--@groupName varchar(50),
--@modifiedBy int,
--@modifiedOn datetime
--as
--begin
--	update tblGroups 
--	set 
--	groupName=@groupName
--	,modifiedBy=@modifiedBy
--	,modifiedOn=@modifiedOn
--	where id = @groupid
--end


--create proc spUpdateGroup
--@groupid int,
--@groupName varchar(50),
--@modifiedBy int,
--@modifiedOn datetime
--as
--begin
--	update tblGroups 
--	set 
--	groupName=@groupName
--	,modifiedBy=@modifiedBy
--	,modifiedOn=@modifiedOn
--	where id = @groupid
--end


--_____________________ chatGroup _____________________________
--select * from tblMessageFiles


--create table tblMessageFiles(
-- id int primary key identity,
-- senderId int ,
-- receiverdId int default null,
-- fileBytes VARBINARY(MAX),
-- fileName nvarchar(250),
-- groupId int
--)


--create proc tblPrivateMessageFiles
--@senderId int,
--@receiverId int,
--@fileBytes Varbinary(Max),
--@fileName nvarchar(250)
--as
--begin
--	insert into tblMessageFiles(senderid,receiverdId,fileBytes,fileName)
--	values (@senderId,@receiverId,@fileBytes,@fileName)
--end

--create proc tblGroupMessageFiles
--@senderId int,
--@groupId int,
--@fileBytes Varbinary(Max),
--@fileName nvarchar(250)
--as
--begin
--	insert into tblMessageFiles(senderid,groupId,fileBytes,fileName)
--	values (@senderId,@groupId,@fileBytes,@fileName)
--end









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

use

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




--create table channel(
--	id int primary key identity,
--	name varchar(25),
--	status bit ,
--	createdBy int,
--	createdOn datetime,
--	modifiedBy int,
--	modifiedOn datetime
--)

--create table tblUsersChannel(
--	id int primary key identity,
--	channelId int,
--	userId int,
--	status bit,
--	addedBy int,
--	removedBy int,
--	addedOn datetime,
--	removedOn datetime
--)


--create table tblChannelMessage(
--	id int primary key identity,
--	channelId int,
--	senderId  int,
--	channelId int,
--	message nvarchar(Max),
--	appId int,
--	applicationReviewId int,
--	TimeStamp datetime,
--	isReaded bit,
--	isRecever bit,
--	isSender bit,
--)

--create table tblPrivateMessage(
--	Id int primary key identity,
--	senderId int,
--	receiverId int,
--	message nvarchar(Max),
--	appId int,
--	applicationReviewId int,
--	TimeStamp datetime,
--	isReaded bit,
--	isRecever bit,
--	isSender bit
--)


--create table tblMsgFileRef(
--	Id int primary key identity,
--	privateMessageId int,
--	channelMessageId int,
--	fileId int,
--)

--create table tblMsgFiles(
--	Id int primary key identity,
--	fileBytes varbinary(Max),
--	fileName nvarchar(500),
--	fileType  nvarchar(25)
--)


--drop table tblPrivateMessage
--CREATE TABLE tblPrivateMessages (
--    id INT PRIMARY KEY IDENTITY,
--    senderId INT, -- Reference to userId in tblUsers
--    receiverId INT, -- Reference to userId in tblUsers
--    messageText NVARCHAR(MAX), -- Include emojis in the message text
--    appId INT,
--    applicationReviewId INT,
--    timeStamp DATETIME,
--    reminder DATETIME,
--    -- Add other private message-related columns as needed
--);


--INSERT INTO tblPrivateMessages (senderId, receiverId, messageText, appId, applicationReviewId, timeStamp, reminder)
--VALUES (1, 2, N'Hello! 😀😀', 123, 456, GETDATE(), NULL);

--select * from tblPrivateMessages

