/* tslint:disable */
/* eslint-disable */
// @ts-nocheck

import { ConcreteRequest } from "relay-runtime";
export type AddPersonInput = {
    clientMutationId: string;
    name: string;
    webSite?: string | null;
};
export type CreatePerson_AddPersonMutationVariables = {
    input: AddPersonInput;
    connections: Array<string>;
};
export type CreatePerson_AddPersonMutationResponse = {
    readonly addPerson: {
        readonly person: {
            readonly cursor: string;
            readonly node: {
                readonly id: string;
                readonly name: string | null;
                readonly webSite: string | null;
            };
        };
    };
};
export type CreatePerson_AddPersonMutation = {
    readonly response: CreatePerson_AddPersonMutationResponse;
    readonly variables: CreatePerson_AddPersonMutationVariables;
};



/*
mutation CreatePerson_AddPersonMutation(
  $input: AddPersonInput!
) {
  addPerson(input: $input) {
    person {
      cursor
      node {
        id
        name
        webSite
      }
    }
  }
}
*/

const node: ConcreteRequest = (function(){
var v0 = {
  "defaultValue": null,
  "kind": "LocalArgument",
  "name": "connections"
},
v1 = {
  "defaultValue": null,
  "kind": "LocalArgument",
  "name": "input"
},
v2 = [
  {
    "kind": "Variable",
    "name": "input",
    "variableName": "input"
  }
],
v3 = {
  "alias": null,
  "args": null,
  "concreteType": "EdgeOfPerson",
  "kind": "LinkedField",
  "name": "person",
  "plural": false,
  "selections": [
    {
      "alias": null,
      "args": null,
      "kind": "ScalarField",
      "name": "cursor",
      "storageKey": null
    },
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
        }
      ],
      "storageKey": null
    }
  ],
  "storageKey": null
};
return {
  "fragment": {
    "argumentDefinitions": [
      (v0/*: any*/),
      (v1/*: any*/)
    ],
    "kind": "Fragment",
    "metadata": null,
    "name": "CreatePerson_AddPersonMutation",
    "selections": [
      {
        "alias": null,
        "args": (v2/*: any*/),
        "concreteType": "AddPersonPayload",
        "kind": "LinkedField",
        "name": "addPerson",
        "plural": false,
        "selections": [
          (v3/*: any*/)
        ],
        "storageKey": null
      }
    ],
    "type": "Mutation",
    "abstractKey": null
  },
  "kind": "Request",
  "operation": {
    "argumentDefinitions": [
      (v1/*: any*/),
      (v0/*: any*/)
    ],
    "kind": "Operation",
    "name": "CreatePerson_AddPersonMutation",
    "selections": [
      {
        "alias": null,
        "args": (v2/*: any*/),
        "concreteType": "AddPersonPayload",
        "kind": "LinkedField",
        "name": "addPerson",
        "plural": false,
        "selections": [
          (v3/*: any*/),
          {
            "alias": null,
            "args": null,
            "filters": null,
            "handle": "appendEdge",
            "key": "",
            "kind": "LinkedHandle",
            "name": "person",
            "handleArgs": [
              {
                "kind": "Variable",
                "name": "connections",
                "variableName": "connections"
              }
            ]
          }
        ],
        "storageKey": null
      }
    ]
  },
  "params": {
    "cacheID": "685535405ccde2783ea6a30e27386256",
    "id": null,
    "metadata": {},
    "name": "CreatePerson_AddPersonMutation",
    "operationKind": "mutation",
    "text": "mutation CreatePerson_AddPersonMutation(\n  $input: AddPersonInput!\n) {\n  addPerson(input: $input) {\n    person {\n      cursor\n      node {\n        id\n        name\n        webSite\n      }\n    }\n  }\n}\n"
  }
};
})();
(node as any).hash = 'dfb820bb06ae36a64702d589e11c1a5f';
export default node;
