Token auth:
1.You can make requests require authorization by adding [Authorize] attribute to controller actions, but 
some modifications need to be done for the token to carry metadata.
2. Add the token in a bearer token authorization method and you're set.