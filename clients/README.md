### Serve static build for testing
##### uses a proxy on the server graphql server
````
yarn build
serve -s build
````



## References 

### Monorepo Inspiration From
https://github.com/NiGhTTraX/ts-monorepo

### React Setup (Mostly)
https://www.carlrippon.com/creating-react-app-with-typescript-eslint-with-webpack5/

### Relay Setup 

### Getting your GraphQL Schema for Relay

`` https://www.npmjs.com/package/get-graphql-schema ``  
`` npm install -g get-graphql-schema ``

`` cd client ``  
`` get-graphql-schema https://localhost:5840/graphql > schema/schema.graphql ``  


### git hooks 
```json

  "pre-commit": "lint:staged",
  "lint-staged": {
    "*.{js,ts,tsx}": [
      "yarn prettier",
      "eslint --fix"
    ],
    "*.yml": [
      "prettier --write"
    ]
  },


```
