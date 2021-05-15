/* tslint:disable */
/* eslint-disable */
// @ts-nocheck

import { ConcreteRequest } from "relay-runtime";
import { FragmentRefs } from "relay-runtime";
export type PeopleListPaginationQueryVariables = {
    after?: string | null;
    first?: number | null;
};
export type PeopleListPaginationQueryResponse = {
    readonly " $fragmentRefs": FragmentRefs<"PeopleList_people">;
};
export type PeopleListPaginationQuery = {
    readonly response: PeopleListPaginationQueryResponse;
    readonly variables: PeopleListPaginationQueryVariables;
};



/*
query PeopleListPaginationQuery(
  $after: String
  $first: Int = 1
) {
  ...PeopleList_people_2HEEH6
}

fragment PeopleList_people_2HEEH6 on Query {
  people(first: $first, after: $after) {
    pageInfo {
      hasNextPage
      hasPreviousPage
      startCursor
      endCursor
    }
    edges {
      node {
        id
        name
        webSite
        ...Person_person
        ...PersonRow_person
        __typename
      }
      cursor
    }
  }
}

fragment PersonRow_person on Person {
  id
  name
  webSite
}

fragment Person_person on Person {
  id
  name
  webSite
}
*/

const node: ConcreteRequest = (function(){
var v0 = [
  {
    "defaultValue": null,
    "kind": "LocalArgument",
    "name": "after"
  },
  {
    "defaultValue": 1,
    "kind": "LocalArgument",
    "name": "first"
  }
],
v1 = [
  {
    "kind": "Variable",
    "name": "after",
    "variableName": "after"
  },
  {
    "kind": "Variable",
    "name": "first",
    "variableName": "first"
  }
];
return {
  "fragment": {
    "argumentDefinitions": (v0/*: any*/),
    "kind": "Fragment",
    "metadata": null,
    "name": "PeopleListPaginationQuery",
    "selections": [
      {
        "args": (v1/*: any*/),
        "kind": "FragmentSpread",
        "name": "PeopleList_people"
      }
    ],
    "type": "Query",
    "abstractKey": null
  },
  "kind": "Request",
  "operation": {
    "argumentDefinitions": (v0/*: any*/),
    "kind": "Operation",
    "name": "PeopleListPaginationQuery",
    "selections": [
      {
        "alias": null,
        "args": (v1/*: any*/),
        "concreteType": "PersonConnection",
        "kind": "LinkedField",
        "name": "people",
        "plural": false,
        "selections": [
          {
            "alias": null,
            "args": null,
            "concreteType": "PageInfo",
            "kind": "LinkedField",
            "name": "pageInfo",
            "plural": false,
            "selections": [
              {
                "alias": null,
                "args": null,
                "kind": "ScalarField",
                "name": "hasNextPage",
                "storageKey": null
              },
              {
                "alias": null,
                "args": null,
                "kind": "ScalarField",
                "name": "hasPreviousPage",
                "storageKey": null
              },
              {
                "alias": null,
                "args": null,
                "kind": "ScalarField",
                "name": "startCursor",
                "storageKey": null
              },
              {
                "alias": null,
                "args": null,
                "kind": "ScalarField",
                "name": "endCursor",
                "storageKey": null
              }
            ],
            "storageKey": null
          },
          {
            "alias": null,
            "args": null,
            "concreteType": "PersonEdge",
            "kind": "LinkedField",
            "name": "edges",
            "plural": true,
            "selections": [
              {
                "alias": null,
                "args": null,
                "concreteType": "Person",
                "kind": "LinkedField",
                "name": "node",
                "plural": false,
                "selections": [
                  {
                    "alias": null,
                    "args": null,
                    "kind": "ScalarField",
                    "name": "id",
                    "storageKey": null
                  },
                  {
                    "alias": null,
                    "args": null,
                    "kind": "ScalarField",
                    "name": "name",
                    "storageKey": null
                  },
                  {
                    "alias": null,
                    "args": null,
                    "kind": "ScalarField",
                    "name": "webSite",
                    "storageKey": null
                  },
                  {
                    "alias": null,
                    "args": null,
                    "kind": "ScalarField",
                    "name": "__typename",
                    "storageKey": null
                  }
                ],
                "storageKey": null
              },
              {
                "alias": null,
                "args": null,
                "kind": "ScalarField",
                "name": "cursor",
                "storageKey": null
              }
            ],
            "storageKey": null
          },
          {
            "kind": "ClientExtension",
            "selections": [
              {
                "alias": null,
                "args": null,
                "kind": "ScalarField",
                "name": "__id",
                "storageKey": null
              }
            ]
          }
        ],
        "storageKey": null
      },
      {
        "alias": null,
        "args": (v1/*: any*/),
        "filters": null,
        "handle": "connection",
        "key": "PeopleList_people",
        "kind": "LinkedHandle",
        "name": "people"
      }
    ]
  },
  "params": {
    "cacheID": "149f80f52ad277b97b752f65d7bb0e3d",
    "id": null,
    "metadata": {},
    "name": "PeopleListPaginationQuery",
    "operationKind": "query",
    "text": "query PeopleListPaginationQuery(\n  $after: String\n  $first: Int = 1\n) {\n  ...PeopleList_people_2HEEH6\n}\n\nfragment PeopleList_people_2HEEH6 on Query {\n  people(first: $first, after: $after) {\n    pageInfo {\n      hasNextPage\n      hasPreviousPage\n      startCursor\n      endCursor\n    }\n    edges {\n      node {\n        id\n        name\n        webSite\n        ...Person_person\n        ...PersonRow_person\n        __typename\n      }\n      cursor\n    }\n  }\n}\n\nfragment PersonRow_person on Person {\n  id\n  name\n  webSite\n}\n\nfragment Person_person on Person {\n  id\n  name\n  webSite\n}\n"
  }
};
})();
(node as any).hash = 'c1ecc931fd2ab20238d57755cf2209b2';
export default node;
