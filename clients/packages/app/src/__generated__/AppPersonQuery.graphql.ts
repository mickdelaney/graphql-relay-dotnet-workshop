/* tslint:disable */
/* eslint-disable */
// @ts-nocheck

import { ConcreteRequest } from "relay-runtime";
import { FragmentRefs } from "relay-runtime";
export type AppPersonQueryVariables = {};
export type AppPersonQueryResponse = {
    readonly " $fragmentRefs": FragmentRefs<"PeopleList_people">;
};
export type AppPersonQuery = {
    readonly response: AppPersonQueryResponse;
    readonly variables: AppPersonQueryVariables;
};



/*
query AppPersonQuery {
  ...PeopleList_people
}

fragment PeopleList_people on Query {
  people(first: 1) {
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
    "kind": "Literal",
    "name": "first",
    "value": 1
  }
];
return {
  "fragment": {
    "argumentDefinitions": [],
    "kind": "Fragment",
    "metadata": null,
    "name": "AppPersonQuery",
    "selections": [
      {
        "args": null,
        "kind": "FragmentSpread",
        "name": "PeopleList_people"
      }
    ],
    "type": "Query",
    "abstractKey": null
  },
  "kind": "Request",
  "operation": {
    "argumentDefinitions": [],
    "kind": "Operation",
    "name": "AppPersonQuery",
    "selections": [
      {
        "alias": null,
        "args": (v0/*: any*/),
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
        "storageKey": "people(first:1)"
      },
      {
        "alias": null,
        "args": (v0/*: any*/),
        "filters": null,
        "handle": "connection",
        "key": "PeopleList_people",
        "kind": "LinkedHandle",
        "name": "people"
      }
    ]
  },
  "params": {
    "cacheID": "bfec05a67e2c872ad9b664806376295b",
    "id": null,
    "metadata": {},
    "name": "AppPersonQuery",
    "operationKind": "query",
    "text": "query AppPersonQuery {\n  ...PeopleList_people\n}\n\nfragment PeopleList_people on Query {\n  people(first: 1) {\n    pageInfo {\n      hasNextPage\n      hasPreviousPage\n      startCursor\n      endCursor\n    }\n    edges {\n      node {\n        id\n        name\n        webSite\n        ...Person_person\n        ...PersonRow_person\n        __typename\n      }\n      cursor\n    }\n  }\n}\n\nfragment PersonRow_person on Person {\n  id\n  name\n  webSite\n}\n\nfragment Person_person on Person {\n  id\n  name\n  webSite\n}\n"
  }
};
})();
(node as any).hash = '95950e34589eff92d95ad9535f2e3729';
export default node;
