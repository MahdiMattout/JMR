dotnet ef migrations add "changed constraints" 

dotnet ef database update

Use this:

using (var db = new BloggingContext()){

}
To merge migrations:
https://stackoverflow.com/questions/40740802/merge-migrations-in-entity-framework-core