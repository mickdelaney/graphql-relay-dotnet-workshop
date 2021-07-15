# DB

## Migrate To Latest 
###= delete accounts.db, delete migration code  
``dotnet ef migrations add Initial``  
``dotnet ef database update``  

# GraphQL 

## mutation 

~~~~

mutation AddPerson {
    addPerson(input: {
      clientMutationId: "abc",
      name: "mick delaney",
      webSite: "mickdelaney.com"
    }) {
    clientMutationId
    person {
      node {
        id
        name
        webSite
      }
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