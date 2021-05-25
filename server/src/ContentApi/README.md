# DB

## Migrate To Latest 
###= delete accounts.db, delete migration code

``dotnet tool update --global dotnet-ef``  
``dotnet tool update dotnet-ef``  


``dotnet ef migrations add Initial``  
``dotnet ef database update``  

# GraphQL 

## mutation 

~~~~
mutation AddContentType {
    addContentType(input: {
      clientMutationId: "12345",
      name: "Posts",
      ownerId: 1
    }) {
    contentType {
        node {
          id
          name
          ownerId
        }
      }
    }
}
~~~~

~~~~
mutation AddContentType {
    addContentItem(input: {
      clientMutationId: "12345",
      name: "Tutorial On Graphql, Relay, Dotnet Part 2",
      ownerId: 1,
      contentTypeId: 1,
      tag: "Tutorial"
    }) {
    contentItem {
        node {
          id
          name
          ownerId
          tag
          contentType {
            name
          }
        }
      }
    }
}
~~~~

## queries

~~~~ 
  query {
   contentItem(order: { name: ASC }) {
      edges {
        cursor
        node {
          id
          name
          tag
          contentType {
            name
          }
        }
      }
   }
  }

~~~~