# DB

## Migrate To Latest 
###= delete accounts.db, delete migration code  
``dotnet ef migrations add Initial``  
``dotnet ef database update``  

# GraphQL 

## mutation 

~~~~
mutation AddSpeaker {
    addPerson(input: {
      name: "Speaker Name"
    }) {
    person {
        id
      }
    }
}
~~~~

## queries

~~~~ 
  query {
    people(order: { name: ASC }, where: { webSite: { eq: "gam.com" } }) {
      edges {
        cursor
        node {
          id
          name
          webSite
        }
      }
    }
  }
~~~~