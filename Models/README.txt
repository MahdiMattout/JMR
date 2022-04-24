dotnet ef migrations add "changed constraints" 

dotnet ef database update

Use this:

using (var db = new BloggingContext()){

}