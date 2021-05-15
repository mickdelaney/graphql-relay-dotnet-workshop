/* tslint:disable */
/* eslint-disable */
// @ts-nocheck

import { ReaderFragment } from "relay-runtime";
import { FragmentRefs } from "relay-runtime";
export type Person_person = {
    readonly id: string;
    readonly name: string | null;
    readonly webSite: string | null;
    readonly " $refType": "Person_person";
};
export type Person_person$data = Person_person;
export type Person_person$key = {
    readonly " $data"?: Person_person$data;
    readonly " $fragmentRefs": FragmentRefs<"Person_person">;
};



const node: ReaderFragment = {
  "argumentDefinitions": [],
  "kind": "Fragment",
  "metadata": null,
  "name": "Person_person",
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
  "type": "Person",
  "abstractKey": null
};
(node as any).hash = '4cbae1a4a698c6b2ddb5be9648dbfd1a';
export default node;
