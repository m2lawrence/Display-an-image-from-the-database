Create proc spGetImageById
@Id int
as
Begin
	Select ImageData from tblImages where Id = @Id
End
Go