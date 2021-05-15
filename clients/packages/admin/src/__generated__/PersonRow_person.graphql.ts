/* tslint:disable */
/* eslint-disable */
// @ts-nocheck

import { ReaderFragment } from "relay-runtime";
import { FragmentRefs } from "relay-runtime";
export type PersonRow_person = {
    readonly id: string;
    readonly name: string | null;
    readonly webSite: string | null;
    readonly " $refType": "PersonRow_person";
};
export type PersonRow_person$data = PersonRow_person;
export type PersonRow_person$key = {
    readonly " $data"?: PersonRow_person$data;
    readonly " $fragmentRefs": FragmentRefs<"PersonRow_person">;
};



const node: ReaderFragment = {
  "argumentDefinitions": [],
  "kind": "Fragment",
  "metadata": null,
  "name": "PersonRow_person",
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
(node as any).hash = 'cf23fa2279e0ab48b8fa1cb60b2bc04a';
export default node;
