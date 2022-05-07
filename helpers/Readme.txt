For authorization use the [Authorize] attribute
there should be a bearer token sent to the endpoints with [Authorize attribute]
Authhelpers.getUserEmail() returns an the user's email for example, but you have to pass it a Request,
because setting up the [ViewContext] attribute is proving to be tricky.