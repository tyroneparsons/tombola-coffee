# Tombola
Technical assessment submission for Tombola.

## To Run
### Run migrations to create an SQLite database
Run from the root of the solution:
```sh
  dotnet ef --project Tombola.Coffee.WebApi database update
```

I've included an SQLite database in the repository I would usually exclude that can be used in case there are any issues with running migrations.

### Run
Use the http launch profile to run the Web API on port 5035.
It should start at http://localhost:5035.

### Test
You can test the API using the provided Tombola.Coffee.WebApi.http or the by navigating to http://localhost:5035/scalar/v1 to use the interactive docs.

## Approach
The below are some notes I will have filled in throughout the technical exercise to detail my thought process.

I've tried to take a pragmatic approach to this.

### Web API
I've started by setting up a solution with a standard controller-based Web API. I opted to stick with controllers over the alternative minimal APIs which can be performant out of the box, as controllers-based APIs are well understood. They are straightforward to follow and require less architectural decisions beneficial in the context of technical tests where you want to timebox the work. In practice, I would consider using minimal APIs as a first option for performance reasons.

As this is a technical test, I've set up SQLite, so it is straightforward to run locally.

I've set up a simple Bean Dto so fields can optionally be returned for security + flexibility.

I've snuck the Bean Of the Day feature into the call to get the bean of the day. This means that at every call, there is a little overhead in checking if the bean of the day already exists. In practice, I would use something like a hosted service, cron job or AWS Lambda function to manage something like this. I opted to keep this simple so that the solution is easy to set up and run.

## Future Enhancements
* Implement OAuth2/bearer tokens to protect the API
* Separate out the colour + country fields into their own tables to ensure consistency at a database level
* Use a more robust database such as SQL Server/Postgres