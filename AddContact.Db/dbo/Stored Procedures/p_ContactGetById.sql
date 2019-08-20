create proc dbo.p_ContactGetById
	@Id int
as
	set nocount on

	select
		Id
		,[Name]
		,Email
		,Phone
		,StreetAddress
		,Suburb
		,PostCode
	from
		dbo.Contact
	where
		Id = @Id