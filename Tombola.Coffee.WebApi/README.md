# Tombola
Technical assessment submission for Tombola.

## To Run
From the root of the project.

### Run migrations to create an SQLite database
```sh
  dotnet ef --project Tombola.Beans.WebApi database update
```

### Run Web Api
Use the http launch profile to run the Web API on port 8080.
It should start at http://localhost:8080.

### Run the Web UI
The Web UI can be run either using npm or docker.

```sh
    cd Tombola.Beans.Ui
    npm install
    npm run dev
```

## Approach
The below are some notes I will have filled in throughout the technical exercise to detail my thought process.

I'm thinking of completing both scenarios to close the loop between backend API and frontend as the two scenarios are closely coupled. If time permits, I'll also consider setting up a docker file to make it easier to run locally and deploy.

### Web API
I've started by setting up a solution with a standard controller-based Web API. I opted to stick with controllers over the alternative minimal APIs which can be performant out of the box, as controllers-based APIs are well understood. They are straightforward to follow and require less architectural decisions beneficial in the context of technical tests where you want to timebox the work. In practice, I would consider using minimal APIs as a first option for performance reasons.

As this is a technical test, I've set up SQLite, so it is straightforward to run locally. 


### UI
For the UI, I decided to use Next.js, as this is something that needs to be done quickly, and I find it easy to prototype quick views in next.js. If I wanted to stay within the .net ecosystem, I would opt for Blazor.




