create proc dbo.p_ContactUpdate
	@Id int
	,@Name nvarchar(100)
	,@Email nvarchar(100)
	,@Phone nvarchar(50)
	,@StreetAddress nvarchar(100)
	,@Suburb nvarchar(100)
	,@PostCode nvarchar(20)
as
	set nocount on

	update
		dbo.Contact
	set
		[Name] = @Name
		,Email = @Email
		,Phone = @Phone
		,StreetAddress = @StreetAddress
		,Suburb = @Suburb
		,PostCode = @PostCode
	where
		Id = @Id