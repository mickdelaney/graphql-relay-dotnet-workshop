/* tslint:disable */
/* eslint-disable */
// @ts-nocheck

import { ReaderFragment } from "relay-runtime";
import { FragmentRefs } from "relay-runtime";
export type PeopleList_people = {
    readonly people: {
        readonly __id: string;
        readonly pageInfo: {
            readonly hasNextPage: boolean;
            readonly hasPreviousPage: boolean;
            readonly startCursor: string | null;
            readonly endCursor: string | null;
        };
        readonly edges: ReadonlyArray<{
            readonly node: {
                readonly id: string;
                readonly name: string | null;
                readonly webSite: string | null;
                readonly " $fragmentRefs": FragmentRefs<"Person_person" | "PersonRow_person">;
            };
            readonly cursor: string;
        }> | null;
    } | null;
    readonly " $refType": "PeopleList_people";
};
export type PeopleList_people$data = PeopleList_people;
export type PeopleList_people$key = {
    readonly " $data"?: PeopleList_people$data;
    readonly " $fragmentRefs": FragmentRefs<"PeopleList_people">;
};



const node: ReaderFragment = (function(){
var v0 = [
  "people"
];
return {
  "argumentDefinitions": [
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
  "kind": "Fragment",
  "metadata": {
    "connection": [
      {
        "count": "first",
        "cursor": "after",
        "direction": "forward",
        "path": (v0/*: any*/)
      }
    ],
    "refetch": {
      "connection": {
        "forward": {
          "count": "first",
          "cursor": "after"
        },
        "backward": null,
        "path": (v0/*: any*/)
      },
      "fragmentPathInResult": [],
      "operation": require('./PeopleListPaginationQuery.graphql.ts')
    }
  },
  "name": "PeopleList_people",
  "selections": [
    {
      "alias": "people",
      "args": null,
      "concreteType": "PersonConnection",
      "kind": "LinkedField",
      "name": "__PeopleList_people_connection",
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
                },
                {
                  "args": null,
                  "kind": "FragmentSpread",
                  "name": "Person_person"
                },
                {
                  "args": null,
                  "kind": "FragmentSpread",
                  "name": "PersonRow_person"
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
    }
  ],
  "type": "Query",
  "abstractKey": null
};
})();
(node as any).hash = 'c1ecc931fd2ab20238d57755cf2209b2';
export default node;
