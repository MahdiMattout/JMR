dotnet ef migrations add "changed constraints" 

dotnet ef database update

Use this:

using (var db = new BloggingContext()){

}
To merge migrations:
https://stackoverflow.com/questions/40740802/merge-migrations-in-entity-framework-core
2nd article : 
https://www.michalbialecki.com/en/2020/07/24/merging-migrations-in-entity-framework-core-5/